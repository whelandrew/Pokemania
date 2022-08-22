using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Characters;
using StardewValley.Menus;

namespace PokemaniaMain
{
    public class ModEntry : Mod
    {
        bool dialogueShown;
        //PetInfo curPet;
        Pet curPet;
        public ToReplace toReplace = new Pokedex().GetAllPokemon();
        public override void Entry(IModHelper helper)
        {
           

            helper.Events.Content.AssetRequested += OnAssetRequested;
            helper.Events.Input.ButtonPressed += OnButtonPressed;
            helper.Events.GameLoop.UpdateTicked += CheckForPet;
        }

        private void CheckForPet(object sender, UpdateTickedEventArgs e)
        {
            //Console.WriteLine(e);
            GameLocation location = Game1.currentLocation;
            if(location != null && location.IsFarm)
            {
                //curPet = new PetInfo(Game1.player.getPet());
                curPet = Game1.player.getPet();
                if(curPet != null)
                {
                    //petInfo.startGlowing(Color.Black, true, 10f);
                    //Console.WriteLine(petInfo);
                }
            }
        }
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            //if(sender!=null)
            { 
            if (e.Button.IsActionButton())
            {
                    if (curPet != null)
                    {
                        StardewValley.Item curItem = Game1.player.CurrentItem;
                        //check if player is holding fire stone
                        //if (curItem.parentSheetIndex == 82)
                        {
                            //check player is using the item on pet
                            ReceiveObject();
                            //curPet.tryToReceiveActiveObject(Game1.player);
                            //curPet.receiveObject(Game1.player, curItem);

                            //check that pet has been evolved

                            //ask if player wants to evolve
                        }
                    }
                }
            }
        }

        private void ReceiveObject()
        {           
            //curPet.tryToReceiveActiveObject(Game1.player);
        }

        private void LoadEvolveWindow()
        {
            if (!dialogueShown)
            {
                dialogueShown = true;
                GameLocation location = Game1.currentLocation;
                Response[] responses = { new Response("0", "Evolve " + Game1.player.getPet().Name), new Response("1", "Do not evolve") };
                location.createQuestionDialogue(Game1.player.getPet().Name + " gives off a magical glow...", responses, delegate (Farmer _, string answer)
                    {
                        switch (answer)
                        {
                            case "0": ChangePetSprite(Game1.player.getPet()); break;
                            case "1": break;
                        }
                    });
            }
        }

        private void ChangePetSprite(Pet pet)
        {

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