using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Characters;
using System.IO;
using HarmonyLib;
using System;
using Microsoft.Xna.Framework.Audio;
using System.Threading.Tasks;
using System.Collections.Generic;

public class PetInfo
{
    private static bool hasSaved {get;set;}
    public static bool enabled { get; private set; }
    private static bool soundLoaded { get; set; }
    private static IMonitor Monitor { get; set; }
    private static IModHelper helper {get; set; }
    private static AllPets allPets { get; set; }

    private static PetData savedPet { get; set; }

    public PetInfo HarmonyPetPatch(Harmony harmony, IMonitor monitor, IModHelper _helper)
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

        return this;
    }

    private static void setAtFarmPosition()
    {
        allPets = helper.Data.ReadJsonFile<AllPets>("petData.json") ?? new AllPets();
        savedPet = new PetData(Game1.player.UniqueMultiplayerID, Game1.player.getPet().Name, false, "");
        foreach(PetData i in allPets.pets)
        {
            if (i.name == Game1.player.getPet().Name)
            {
                savedPet = i;
                if (i.hasEvolved)
                {
                    ChangePetSprite(i.fileName, Game1.player, Game1.player.getPet());
                }
            }
        }

        if (!soundLoaded)
            InstallEvolveSound();
    }

    
    private static void InstallEvolveSound()
    {
        CueDefinition myCueDefinition = new CueDefinition();
        myCueDefinition.name = "evolveSuccess";
        myCueDefinition.instanceLimit = 1;
        myCueDefinition.limitBehavior = CueDefinition.LimitBehavior.ReplaceOldest;
        SoundEffect audio;
        string filePathCombined = Path.Combine(helper.DirectoryPath, Directory.GetCurrentDirectory() + "/mods/Pokemania_Eeveelution/pokemania/assets/evolves/success.wav");
        using (var stream = new FileStream(filePathCombined, System.IO.FileMode.Open))
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
            if (!savedPet.hasEvolved && savedPet.name == pet.Name)
            {
                if (who.ActiveObject != null)
                {
                    GameLocation location = Game1.currentLocation;
                    Response[] responses = { new Response("0", "Evolve " + Game1.player.getPet().Name), new Response("1", "Do not evolve") };

                    if (Game1.player.CurrentItem.ParentSheetIndex == 82)
                    {
                        if (pet.Sprite.Texture.Name == "Animals/dog" || pet.Sprite.Texture.Name == "Animals/cat")
                        {
                            who.Halt();
                            who.faceGeneralDirection(Game1.player.getStandingPosition(), 0, opposite: false, useTileCalculations: false);
                            who.faceTowardFarmerForPeriod(4000, 3, faceAway: false, Game1.player);
                            location.createQuestionDialogue(Game1.player.getPet().Name + " gives off a magical glow...", responses, delegate (Farmer _, string answer)
                            {
                                switch (answer)
                                {
                                    case "0":
                                        if (Game1.player.CurrentItem.ParentSheetIndex == 82 && pet.Sprite.Texture.Name == "Animals/dog") //is growlithe
                                        {
                                            EvolveStart(who, pet, "arcanine.xnb");
                                        }
                                        else
                                        if (Game1.player.CurrentItem.ParentSheetIndex == 82 && pet.Sprite.Texture.Name == "Animals/cat") //is flareon
                                        {
                                            EvolveStart(who, pet, "flareon.xnb");
                                        }
                                        break;
                                    case "1": break;
                                }
                            });
                        }
                    }
                    else
                    if (Game1.player.CurrentItem.ParentSheetIndex == 84 || Game1.player.CurrentItem.ParentSheetIndex == 86)
                    {
                        who.Halt();
                        who.faceGeneralDirection(Game1.player.getStandingPosition(), 0, opposite: false, useTileCalculations: false);
                        who.faceTowardFarmerForPeriod(4000, 3, faceAway: false, Game1.player);
                        location.createQuestionDialogue(Game1.player.getPet().Name + " gives off a magical glow...", responses, delegate (Farmer _, string answer)
                        {
                            switch (answer)
                            {
                                case "0":
                                    if (Game1.player.CurrentItem.ParentSheetIndex == 84) //is vaporeon
                                    {
                                        EvolveStart(who, pet, "vaporeon.xnb");
                                    }
                                    else
                                    if (Game1.player.CurrentItem.ParentSheetIndex == 86) //is jolteon
                                    {
                                        EvolveStart(who, pet, "jolteon.xnb");
                                    }
                                    break;
                                case "1": break;
                            }
                        });
                    }
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
        
        savedPet.id = Game1.player.UniqueMultiplayerID;
        savedPet.hasEvolved = true;
        savedPet.fileName = fileName;        
        
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
        //SaveChanges(pet, fileName);
        who.reduceActiveItemByOne();
        who.completelyStopAnimatingOrDoingAction();
        pet.faceTowardFarmerForPeriod(4000, 3, faceAway: false, who);
        Game1.screenGlowOnce(Color.White, false, .009f, 0);
    }
    private static void ChangePetSprite(string fileName, Farmer who, Pet pet)
    {
        string file = Directory.GetCurrentDirectory() + "/mods/Pokemania_Eeveelution/pokemania/assets/evolves/" + fileName;
        pet.Sprite = new AnimatedSprite();
        pet.Sprite.LoadTexture(file);
        Vector2 offset = pet.appliedRouteAnimationOffset;
        pet.Sprite.SourceRect = new Rectangle(0, 224, 32, 32);
        pet.Sprite.SpriteWidth = 32;
        pet.Sprite.SpriteHeight = 32;
    }

    public void SaveChanges()
    {
        if (savedPet != null && !hasSaved)
        {
            hasSaved = true;
            allPets.pets.Add(savedPet);
            helper.Data.WriteJsonFile("petData.json", allPets);
        }
    }
}

public class AllPets
{
    public List<PetData> pets;
}

public class PetData
{
    public PetData(long petID, string petName, bool hasEvolved, string fileName)
    {
        id = petID;
        name = petName;
        this.hasEvolved = hasEvolved;
        this.fileName = fileName;   
    }
    public long id { get; set; }
    public string name { get; set; }
    public bool hasEvolved { get; set; }
    public string fileName;
}