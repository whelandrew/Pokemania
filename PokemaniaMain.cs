using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Characters;

namespace PokemaniaMain
{
    public class ModEntry : Mod
    {
        public ToReplace toReplace = new Pokedex().GetAllPokemon();
        public override void Entry(IModHelper helper)
        {
            helper.Events.Content.AssetRequested += OnAssetRequested;
            helper.Events.Input.ButtonPressed += OnButtonPressed;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {    
            if (e.Button.IsActionButton())
            {                      
                
                if (Game1.player.name != "" && Game1.player.hasPet())
                {
                    StardewValley.Item curItem = Game1.player.CurrentItem;
                    //check if player is holding fire stone
                    //if (Game1.player.IsCarrying())
                    //if (curItem != null)
                    {
                        if (curItem.parentSheetIndex.Equals(82))
                        {
                            //check that pet has been evolved
                            //ask if player wants to evolve
                            //evolve pet
                            //bool test = Game1.player.hasPlayerTalkedToNPC(pet.Name);
                            //Game1.player.talkToFriend(pet);
                            //Netcode.NetBool test = pet.collidesWithOtherCharacters;

                            //Game1.player.collideWith((StardewValley.Object) pet);
                            //pet.collideWith();
                            //if (!pet.uniquePortraitActive)
                            //{
                                //if (pet.whichBreed.Equals(0))//growlithe
                            //    {
                                    //ChangePetSprite();
                            //    }
                            //}
                        }
                        //Console.WriteLine(Game1.player.IsCarrying());
                        //Item item = Game1.player.Items();
                    }
                }
            }
        }

        private void ChangePetSprite()
        {
            Pet pet = Game1.player.getPet();

            string file = Directory.GetCurrentDirectory() + "/mods/pokemania/assets/evolves/dog.xnb";
            pet.Sprite = new AnimatedSprite();
            pet.Sprite.LoadTexture(file);
            Vector2 offset = pet.appliedRouteAnimationOffset;
            pet.Sprite.SourceRect = new Rectangle(0, 224, 32, 32);
            pet.Sprite.SpriteWidth = 32;
            pet.Sprite.SpriteHeight = 32;
            pet.uniqueSpriteActive = true;
        }

        private void OnAssetRequested(object sender, AssetRequestedEventArgs e)
        {
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
                        IRawTextureData image = Helper.ModContent.Load<IRawTextureData>(i.FromFile);
                        asset.AsImage().PatchImage(source: image);
                    });
                }
            }
        }
    }
}