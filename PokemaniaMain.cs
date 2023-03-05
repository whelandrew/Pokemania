using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Security;
using HarmonyLib;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Characters;

namespace PokemaniaMain
{
    public class ModEntry : Mod
    {
        private static PetInfo pInfo = new PetInfo();
        private static IMonitor monitor;
        public ToReplace toReplace = new Pokedex().GetAllPokemon();
        private SoundPlayer sPlayer;
        public override void Entry(IModHelper helper)
        {
            monitor = Monitor;
            var harmony = new Harmony(ModManifest.UniqueID);
            pInfo.HarmonyPetPatch(harmony, Monitor, helper);
            sPlayer = new SoundPlayer(helper);

            helper.Events.GameLoop.Saved += OnSaved;
            //helper.Events.GameLoop.DayStarted += OnDayStarted;
            //helper.Events.Player.Warped += OnPlayerWarped;
            //helper.Events.Content.AssetRequested += OnAssetRequested;
            //helper.Events.GameLoop.UpdateTicked += OnUpdateTicked;
            helper.Events.GameLoop.SaveLoaded += OnSaveLoaded;

        }

        private void OnSaveLoaded(object sender, EventArgs e)
        {
            pInfo.CheckForPet();
        }

        private void OnDayStarted(object sender, EventArgs e)
        {
            //pInfo.CheckForPet();
        }

        private void OnPlayerWarped(object sender, EventArgs e)
        {
            //pInfo.CheckForPet();
        }

        private void OnSaved(object sender, SavedEventArgs e)
        {
            pInfo.SaveChanges();
        }

        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
        }


        private void OnAssetRequested(object sender, AssetRequestedEventArgs e)
        {
            /*
            List<Item> items = toReplace.Changes.FindAll(x => x.Target == e.Name.Name);
            foreach (Item i in items)
            {
                if (i.Action == "EditData")
                {
                    e.Edit(asset =>
                    {
                        try
                        {
                            var data = asset.AsDictionary<string, string>().Data;
                            foreach (KeyValuePair<string, string> j in i.Entries)
                            {
                                data[j.Key] = j.Value;
                            }
                        }
                        catch
                        {
                            var data = asset.AsDictionary<int, string>().Data;
                            foreach (KeyValuePair<string, string> j in i.Entries)
                            {
                                int key = int.Parse(j.Key);
                                data[key] = j.Value;
                            }
                        }
                    });
                }
                if (i.Action == "EditImage")
                {
                    e.Edit(asset =>
                    {
                        IRawTextureData image = Helper.ModContent.Load<IRawTextureData>(i.FromFile);
                        Rectangle fromRect = i.FromArea;
                        Rectangle toRect = new Rectangle((int)i.ToArea.X, (int)i.ToArea.Y, i.FromArea.Width, i.FromArea.Height);
                        try
                        {
                            asset.AsImage().PatchImage(source: image, sourceArea: fromRect, targetArea: toRect, patchMode: i.PatchMode);
                        }
                        catch (InvalidCastException e)
                        {
                            Debug.WriteLine(e.Message);
                        }
                    });
                }
                else
                    if (i.Action == "Load")
                {
                    e.Edit(asset =>
                    {
                        try
                        {
                            IRawTextureData image = Helper.ModContent.Load<IRawTextureData>(i.FromFile);
                            asset.AsImage().PatchImage(source: image);
                        }
                        catch(Exception e)
                        {
                            monitor.Log(e.Message);
                        }
                    });
                }            
            }
            */
        }
    }
}