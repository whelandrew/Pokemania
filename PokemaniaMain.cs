using System;
using HarmonyLib;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace PokemaniaMain
{
    public sealed class Configs
    {
        public bool Pokepets { get; set; } = true;
        public bool Pokeanimals { get; set; } = true;
    }

    public class ModEntry : Mod
    {
        private static PetInfo pInfo = new PetInfo();
        private static IMonitor monitor;
        public ToReplace toReplace = new Pokedex().GetAllPokemon();
        private SoundPlayer sPlayer;
        private Configs configs;

        public override void Entry(IModHelper helper)
        {
            monitor = Monitor;
            var harmony = new Harmony(ModManifest.UniqueID);
            pInfo.HarmonyPetPatch(harmony, Monitor, helper);
            sPlayer = new SoundPlayer(helper);

            helper.Data.ReadJsonFile<AllPets>("petData.json");
            configs = Helper.ReadConfig<Configs>();
            pInfo.SetPokepetsOn(configs.Pokepets);

            helper.Events.GameLoop.Saved += OnSaved;
            helper.Events.GameLoop.SaveLoaded += OnSaveLoaded;
        }

        private void OnSaveLoaded(object sender, EventArgs e)
        {
            pInfo.CheckForPet();
        }

        private void OnSaved(object sender, SavedEventArgs e)
        {
            pInfo.SaveChanges();
        }
    }
}