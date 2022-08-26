using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Characters;
using System.IO;
using HarmonyLib;
using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Audio;
using StardewValley.Monsters;
using Microsoft.Xna.Framework.Graphics;

public class PetInfo
{
    public static bool enabled { get; private set; }
    private static bool soundLoaded { get; set; }
    private static IMonitor Monitor { get; set; }
    private static IModHelper helper {get; set; }
    private static PetData savedPet { get; set; }

    public static void HarmonyPetPatch(Harmony harmony, IMonitor monitor, IModHelper _helper)
    {
        if (!enabled && monitor != null)
        {
            helper = _helper;
            Monitor = monitor;
            Monitor.Log("HarmonyPetPatch \"checkAction\"");
            harmony.Patch(
               original: AccessTools.Method(typeof(Pet), nameof(Pet.checkAction)),
               prefix: new HarmonyMethod(typeof(PetInfo), nameof(PetInfo.checkAction))
            );
            enabled = true;
        }

        harmony.Patch(
               original: AccessTools.Method(typeof(Pet), nameof(Pet.setAtFarmPosition)),
               prefix: new HarmonyMethod(typeof(PetInfo), nameof(PetInfo.setAtFarmPosition))
            );
    }

    //make pet glow
    public static void setAtFarmPosition()
    {
        savedPet = helper.Data.ReadJsonFile<PetData>("petData.json") ?? new PetData(0, "0", false,""); ;
        if (savedPet != null && savedPet.hasEvolved)
        {
            ChangePetSprite(savedPet.fileName, Game1.player, Game1.player.getPet());
        }
        else
        {
            if(!soundLoaded)
                InstallEvolveSound();
        }
        //Game1.player.getPet().startGlowing(Color.White, false, 1f);
    }

    
    private static void InstallEvolveSound()
    {
        CueDefinition myCueDefinition = new CueDefinition();
        myCueDefinition.name = "evolveSuccess";
        myCueDefinition.instanceLimit = 1;
        myCueDefinition.limitBehavior = CueDefinition.LimitBehavior.ReplaceOldest;
        SoundEffect audio;
        string filePathCombined = Path.Combine(helper.DirectoryPath, Directory.GetCurrentDirectory() + "/mods/pokemania/assets/evolves/success.wav");
        using (var stream = new System.IO.FileStream(filePathCombined, System.IO.FileMode.Open))
        {
            audio = SoundEffect.FromStream(stream);
        }
        myCueDefinition.SetSound(audio, Game1.audioEngine.GetCategoryIndex("Sound"), false);
        Game1.soundBank.AddCue(myCueDefinition);
    }

    public static void checkAction(StardewValley.Object __instance)
    {
        try
        {
            Farmer who = Game1.player;
            Pet pet = who.getPet();
            if (!savedPet.hasEvolved)
            {
                if (who.ActiveObject != null)
                {
                    who.Halt();
                    who.faceGeneralDirection(Game1.player.getStandingPosition(), 0, opposite: false, useTileCalculations: false);
                    who.faceTowardFarmerForPeriod(4000, 3, faceAway: false, Game1.player);
                    GameLocation location = Game1.currentLocation;
                    Response[] responses = { new Response("0", "Evolve " + Game1.player.getPet().Name), new Response("1", "Do not evolve") };
                    location.createQuestionDialogue(Game1.player.getPet().Name + " gives off a magical glow...", responses, delegate (Farmer _, string answer)
                    {
                        switch (answer)
                        {
                            case "0":
                                if (Game1.player.CurrentItem.ParentSheetIndex == 82)
                                {
                                    EvolveStart(who, pet, "dog.xnb");                                    
                                }
                                break;
                            case "1": break;
                        }
                    });
                }
            }
        }
        catch (Exception e)
        {
            Monitor.LogOnce("HarmonyPatch tryToReceiveActiveObject failed " + e.Message);
        }
    }
    private static void EvolveStart(Farmer who, Pet pet, string fileName)    
    {
        who.Halt();
        who.faceGeneralDirection(Game1.player.getStandingPosition(), 0, opposite: false, useTileCalculations: false);
        who.faceTowardFarmerForPeriod(4000, 3, faceAway: false, Game1.player);
        EvolveAnimate(who, pet);
        ChangePetSprite(fileName, who, pet);
        EvolveFinished(who, pet, fileName);
    }

    public static void EvolveAnimate(Farmer who, Pet pet)
    {
        Game1.currentLocation.//explode(pet.Position, 50, who, false);
        //Game1.screenGlowOnce(Color.White, false,0.005f,1);
    }

    public static void EvolveFinished(Farmer who, Pet pet, string fileName)
    {
        Game1.drawObjectDialogue(pet.Name + " has evolved!");
        Game1.playSound("evolveSuccess");
        SaveChanges(pet, fileName);
        who.reduceActiveItemByOne();
        who.completelyStopAnimatingOrDoingAction();
        pet.faceTowardFarmerForPeriod(4000, 3, faceAway: false, who); 
    }

    public static void ChangePetSprite(string fileName, Farmer who, Pet pet)
    {
        string file = Directory.GetCurrentDirectory() + "/mods/pokemania/assets/evolves/" + fileName;
        pet.Sprite = new AnimatedSprite();
        pet.Sprite.LoadTexture(file);
        Vector2 offset = pet.appliedRouteAnimationOffset;
        pet.Sprite.SourceRect = new Rectangle(0, 224, 32, 32);
        pet.Sprite.SpriteWidth = 32;
        pet.Sprite.SpriteHeight = 32;
    }

    private static void SaveChanges(Pet curPet, string fileName)
    {
        savedPet = new PetData(curPet.id, curPet.Name, true, fileName);
        //helper.Data.WriteJsonFile("petData.json", savedPet);
    }
}

public class PetData
{
    public PetData(int petID, string petName, bool hasEvolved, string fileName)
    {
        id = petID;
        name = petName;
        this.hasEvolved = hasEvolved;
        this.fileName = fileName;   
    }
    public int id { get; set; }
    public string name { get; set; }
    public bool hasEvolved { get; set; }
    public string fileName;
}