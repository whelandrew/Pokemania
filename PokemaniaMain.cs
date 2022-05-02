using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace PokemaniaMain
{
    public class ModEntry : Mod
    {
        private IModHelper modHelper;
        public override void Entry(IModHelper helper)
        {
            modHelper = helper;

            helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
        }
        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            Helper.Content.AssetEditors.Add(new ImageReplacers(Helper));
            Helper.Content.AssetEditors.Add(new ImageEdits(Helper));
        }
    }
}