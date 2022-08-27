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
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;

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

    private static void setAtFarmPosition()
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

    private static void checkAction(StardewValley.Object __instance)
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
    private static async void EvolveStart(Farmer who, Pet pet, string fileName)    
    {
        who.Halt();
        who.faceGeneralDirection(Game1.player.getStandingPosition(), 0, opposite: false, useTileCalculations: false);
        who.faceTowardFarmerForPeriod(4000, 3, faceAway: false, Game1.player);

        //EvolveAnimate(who, pet);
        await EvolveAnimate(who, pet);
        ChangePetSprite(fileName, who, pet);
        EvolveFinished(who, pet, fileName);
    }     

    private static async Task EvolveAnimate(Farmer who, Pet pet)
    {
        Game1.screenGlowOnce(Color.White, true, .009f, 1);
        Game1.playSound("secret1");
        await Task.Delay(2000);        
    }

    private static void EvolveFinished(Farmer who, Pet pet, string fileName)
    {
        Game1.drawObjectDialogue(pet.Name + " has evolved!");
        Game1.playSound("evolveSuccess");
        SaveChanges(pet, fileName);
        who.reduceActiveItemByOne();
        who.completelyStopAnimatingOrDoingAction();
        pet.faceTowardFarmerForPeriod(4000, 3, faceAway: false, who);
        Game1.screenGlowOnce(Color.White, false, .009f, 0);
    }
    private static void ChangePetSprite(string fileName, Farmer who, Pet pet)
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
        helper.Data.WriteJsonFile("petData.json", savedPet);
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