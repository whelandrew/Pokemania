using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewValley;

class ImageReplacers : IAssetEditor
{
    string[] toReplace = new string[] { 
                                        "LooseSprites/GemBird", 
                                        "MiniGames/submarine_tilesheet",
                                        "TileSheets/critters",
                                        "Portraits/Bear",
                                        "LooseSprites/cowPhotos",
                                        "LooseSprites/cowPhotosWinter",
                                        "LooseSprites/SeaMonster",
                                        "Characters/Junimo",
                                        "Characters/Monsters/Armored Bug",
                                        "Characters/Monsters/Bat",
                                        "Characters/Monsters/Big Slime",
                                        "Characters/Monsters/Bug",
                                        "Characters/Monsters/Carbon Ghost",
                                        "Characters/Monsters/Duggy",
                                        "Characters/Monsters/Dust Spirit",
                                        "Characters/Monsters/Fly",
                                        "Characters/Monsters/Frost Bat",
                                        "Characters/Monsters/Ghost",
                                        "Characters/Monsters/Green Slime",
                                        "Characters/Monsters/Grub",
                                        "Characters/Monsters/Iridium Bat",
                                        "Characters/Monsters/Iridium Crab",
                                        "Characters/Monsters/Lava Bat",
                                        "Characters/Monsters/Lava Crab",
                                        "Characters/Monsters/Metal Head",
                                        "Characters/Monsters/Mummy",
                                        "Characters/Monsters/Rock Crab",
                                        "Characters/Monsters/Serpent",
                                        "Characters/Monsters/Shadow Brute",
                                        "Characters/Monsters/Shadow Shaman",
                                        "Characters/Monsters/Skeleton",
                                        "Characters/Monsters/Squid Kid",
                                        "Characters/Monsters/Stone Golem",
                                        "Characters/Monsters/Wilderness Golem",
                                        "Animals/BabyBlue Chicken",
                                        "Animals/BabyBrown Chicken",
                                        "Animals/BabyBrown Cow",
                                        "Animals/BabyGoat",
                                        "Animals/BabyPig",
                                        "Animals/BabyRabbit",
                                        "Animals/BabySheep",
                                        "Animals/BabyVoid Chicken",
                                        "Animals/BabyWhite Chicken",
                                        "Animals/BabyWhite Cow",
                                        "Animals/Blue Chicken",
                                        "Animals/Brown Chicken",
                                        "Animals/Brown Cow",
                                        "Animals/cat", //cat1, cat2
                                        "Animals/cat1",
                                        "Animals/cat2",
                                        "Animals/Dinosaur",
                                        "Animals/dog", //dog1, dog2
                                        "Animals/dog1",
                                        "Animals/dog2",
                                        "Animals/Duck",
                                        "Animals/Goat",
                                        "Animals/horse",
                                        "Animals/Pig",
                                        "Animals/Rabbit",
                                        "Animals/ShearedSheep",
                                        "Animals/Sheep",
                                        "Animals/Void Chicken",
                                        "Animals/White Chicken",
                                        "Animals/White Cow"

    };
    string[] replaceWith = new string[] {   
                                            "NewGemBird.png", 
                                            "submarine_tilesheet.png",
                                            "critters",
                                            "Bear",
                                            "cowPhotos",
                                            "cowPhotosWinter",
                                            "SeaMonster",
                                            "Junimo",
                                            "Armored Bug",
                                            "Bat",
                                            "Big Slime",
                                            "Bug",
                                            "Carbon Ghost",
                                            "Duggy",
                                            "Dust Spirit",
                                            "Fly",
                                            "Frost Bat",
                                            "Ghost",
                                            "Green Slime",
                                            "Grub",
                                            "Iridium Bat",
                                            "Iridium Crab",
                                            "Lava Bat",
                                            "Lava Crab",
                                            "Metal Head",
                                            "Mummy",
                                            "Rock Crab",
                                            "Serpent",
                                            "Shadow Brute",
                                            "Shadow Shaman",
                                            "Skeleton",
                                            "Squid Kid",
                                            "Stone Golem",
                                            "Wilderness Golem",
                                            "BabyBlue Chicken",
                                            "BabyBrown Chicken",
                                            "BabyBrown Cow",
                                            "BabyGoat",
                                            "BabyPig",
                                            "BabyRabbit",
                                            "BabySheep",
                                            "BabyVoid Chicken",
                                            "BabyWhite Chicken",
                                            "BabyWhite Cow",
                                            "Blue Chicken",
                                            "Brown Chicken",
                                            "Brown Cow",
                                            "cat", // cat1, cat2
                                            "cat1",
                                            "cat2",
                                            "Dinosaur",
                                            "dog", //dog1 dog2
                                            "dog1",
                                            "dog2",
                                            "Duck",
                                            "Goat",
                                            "horse",
                                            "Pig",
                                            "Rabbit",
                                            "ShearedSheep",
                                            "Sheep",
                                            "Void Chicken",
                                            "White Chicken",
                                            "White Cow"




    };     
    int currentReplacer = -1;

    private IModHelper modHelper;
    public ImageReplacers(IModHelper helper)
    {
        modHelper = helper;
    }
    public bool CanEdit<T>(IAssetInfo asset)
    {
        return GetReplacer(asset.AssetName); 
    }
    public void Edit<T>(IAssetData asset)
    {
        if (GetReplacer(asset.AssetName))
        {
            Texture2D image = modHelper.Content.Load<Texture2D>("assets/" + replaceWith[currentReplacer] + ".png", ContentSource.ModFolder);
            asset.AsImage().PatchImage(image, image.Bounds, image.Bounds, PatchMode.Replace);
        }            
    }
    private bool GetReplacer(string name)
    {
        for (int i = 0; i < toReplace.Length; i++)
        {
            if (toReplace[i] == name)
            {
                currentReplacer = i;
                return true;
            }
        }
        return false;
    }
}
