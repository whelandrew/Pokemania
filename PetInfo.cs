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
using Rectangle = Microsoft.Xna.Framework.Rectangle;

public class PetInfo
{
    private static bool hasSaved { get; set; }
    public static bool enabled { get; private set; }    
    private static IMonitor Monitor { get; set; }
    private static IModHelper helper { get; set; }
    private static AllPets allPets { get; set; }
    private static PetData curPet { get; set; }
    private static bool evolveSoundLoaded { get; set; }
    private static bool crySoundLoaded { get; set; }

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
        return this;
    }

    public void CheckForPet()
    {
        allPets = helper.Data.ReadJsonFile<AllPets>("petData.json") ?? new AllPets();
        Pet pet = Game1.player.getPet();
        if (pet != null)
        {
            PetData foundPet = allPets.pets.Find(x => x.name == pet.name);
            if (foundPet == null)
            {
                //create new pet data
                PetData newPet = new PetData(Game1.player.UniqueMultiplayerID, pet.Name, false, pet.Sprite.Texture.Name, pet.friendshipTowardFarmer, GetPetType(), Game1.player.catPerson);
                allPets.pets.Add(newPet);
                curPet = newPet;
            }
            else
            {
                //update found pet data
                curPet = foundPet;
            }

                if (!crySoundLoaded)
                    ChangeSpriteAudio();

            if (!evolveSoundLoaded)
                InstallEvolveSound();
        }
        else
        {
            InstallPetCry("cat", "");
            InstallPetCry("dog_bark", "");
        }
    }

    private int GetPetType()
    {
        Pet pet = Game1.player.getPet();
        if (pet.Sprite.Texture.Name == "Animals/dog") return 3;
        if (pet.Sprite.Texture.Name == "Animals/cat") return 0;
        if (pet.Sprite.Texture.Name == "Animals/cat1") return 1;
        if (pet.Sprite.Texture.Name == "Animals/dog1") return 4;
        if (pet.Sprite.Texture.Name == "Animals/cat2") return 2;
        if (pet.Sprite.Texture.Name == "Animals/dog2") return 5;


        if (curPet == null) return -1;
        //evolved ids
        if(curPet.hasEvolved) ChangeSpriteAudio();

        return -1;
    }

    private static void InstallEvolveSound()
    {
        CueDefinition myCueDefinition = new CueDefinition();
        myCueDefinition.name = "evolveSuccess";
        myCueDefinition.instanceLimit = 1;
        myCueDefinition.limitBehavior = CueDefinition.LimitBehavior.ReplaceOldest;
        SoundEffect audio;
        string path = Path.Combine(helper.DirectoryPath, "assets/audio", "success.wav");
        string file = new FileInfo(path).FullName;
        using (var stream = new FileStream(file, FileMode.Open))
        {
            audio = SoundEffect.FromStream(stream);
        }
        myCueDefinition.SetSound(audio, Game1.audioEngine.GetCategoryIndex("Sound"), false);
        Game1.soundBank.AddCue(myCueDefinition);

        evolveSoundLoaded = true;
    }

    private static void InstallPetCry(string petType, string cryName)
    {
        var petCry = Game1.soundBank.GetCueDefinition(petType);
        SoundEffect audio;
        if (cryName == "")
        {
            audio = null;
        }
        else
        {
            string filePathCombined = Path.Combine(helper.DirectoryPath, "assets/audio", cryName);
            using (var stream = new FileStream(filePathCombined, FileMode.Open))
            {
                audio = SoundEffect.FromStream(stream);
            }
        }

        petCry.SetSound(audio, Game1.audioEngine.GetCategoryIndex("Sound"), false);
        crySoundLoaded = true;
    }

    private static void checkAction(StardewValley.Object __instance)
    {
        try
        {
            if (Game1.player.hasPet())
            {
                if (allPets.stopAsking) return;

                Pet pet = Game1.player.getPet();
                PetData curPet = allPets.pets.Find(x => x.fileName == pet.Sprite.Texture.Name);
                if (curPet == null || !curPet.hasEvolved)
                {
                    if (Game1.player.ActiveObject != null)
                    {
                        if (Game1.player.CurrentItem.ParentSheetIndex == 82)
                        {
                            if (curPet.pType == 3 || curPet.pType == 0)
                            {
                                if (Game1.player.CurrentItem.ParentSheetIndex == 82 && curPet.pType==3) //is growlithe
                                {
                                    AskQuestion("arcanine.xnb");
                                }
                                else
                                if (Game1.player.CurrentItem.ParentSheetIndex == 82 && curPet.pType == 0) //is flareon
                                {
                                    AskQuestion("flareon.xnb");
                                }
                            }
                        }
                        else
                        if (Game1.player.CurrentItem.ParentSheetIndex == 84 || Game1.player.CurrentItem.ParentSheetIndex == 86)
                        {
                            if (curPet.pType == 0)
                            {
                                if (Game1.player.CurrentItem.ParentSheetIndex == 84) //is vaporeon
                                {
                                    AskQuestion("vaporeon.xnb");
                                }
                                else
                                if (Game1.player.CurrentItem.ParentSheetIndex == 86) //is jolteon
                                {
                                    AskQuestion("jolteon.xnb");
                                }
                            }
                        }
                    }
                    else//friendship check
                    {
                        if(pet.friendshipTowardFarmer >5)//if (pet.friendshipTowardFarmer >= 500)
                        {
                            if (curPet.pType == 2)//persian
                            {
                                AskQuestion("Persian.xnb");
                            }
                            if (curPet.pType == 1)
                            {
                                AskQuestion("torrakat.xnb");
                            }
                        }
                        if (pet.friendshipTowardFarmer >= 200)
                        {
                            if (curPet.pType == 4)
                            {
                                AskQuestion("boltund.xnb");
                            }
                            if (curPet.pType == 5)
                            {
                                AskQuestion("houndoom.xnb");
                            }
                            if (Game1.timeOfDay <= 1200 && curPet.pType == 0)
                            {
                                AskQuestion("espeon.xnb");
                            }
                            else
                            if (Game1.timeOfDay > 1200 && curPet.pType == 0)
                            {
                                AskQuestion("umbreon.xnb");
                            }

                            //if (Game1.player.CurrentItem.ParentSheetIndex == 132 && pet.Sprite.Texture.Name == "Animals/cat")//silveon
                            //{
                            //    AskQuestion("silveon.xnb");
                            //
                            //leafeon
                            //glaceon
                        }

                    }
                }
            }
        }
        catch (Exception e)
        {
            Monitor.LogOnce("HarmonyPatch tryToReceiveActiveObject failed " + e.Message);
        }
    }

    private static void AskQuestion(string fileName)
    {
        Farmer who = Game1.player;
        GameLocation location = Game1.currentLocation;
        Response[] responses = { new Response("0", "Evolve " + Game1.player.getPet().Name), new Response("1", "Do not evolve"), new Response("2", "No and don't ask again") };

        who.Halt();
        who.faceGeneralDirection(Game1.player.getStandingPosition(), 0, opposite: false, useTileCalculations: false);
        who.faceTowardFarmerForPeriod(4000, 3, faceAway: false, Game1.player);
        location.createQuestionDialogue(Game1.player.getPet().Name + " gives off a magical glow...", responses, delegate (Farmer _, string answer)
        {
            switch (answer)
            {
                case "0":
                    EvolveStart(who, who.getPet(), fileName);                    
                    break;
                case "1": break;
                case "2": NoForever(); break;
            }
        });
    }

    private static int GetEvolvedType(string fileName)
    {
        switch(fileName)
        {
            case "arcanine.xnb": return 10;
            case "flareon.xnb": return 11;
            case "vaporeon.xnb": return 12;
            case "jolteon.xnb": return 13;
            case "Persian.xnb": return 14;
            case "torrakat.xnb": return 15;
            case "boltund.xnb": return 16;
            case "houndoom.xnb": return 17;
            case "espeon.xnb": return 18;
            case "umbreon.xnb": return 19;
            case "silveon.xnb": return 20;
            case "leafeon.xnb": return 21;
            case "glaceon.xnb": return 22;
        }        

        return -1;
    }
    private static async void EvolveStart(Farmer who, Pet pet, string fileName)
    {
        who.Halt();
        who.faceGeneralDirection(Game1.player.getStandingPosition(), 0, opposite: false, useTileCalculations: false);
        who.faceTowardFarmerForPeriod(4000, 3, faceAway: false, Game1.player);
        curPet = new PetData(Game1.player.UniqueMultiplayerID, pet.Name, true, fileName, pet.friendshipTowardFarmer, GetEvolvedType(fileName), Game1.player.catPerson);

        await EvolveAnimate(who, pet);
        ChangePetSprite(fileName, who, pet);
        EvolveFinished(who, pet, fileName);
        ChangeSpriteAudio();
    }

    private static void ChangeSpriteAudio()
    {
        switch (curPet.pType)
        {
            case 0: InstallPetCry("cat", "eevee.wav"); break;
            case 1: InstallPetCry("cat", "litten.wav"); break;
            case 2: InstallPetCry("cat", "meowth.wav"); break;
            case 3: InstallPetCry("dog_bark", "growlithe.wav"); break;
            case 4: InstallPetCry("dog_bark", "boltund.wav"); break;
            case 5: InstallPetCry("dog_bark", "houndour.wav"); break;

            case 11: InstallPetCry("cat", "flareon.wav"); break;
            case 12: InstallPetCry("cat", "vaporeon.wav"); break;
            case 13: InstallPetCry("cat", "jolteon.wav"); break;
            case 14: InstallPetCry("cat", "persian.wav"); break;
            case 15: InstallPetCry("cat", "torrakat.wav"); break;
            case 18: InstallPetCry("cat", "espeon.wav"); break;
            case 19: InstallPetCry("cat", "umbreon.wav"); break;
            case 20: InstallPetCry("cat", "silveon.wav"); break;
            case 21: InstallPetCry("cat", "leafeon.wav"); break;
            case 22: InstallPetCry("cat", "glaceon.wav"); break;
            case 10: InstallPetCry("dog_bark", "arcanine.wav"); break;
            case 16: InstallPetCry("dog_bark", "boltund.wav"); break;
            case 17: InstallPetCry("dog_bark", "houndoom.wav"); break;
        }
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
        who.reduceActiveItemByOne();
        who.completelyStopAnimatingOrDoingAction();
        pet.faceTowardFarmerForPeriod(4000, 3, faceAway: false, who);
        Game1.screenGlowOnce(Color.White, false, .009f, 0);
    }

    private static bool hasDataBeenUpdated;
    
    

    private static void ChangePetSprite(string fileName, Farmer who, Pet pet)
    {
        string path = Path.Combine(helper.DirectoryPath, "assets/evolves", fileName); 
        string file = new FileInfo(path).FullName;
        pet.Sprite = new AnimatedSprite();
        pet.Sprite.LoadTexture(file);
        Vector2 offset = pet.appliedRouteAnimationOffset;
        pet.Sprite.SourceRect = new Rectangle(0, 224, 32, 32);
        pet.Sprite.SpriteWidth = 32;
        pet.Sprite.SpriteHeight = 32;
        
        return;
    }

    private static void NoForever()
    {
        curPet.hasEvolved = false;
        curPet.stopAsking = true;        
    }

    public void SaveChanges()
    {
        if (curPet != null && !hasSaved)
        {
            for(int i=0;i< allPets.pets.Count;i++)
            {
                if (allPets.pets[i].id==curPet.id)
                {
                    allPets.pets[i] = curPet;
                }
            }

            hasSaved = true;
            helper.Data.WriteJsonFile("petData.json", allPets);
        }
    }
}

public class AllPets
{
    public AllPets() { pets = new List<PetData>(); }
    public List<PetData> pets;
    public bool stopAsking;
}

public class PetData
{
    public PetData(long petID, string petName, bool hasEvolved, string fileName, int friendship, int petType, bool catPerson)
    {
        id = petID;
        pType = petType;
        name = petName;
        this.hasEvolved = hasEvolved;
        this.fileName = fileName;
        this.friendship = friendship;
        this.catPerson = catPerson;
    }
    public long id { get; set; }
    public int pType { get; set; }
    public string name { get; set; }
    public bool hasEvolved { get; set; }
    public string fileName;
    public int friendship { get; set; }
    public bool stopAsking { get; set; }
    public bool catPerson { get; set; }
}