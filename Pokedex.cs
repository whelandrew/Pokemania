using Microsoft.Xna.Framework;
using StardewModdingAPI;
using System;
using System.Collections.Generic;

public class ToReplace
{
    public List<Item> Changes { get; set; }
}
public class Item
{
    public Item(string logName, string action, string target, string fromFile, Rectangle fromArea, Vector2 toArea, PatchMode patchMode)
    {
        LogName = logName;
        Action = action;
        Target = target;
        FromFile = fromFile;
        FromArea = fromArea;
        ToArea = toArea;
        PatchMode = patchMode;
    }

    public Item(string logName, string action, string target, string fromFile)
    {
        LogName = logName;
        Action = action;
        Target = target;
        FromFile = fromFile;
    }

    public Item(string logName, string action, string target, string fromFile, Rectangle fromArea, Vector2 toArea, PatchMode patchMode, int animationFrameTime, int animationFrameCount)
    {
        LogName = logName;
        Action = action;
        Target = target;
        FromFile = fromFile;
        FromArea = fromArea;
        ToArea = toArea;
        AnimationFrameCount = animationFrameCount;
        AnimationFrameTime = animationFrameTime;
        PatchMode = patchMode;
    }

    public Item(string action, string target, IDictionary<string, string> entries)
    {
        Action = action;
        Target = target;
        Entries = entries;
    }
    public string LogName { get; set; }
    public string Action { get; set; }
    public string Target { get; set; }
    public string FromFile { get; set; }
    public Rectangle FromArea { get; set; }
    public Vector2 ToArea { get; set; }
    public int AnimationFrameTime { get; set; }
    public int AnimationFrameCount { get; set; }
    public PatchMode PatchMode { get; set; }
    public IDictionary<string, string> Entries { get; set; }
}

public class Pokedex
{
    private ToReplace toReplace = new ToReplace();
    public Pokedex()
    {
        toReplace.Changes = new List<Item>();
    }

    public ToReplace GetAllPokemon()
    {
        //LooseSprites/Cursors
        toReplace.Changes.Add(new Item("Pokedex", "EditImage", "LooseSprites/Cursors", "assets/Pokedex.png", new Rectangle(0, 0, 16, 16), new Vector2(80, 368), PatchMode.Replace));
        toReplace.Changes.Add(new Item("TrainAnimals", "EditImage", "LooseSprites/Cursors", "assets/TrainAnimals.png", new Rectangle(0, 0, 32, 32), new Vector2(231, 576), PatchMode.Replace));
        toReplace.Changes.Add(new Item("TrainGraffiti_01", "EditImage", "LooseSprites/Cursors", "assets/TrainGraffiti_01.png", new Rectangle(0, 0, 32, 32), new Vector2(224, 672), PatchMode.Replace));
        toReplace.Changes.Add(new Item("TrainGraffiti_02", "EditImage", "LooseSprites/Cursors", "assets/TrainGraffiti_02.png", new Rectangle(0, 0, 32, 32), new Vector2(320, 640), PatchMode.Replace));
        toReplace.Changes.Add(new Item("TrainGraffiti_03", "EditImage", "LooseSprites/Cursors", "assets/TrainGraffiti_03.png", new Rectangle(0, 0, 32, 32), new Vector2(416, 640), PatchMode.Replace));
        toReplace.Changes.Add(new Item("TrainGraffiti_04", "EditImage", "LooseSprites/Cursors", "assets/TrainGraffiti_04.png", new Rectangle(0, 0, 32, 32), new Vector2(352, 608), PatchMode.Replace));
        toReplace.Changes.Add(new Item("TrainGraffiti_05", "EditImage", "LooseSprites/Cursors", "assets/TrainGraffiti_05.png", new Rectangle(0, 0, 32, 32), new Vector2(416, 576), PatchMode.Replace));
        toReplace.Changes.Add(new Item("TrainGraffiti_06", "EditImage", "LooseSprites/Cursors", "assets/TrainGraffiti_06.png", new Rectangle(0, 0, 32, 32), new Vector2(320, 704), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Zubat", "EditImage", "LooseSprites/Cursors", "assets/Zubat.png", new Rectangle(0, 0, 64, 16), new Vector2(640, 1664), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Pokeballs", "EditImage", "LooseSprites/Cursors", "assets/Pokeballs.png", new Rectangle(0, 0, 64, 16), new Vector2(368, 32), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Chingling_02", "EditImage", "LooseSprites/Cursors", "assets/Chingling_02.png", new Rectangle(0, 0, 190, 28), new Vector2(0, 165), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Chingling_01", "EditImage", "LooseSprites/Cursors", "assets/Chingling_01.png", new Rectangle(0, 0, 112, 15), new Vector2(48,144), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Tangella", "EditImage", "LooseSprites/Cursors", "assets/Tangella.png", new Rectangle(0, 0, 16, 30), new Vector2(127, 687), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Drifloon", "EditImage", "LooseSprites/Cursors", "assets/Drifloon.png", new Rectangle(0, 0, 64, 18), new Vector2(640, 768), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Drifblim", "EditImage", "LooseSprites/Cursors", "assets/Drifblim.png", new Rectangle(0, 0, 84, 143), new Vector2(0, 1182), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Voltorb", "EditImage", "LooseSprites/Cursors", "assets/Voltorb.png", new Rectangle(0, 0, 63, 48), new Vector2(289, 1182), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Rhyhorn01", "EditImage", "LooseSprites/Cursors", "assets/Rhyhorn01.png", new Rectangle(0, 0, 48, 24), new Vector2(96, 1424), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Mismagus", "EditImage", "LooseSprites/Cursors", "assets/Mismagus.png", new Rectangle(0, 0, 48, 60), new Vector2(276, 1885), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Houndoom", "EditImage", "LooseSprites/Cursors", "assets/Houndoom.png", new Rectangle(0, 0, 72, 40), new Vector2(323, 1916), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Pelipper", "EditImage", "LooseSprites/Cursors", "assets/Pelipper.png", new Rectangle(0, 0, 144, 21), new Vector2(388, 1894), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Lopad", "EditImage", "LooseSprites/Cursors", "assets/Lopad.png", new Rectangle(0, 0, 64, 16), new Vector2(0, 1920), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Castform_Grey", "EditImage", "LooseSprites/Cursors", "assets/Castform_Grey.png", new Rectangle(0, 0, 62, 18), new Vector2(295, 1432), PatchMode.Replace));

        //LooseSprites/Cursors2
        toReplace.Changes.Add(new Item("Remoraid", "EditImage", "LooseSprites/Cursors2", "assets/Remoraid.png", new Rectangle(0, 0, 84, 28), new Vector2(172, 33), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Chatot_03", "EditImage", "LooseSprites/Cursors2", "assets/Chatot_03.png", new Rectangle(0, 0, 42, 28), new Vector2(148, 62), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Trubbish", "EditImage", "LooseSprites/Cursors2", "assets/Trubbish.png", new Rectangle(0, 0, 67, 32), new Vector2(39, 0), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Snorlax", "EditImage", "LooseSprites/Cursors2", "assets/Snorlax.png", new Rectangle(0, 0, 92, 56), new Vector2(0, 80), PatchMode.Replace));

        //Maps/springobjects
        toReplace.Changes.Add(new Item("Exeggute", "EditImage", "Maps/springobjects", "assets/Exeggute.png", new Rectangle(0, 0, 16, 16), new Vector2(256, 48), PatchMode.Replace));
        toReplace.Changes.Add(new Item("TM", "EditImage", "Maps/springobjects", "assets/TM.png", new Rectangle(0, 0, 16, 16), new Vector2(48, 112), PatchMode.Replace));
        toReplace.Changes.Add(new Item("EggLargePurple", "EditImage", "Maps/springobjects", "assets/EggLargePurple.png", new Rectangle(0, 0, 16, 16), new Vector2(96, 112), PatchMode.Replace));
        toReplace.Changes.Add(new Item("EggLargeOrange", "EditImage", "Maps/springobjects", "assets/EggLargeOrange.png", new Rectangle(0, 0, 16, 16), new Vector2(224, 112), PatchMode.Replace));
        toReplace.Changes.Add(new Item("EggRegPurple", "EditImage", "Maps/springobjects", "assets/EggRegPurple.png", new Rectangle(0, 0, 16, 16), new Vector2(128, 112), PatchMode.Replace));
        toReplace.Changes.Add(new Item("EggRegOrange", "EditImage", "Maps/springobjects", "assets/EggRegOrange.png", new Rectangle(0, 0, 16, 16), new Vector2(192, 112), PatchMode.Replace));
        toReplace.Changes.Add(new Item("FireStone", "EditImage", "Maps/springobjects", "assets/fireStone.png", new Rectangle(0, 0, 16, 16), new Vector2(160, 48), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Fish_01", "EditImage", "Maps/springobjects", "assets/Fish_01.png", new Rectangle(0, 0, 79, 16), new Vector2(128, 80), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Fish_02", "EditImage", "Maps/springobjects", "assets/Fish_02.png", new Rectangle(0, 0, 128, 16), new Vector2(256, 80), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Fish_03", "EditImage", "Maps/springobjects", "assets/Fish_03.png", new Rectangle(0, 0, 380, 16), new Vector2(0, 96), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Fish_04", "EditImage", "Maps/springobjects", "assets/Fish_04.png", new Rectangle(0, 0, 46, 16), new Vector2(50, 176), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Fish_05", "EditImage", "Maps/springobjects", "assets/Fish_05.png", new Rectangle(0, 0, 79, 16), new Vector2(32, 464), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Fish_06", "EditImage", "Maps/springobjects", "assets/Fish_06.png", new Rectangle(0, 0, 64, 16), new Vector2(0, 480), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Fish_07", "EditImage", "Maps/springobjects", "assets/Fish_07.png", new Rectangle(0, 0, 96, 16), new Vector2(48, 528), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Fish_08", "EditImage", "Maps/springobjects", "assets/Fish_08.png", new Rectangle(0, 0, 48, 16), new Vector2(320, 544), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Fish_10", "EditImage", "Maps/springobjects", "assets/Fish_10.png", new Rectangle(0, 0, 16, 16), new Vector2(224, 480), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Fish_14", "EditImage", "Maps/springobjects", "assets/Fish_14.png", new Rectangle(0, 0, 79, 16), new Vector2(304, 464), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Potion", "EditImage", "Maps/springobjects", "assets/Potion.png", new Rectangle(0, 0, 16, 16), new Vector2(368, 96), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Food_01", "EditImage", "Maps/springobjects", "assets/Food_01.png", new Rectangle(0, 0, 15, 16), new Vector2(96, 128), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Junk", "EditImage", "Maps/springobjects", "assets/Junk.png", new Rectangle(0, 0, 16, 16), new Vector2(0, 112), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Nanab", "EditImage", "Maps/springobjects", "assets/Nanab.png", new Rectangle(0, 0, 16, 16), new Vector2(304, 48), PatchMode.Replace));
        toReplace.Changes.Add(new Item("NanabTree", "EditImage", "Maps/springobjects", "assets/NanabTree.png", new Rectangle(0, 0, 16, 16), new Vector2(336, 32), PatchMode.Replace));
        //toReplace.Changes.Add(new Item("Exeggutor", "EditImage", "Maps/springobjects", "assets/Exeggutor.png", new Rectangle(0, 0, 16, 16), new Vector2(272, 64), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Torchic", "EditImage", "Maps/springobjects", "assets/Torchic.png", new Rectangle(0, 0, 16, 16), new Vector2(272, 64), PatchMode.Replace));
        toReplace.Changes.Add(new Item("EggHuge", "EditImage", "Maps/springobjects", "assets/Egg.png", new Rectangle(0, 0, 16, 16), new Vector2(176, 64), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Spelon", "EditImage", "Maps/springobjects", "assets/Spelon.png", new Rectangle(0, 0, 16, 16), new Vector2(320, 160), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Morelull", "EditImage", "Maps/springobjects", "assets/Morelull.png", new Rectangle(0, 0, 16, 16), new Vector2(272, 160), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Foongus", "EditImage", "Maps/springobjects", "assets/Foongus.png", new Rectangle(0, 0, 16, 16), new Vector2(320, 256), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Pinap", "EditImage", "Maps/springobjects", "assets/Pinap.png", new Rectangle(0, 0, 16, 16), new Vector2(256, 544), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Oran", "EditImage", "Maps/springobjects", "assets/Oran.png", new Rectangle(0, 0, 16, 16), new Vector2(176, 416), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Apicotberry", "EditImage", "Maps/springobjects", "assets/Apicotberry.png", new Rectangle(0, 0, 16, 16), new Vector2(192, 416), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Lumberry", "EditImage", "Maps/springobjects", "assets/Lumberry.png", new Rectangle(0, 0, 16, 16), new Vector2(352, 256), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Shroomish", "EditImage", "Maps/springobjects", "assets/Shroomish.png", new Rectangle(0, 0, 16, 16), new Vector2(352, 272), PatchMode.Replace));
        toReplace.Changes.Add(new Item("AnorinthCocktail", "EditImage", "Maps/springobjects", "assets/AnorinthCocktail.png", new Rectangle(0, 0, 16, 16), new Vector2(208, 480), PatchMode.Replace));

        //LooseSprites/JunimoNote
        toReplace.Changes.Add(new Item("Lapras", "EditImage", "LooseSprites/JunimoNote", "assets/Lapras.png", new Rectangle(0, 0, 32, 32), new Vector2(255, 180), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Krabby", "EditImage", "LooseSprites/JunimoNote", "assets/Krabby.png", new Rectangle(0, 0, 32, 32), new Vector2(352, 180), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Staryu", "EditImage", "LooseSprites/JunimoNote", "assets/Staryu.png", new Rectangle(0, 0, 32, 32), new Vector2(447, 180), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Hippowdon", "EditImage", "LooseSprites/JunimoNote", "assets/Hippowdon.png", new Rectangle(0, 0, 32, 32), new Vector2(128, 180), PatchMode.Replace));

        //Maps/Festivals
        toReplace.Changes.Add(new Item("Frillish", "EditImage", "Maps/Festivals", "assets/Frillish.png", new Rectangle(0, 0, 96, 32), new Vector2(256, 16), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Spinarak", "EditImage", "Maps/Festivals", "assets/Spinarak.png", new Rectangle(0, 0, 16, 16), new Vector2(256, 288), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Jynx", "EditImage", "Maps/Festivals", "assets/Jynx.png", new Rectangle(0, 0, 16, 48), new Vector2(32, 32), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Fish_10", "EditImage", "Maps/Festivals", "assets/Fish_10.png", new Rectangle(0, 0, 16, 16), new Vector2(111, 431), PatchMode.Replace));
        toReplace.Changes.Add(new Item("FishBox", "EditImage", "Maps/Festivals", "assets/FishBox.png", new Rectangle(0, 0, 48, 48), new Vector2(464, 55), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Castform_02", "EditImage", "Maps/Festivals", "assets/Castform_02.png", new Rectangle(0, 0, 31, 31), new Vector2(303, 160), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Castform_01", "EditImage", "Maps/Festivals", "assets/Castform_01.png", new Rectangle(0, 0, 31, 31), new Vector2(256, 16), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Gengar", "EditImage", "Maps/Festivals", "assets/Gengar.png", new Rectangle(0, 0, 64, 16), new Vector2(320, 336), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Clefairy", "EditImage", "Maps/Festivals", "assets/Clefairy.png", new Rectangle(0, 0, 32, 48), new Vector2(96, 352), PatchMode.Replace));

        //Maps/DesertTiles
        toReplace.Changes.Add(new Item("MeowthMachine", "EditImage", "Maps/DesertTiles", "assets/MeowthMachine.png", new Rectangle(0, 0, 32, 48), new Vector2(191, 287), PatchMode.Replace));

        //Characters/Emily
        toReplace.Changes.Add(new Item("Emily", "EditImage", "Characters/Emily", "assets/Emily.png", new Rectangle(0, 0, 48, 32), new Vector2(0, 224), PatchMode.Replace));

        //TileSheets/SecretNotesImages
        toReplace.Changes.Add(new Item("SecretNotesImages", "EditImage", "TileSheets/SecretNotesImages", "assets/SecretNotesImages.png", new Rectangle(0, 0, 60, 52), new Vector2(129, 65), PatchMode.Replace));

        //Maps/spring_town
        toReplace.Changes.Add(new Item("PokeCenter", "EditImage", "Maps/spring_town", "assets/PokeCenter.png", new Rectangle(0, 0, 80, 48), new Vector2(0, 224), PatchMode.Replace));
        toReplace.Changes.Add(new Item("OttselSeat", "EditImage", "Maps/spring_town", "assets/OttselSeat.png", new Rectangle(0, 0, 32, 32), new Vector2(162, 527), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Solrok_02", "EditImage", "Maps/spring_town", "assets/Solrok_01.png", new Rectangle(0, 0, 18, 18), new Vector2(15, 90), PatchMode.Overlay));
        toReplace.Changes.Add(new Item("Solrok_01", "EditImage", "Maps/spring_town", "assets/Solrok_01.png", new Rectangle(0, 0, 18, 18), new Vector2(15, 90), PatchMode.Overlay));
        toReplace.Changes.Add(new Item("Rowlet", "EditImage", "Maps/spring_town", "assets/Rowlet.png", new Rectangle(0, 0, 13, 18), new Vector2(305, 78), PatchMode.Overlay));
        toReplace.Changes.Add(new Item("TownSquare", "EditImage", "Maps/spring_town", "assets/TownSquare.png", new Rectangle(0, 0, 96, 96), new Vector2(416, 416), PatchMode.Overlay));
        toReplace.Changes.Add(new Item("Noctowl_02", "EditImage", "Maps/spring_town", "assets/Noctowl_02.png", new Rectangle(0, 0, 96, 48), new Vector2(272, 592), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Noctowl_01", "EditImage", "Maps/spring_town", "assets/Noctowl_01.png", new Rectangle(0, 0, 112, 48), new Vector2(208, 512), PatchMode.Replace));

        //Maps/winter_town
        toReplace.Changes.Add(new Item("winterPokemart", "EditImage", "Maps/winter_town", "assets/winterPokemart.png", new Rectangle(0, 0, 92, 111), new Vector2(111, 208), PatchMode.Replace));
        toReplace.Changes.Add(new Item("PokeCenter", "EditImage", "Maps/winter_town", "assets/PokeCenter.png", new Rectangle(0, 0, 80, 48), new Vector2(0, 224), PatchMode.Replace));
        toReplace.Changes.Add(new Item("OttselSeatWinter", "EditImage", "Maps/winter_town", "assets/OttselSeatWinter.png", new Rectangle(0, 0, 32, 32), new Vector2(160, 529), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Solrok_01", "EditImage", "Maps/winter_town", "assets/Solrok_01.png", new Rectangle(0, 0, 18, 16), new Vector2(15, 90), PatchMode.Overlay));
        toReplace.Changes.Add(new Item("SolrokWinter", "EditImage", "Maps/winter_town", "assets/SolrokWinter.png", new Rectangle(0, 0, 18, 16), new Vector2(198, 560), PatchMode.Replace));
        toReplace.Changes.Add(new Item("RowletWinter", "EditImage", "Maps/winter_town", "assets/Rowlet.png", new Rectangle(0, 0, 13, 18), new Vector2(305, 78), PatchMode.Overlay));
        toReplace.Changes.Add(new Item("TownSquareWinter", "EditImage", "Maps/winter_town", "assets/TownSquare.png", new Rectangle(0, 0, 96, 96), new Vector2(416, 416), PatchMode.Overlay));
        toReplace.Changes.Add(new Item("NoctowlWinter_02", "EditImage", "Maps/winter_town", "assets/NoctowlWinter_02.png", new Rectangle(0, 0, 96, 32), new Vector2(272, 592), PatchMode.Replace));
        toReplace.Changes.Add(new Item("NoctowlWinter_01", "EditImage", "Maps/winter_town", "assets/NoctowlWinter_01.png", new Rectangle(0, 0, 128, 48), new Vector2(208, 512), PatchMode.Replace));

        //Maps/summer_town
        toReplace.Changes.Add(new Item("TownSquareSummer", "EditImage", "Maps/summer_town", "assets/TownSquare.png", new Rectangle(0, 0, 96, 96), new Vector2(416, 416), PatchMode.Overlay));
        toReplace.Changes.Add(new Item("summerPokemart", "EditImage", "Maps/summer_town", "assets/summerPokemart.png", new Rectangle(0, 0, 92, 112), new Vector2(111, 208), PatchMode.Replace));
        toReplace.Changes.Add(new Item("summerTownCenterpiece_02", "EditImage", "Maps/summer_town", "assets/summerTownCenterpiece_02.png", new Rectangle(0, 0, 38, 16), new Vector2(369, 432), PatchMode.Replace));
        toReplace.Changes.Add(new Item("PokeCenter", "EditImage", "Maps/summer_town", "assets/PokeCenter.png", new Rectangle(0, 0, 80, 48), new Vector2(0, 224), PatchMode.Replace));
        toReplace.Changes.Add(new Item("OttselSeat", "EditImage", "Maps/summer_town", "assets/OttselSeat.png", new Rectangle(0, 0, 29, 32), new Vector2(162, 527), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Solrok_02", "EditImage", "Maps/summer_town", "assets/Solrok_01.png", new Rectangle(0, 0, 18, 18), new Vector2(14, 90), PatchMode.Overlay));
        toReplace.Changes.Add(new Item("Solrok_01", "EditImage", "Maps/summer_town", "assets/Solrok_01.png", new Rectangle(0, 0, 18, 18), new Vector2(197, 560), PatchMode.Overlay));
        toReplace.Changes.Add(new Item("Rowlet_Summer", "EditImage", "Maps/summer_town", "assets/Rowlet.png", new Rectangle(0, 0, 13, 18), new Vector2(305, 78), PatchMode.Overlay));
        toReplace.Changes.Add(new Item("Noctowl_02", "EditImage", "Maps/summer_town", "assets/Noctowl_02.png", new Rectangle(0, 0, 92, 48), new Vector2(272, 592), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Noctowl_01", "EditImage", "Maps/summer_town", "assets/Noctowl_01.png", new Rectangle(0, 0, 112, 48), new Vector2(208, 512), PatchMode.Replace));

        //Minigames/TitleButtons
        toReplace.Changes.Add(new Item("Unown", "EditImage", "Minigames/TitleButtons", "assets/Unown.png", new Rectangle(0, 0, 296, 116), new Vector2(0, 187), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Unown_02", "EditImage", "Minigames/TitleButtons", "assets/Unown_02.png", new Rectangle(0, 0, 44, 25), new Vector2(8, 458), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Togekiss", "EditImage", "Minigames/TitleButtons", "assets/Togekiss.png", new Rectangle(0, 0, 104, 21), new Vector2(296, 227), PatchMode.Replace));
        toReplace.Changes.Add(new Item("MewTwo", "EditImage", "Minigames/TitleButtons", "assets/MewTwo.png", new Rectangle(0, 0, 167, 67), new Vector2(177, 376), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Castform_Title", "EditImage", "Minigames/TitleButtons", "assets/Castform_Title.png", new Rectangle(0, 0, 264, 16), new Vector2(136, 464), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Clefable", "EditImage", "Minigames/TitleButtons", "assets/Clefable.png", new Rectangle(0, 0, 378, 68), new Vector2(0, 492), PatchMode.Replace));


        //Maps/fall_town
        toReplace.Changes.Add(new Item("fallPokemart", "EditImage", "Maps/fall_town", "assets/fallPokemart.png", new Rectangle(0, 0, 86, 112), new Vector2(111, 208), PatchMode.Replace));
        toReplace.Changes.Add(new Item("PokeCenter", "EditImage", "Maps/fall_town", "assets/PokeCenter.png", new Rectangle(0, 0, 80, 48), new Vector2(0, 224), PatchMode.Replace));
        toReplace.Changes.Add(new Item("OttselSeat", "EditImage", "Maps/fall_town", "assets/OttselSeat.png", new Rectangle(0, 0, 32, 32), new Vector2(162, 527), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Solrok_01", "EditImage", "Maps/summer_town", "assets/Solrok_01.png", new Rectangle(0, 0, 18, 18), new Vector2(197, 560), PatchMode.Overlay));
        toReplace.Changes.Add(new Item("Solrok_02", "EditImage", "Maps/fall_town", "assets/Solrok_01.png", new Rectangle(0, 0, 18, 18), new Vector2(14, 90), PatchMode.Overlay));
        toReplace.Changes.Add(new Item("Rowlet", "EditImage", "Maps/fall_town", "assets/Rowlet.png", new Rectangle(0, 0, 13, 18), new Vector2(305, 78), PatchMode.Overlay));
        toReplace.Changes.Add(new Item("fallTownSquare", "EditImage", "Maps/fall_town", "assets/TownSquare.png", new Rectangle(0, 0, 96, 96), new Vector2(416, 416), PatchMode.Overlay));
        toReplace.Changes.Add(new Item("Noctowl_03", "EditImage", "Maps/fall_town", "assets/Noctowl_03.png", new Rectangle(0, 0, 96, 48), new Vector2(208, 512), PatchMode.Replace));

        //Maps/fall_outdoorsTileSheet
        toReplace.Changes.Add(new Item("MrMime_01", "EditImage", "Maps/fall_outdoorsTileSheet", "assets/MrMime_01.png", new Rectangle(0, 0, 32, 48), new Vector2(240, 688), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Lopad", "EditImage", "Maps/fall_outdoorsTileSheet", "assets/Lopad.png", new Rectangle(0, 0, 64, 16), new Vector2(288, 816), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Abra", "EditImage", "Maps/fall_outdoorsTileSheet", "assets/Abra.png", new Rectangle(0, 0, 16, 32), new Vector2(336, 512), PatchMode.Replace));

        //Maps/summer_outdoorsTileSheet
        toReplace.Changes.Add(new Item("Abra", "EditImage", "Maps/summer_outdoorsTileSheet", "assets/Abra.png", new Rectangle(0, 0, 16, 32), new Vector2(336, 512), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Lopad", "EditImage", "Maps/summer_outdoorsTileSheet", "assets/Lopad.png", new Rectangle(0, 0, 64, 16), new Vector2(288, 816), PatchMode.Replace));
        toReplace.Changes.Add(new Item("MrMime_01", "EditImage", "Maps/summer_outdoorsTileSheet", "assets/MrMime_01.png", new Rectangle(0, 0, 32, 16), new Vector2(272, 704), PatchMode.Replace));

        //Maps/spring_outdoorsTileSheet
        toReplace.Changes.Add(new Item("Abra", "EditImage", "Maps/spring_outdoorsTileSheet", "assets/Abra.png", new Rectangle(0, 0, 16, 32), new Vector2(336, 512), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Lopad", "EditImage", "Maps/spring_outdoorsTileSheet", "assets/Lopad.png", new Rectangle(0, 0, 64, 16), new Vector2(288, 816), PatchMode.Replace));
        toReplace.Changes.Add(new Item("MrMime_01", "EditImage", "Maps/spring_outdoorsTileSheet", "assets/MrMime_01.png", new Rectangle(0, 0, 32, 16), new Vector2(272, 704), PatchMode.Replace));

        //Maps/fall_outdoorsTileSheet
        toReplace.Changes.Add(new Item("Abra", "EditImage", "Maps/fall_outdoorsTileSheet", "assets/Abra.png", new Rectangle(0, 0, 16, 32), new Vector2(336, 512), PatchMode.Replace));
        toReplace.Changes.Add(new Item("MrMime_01", "EditImage", "Maps/fall_outdoorsTileSheet", "assets/MrMime_01.png", new Rectangle(0, 0, 32, 48), new Vector2(240, 688), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Lopad", "EditImage", "Maps/fall_outdoorsTileSheet", "assets/Lopad.png", new Rectangle(0, 0, 64, 16), new Vector2(288, 816), PatchMode.Replace));

        //Maps/winter_outdoorsTileSheet
        toReplace.Changes.Add(new Item("Abra", "EditImage", "Maps/winter_outdoorsTileSheet", "assets/Abra.png", new Rectangle(0, 0, 16, 32), new Vector2(336, 512), PatchMode.Replace));
        toReplace.Changes.Add(new Item("MrMime_01", "EditImage", "Maps/winter_outdoorsTileSheet", "assets/MrMime_01.png", new Rectangle(0, 0, 32, 48), new Vector2(240, 688), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Lopad", "EditImage", "Maps/winter_outdoorsTileSheet", "assets/Lopad.png", new Rectangle(0, 0, 64, 16), new Vector2(288, 816), PatchMode.Replace));

        //Maps/night_market_tilesheet_objects
        toReplace.Changes.Add(new Item("VileBloom", "EditImage", "Maps/night_market_tilesheet_objects", "assets/VileBloom.png", new Rectangle(0, 0, 27, 15), new Vector2(337, 106), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Manaphy", "EditImage", "Maps/night_market_tilesheet_objects", "assets/Manaphy.png", new Rectangle(0, 0, 27, 27), new Vector2(975, 90), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Rhyhorn02", "EditImage", "Maps/night_market_tilesheet_objects", "assets/Rhyhorn02.png", new Rectangle(0, 0, 29, 27), new Vector2(707, 64), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Rhyhorn03", "EditImage", "Maps/night_market_tilesheet_objects", "assets/Rhyhorn02.png", new Rectangle(0, 0, 29, 27), new Vector2(546, 63), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Rotom", "EditImage", "Maps/night_market_tilesheet_objects", "assets/Rotom.png", new Rectangle(0, 0, 96, 32), new Vector2(976, 175), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Lanturn_02", "EditImage", "Maps/night_market_tilesheet_objects", "assets/Lanturn_02.png", new Rectangle(0, 0, 32, 32), new Vector2(111, 271), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Lanturn_01", "EditImage", "Maps/night_market_tilesheet_objects", "assets/Lanturn_01.png", new Rectangle(0, 0, 32, 32), new Vector2(47, 127), PatchMode.Replace));

        //Maps/townInterior
        toReplace.Changes.Add(new Item("Smeargle", "EditImage", "Maps/townInterior", "assets/Smeargle.png", new Rectangle(0, 0, 16, 32), new Vector2(352, 560), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Ursaring", "EditImage", "Maps/townInterior", "assets/Ursaring.png", new Rectangle(0, 0, 32, 64), new Vector2(0, 688), PatchMode.Replace));
        toReplace.Changes.Add(new Item("ShinyP", "EditImage", "Maps/townInterior", "assets/ShinyP.png", new Rectangle(0, 0, 16, 14), new Vector2(128, 624), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Pangoro", "EditImage", "Maps/townInterior", "assets/Pangoro.png", new Rectangle(0, 0, 32, 32), new Vector2(0, 640), PatchMode.Replace));
        //toReplace.Changes.Add(new Item("Pancham", "EditImage", "Maps/townInterior", "assets/Pancham.png", new Rectangle(0, 0, 16, 16), new Vector2(0, 272), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Tangella", "EditImage", "Maps/townInterior", "assets/Tangella.png", new Rectangle(0, 0, 16, 30), new Vector2(351, 528), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Machoke", "EditImage", "Maps/townInterior", "assets/Machoke.png", new Rectangle(0, 0, 16, 16), new Vector2(287, 160), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Marowak", "EditImage", "Maps/townInterior", "assets/Marowak.png", new Rectangle(0, 0, 64, 32), new Vector2(319, 384), PatchMode.Replace));

        //Maps/SewerTiles
        toReplace.Changes.Add(new Item("Spinda", "EditImage", "Maps/SewerTiles", "assets/Spinda.png", new Rectangle(0, 0, 30, 32), new Vector2(96, 144), PatchMode.Replace));

        //Maps/HarveyBalloonTiles
        toReplace.Changes.Add(new Item("HarveyBalloon", "EditImage", "Maps/HarveyBalloon", "assets/HarveyBalloon.png", new Rectangle(0, 0, 93, 106), new Vector2(0, 0), PatchMode.Replace));

        //MiniGames/Intro
        toReplace.Changes.Add(new Item("Pidgey", "EditImage", "MiniGames/Intro", "assets/Pidgey.png", new Rectangle(0, 0, 95, 16), new Vector2(16, 64), PatchMode.Replace));

        //TileSheets/Craftables
        toReplace.Changes.Add(new Item("MissingNo", "EditImage", "TileSheets/Craftables", "assets/MissingNo.png", new Rectangle(0, 0, 16, 32), new Vector2(16, 640), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Noctowl", "EditImage", "TileSheets/Craftables", "assets/Noctowl.png", new Rectangle(0, 0, 16, 32), new Vector2(112, 352), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Regice", "EditImage", "TileSheets/Craftables", "assets/Regice.png", new Rectangle(0, 0, 16, 32), new Vector2(96, 352), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Elgyem", "EditImage", "TileSheets/Craftables", "assets/Elgyem.png", new Rectangle(0, 0, 16, 32), new Vector2(96, 480), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Statues", "EditImage", "TileSheets/Craftables", "assets/Statues.png", new Rectangle(0, 0, 64, 32), new Vector2(64, 192), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Buneary", "EditImage", "TileSheets/Craftables", "assets/Buneary.png", new Rectangle(0, 0, 16, 32), new Vector2(48, 448), PatchMode.Replace));
        toReplace.Changes.Add(new Item("GoldMeowth", "EditImage", "TileSheets/Craftables", "assets/GoldMeowth.png", new Rectangle(0, 0, 16, 29), new Vector2(112, 480), PatchMode.Replace));
        toReplace.Changes.Add(new Item("IridiumMeowth", "EditImage", "TileSheets/Craftables", "assets/IridiumMeowth.png", new Rectangle(0, 0, 16, 32), new Vector2(0, 640), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Sentrent", "EditImage", "TileSheets/Craftables", "assets/Sentrent.png", new Rectangle(0, 0, 16, 32), new Vector2(48, 544), PatchMode.Replace));
        toReplace.Changes.Add(new Item("StatueNatu", "EditImage", "TileSheets/Craftables", "assets/StatueNatu.png", new Rectangle(0, 0, 15, 29), new Vector2(112, 96), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Loudred", "EditImage", "TileSheets/Craftables", "assets/Loudred.png", new Rectangle(0, 0, 16, 32), new Vector2(32, 640), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Mimikyu", "EditImage", "TileSheets/Craftables", "assets/Mimikyu.png", new Rectangle(0, 0, 16, 32), new Vector2(112, 640), PatchMode.Replace));

        //TileSheets/furniture
        toReplace.Changes.Add(new Item("Combusken", "EditImage", "TileSheets/furniture", "assets/Combusken.png", new Rectangle(0, 0, 16, 32), new Vector2(400, 640), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Eggxecutor", "EditImage", "TileSheets/furniture", "assets/Eggxecutor.png", new Rectangle(0, 0, 16, 48), new Vector2(24, 641), PatchMode.Replace));
        toReplace.Changes.Add(new Item("PanchamFurniture", "EditImage", "TileSheets/furniture", "assets/PanchamFurniture.png", new Rectangle(0, 0, 16, 16), new Vector2(336, 672), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Paintings", "EditImage", "TileSheets/furniture", "assets/Paintings.png", new Rectangle(0, 0, 415, 31), new Vector2(48, 769), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Paintings02", "EditImage", "TileSheets/furniture", "assets/Paintings02.png", new Rectangle(0, 0, 64, 18), new Vector2(416, 918), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Porygon", "EditImage", "TileSheets/furniture", "assets/Porygon.png", new Rectangle(0, 0, 32, 29), new Vector2(111, 800), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Pangoro", "EditImage", "TileSheets/furniture", "assets/Pangoro.png", new Rectangle(0, 0, 32, 32), new Vector2(80, 831), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Ursaring", "EditImage", "TileSheets/furniture", "assets/Ursaring.png", new Rectangle(0, 0, 32, 64), new Vector2(111, 831), PatchMode.Replace));
        toReplace.Changes.Add(new Item("CastformFurniture", "EditImage", "TileSheets/furniture", "assets/Castform.png", new Rectangle(0, 0, 32, 32), new Vector2(80, 864), PatchMode.Replace));
        toReplace.Changes.Add(new Item("TangellaFurniture", "EditImage", "TileSheets/furniture", "assets/Tangella.png", new Rectangle(0, 0, 16, 30), new Vector2(416, 640), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Sunflora02", "EditImage", "TileSheets/furniture", "assets/Sunflora02.png", new Rectangle(0, 0, 32, 46), new Vector2(336, 976), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Buneary01", "EditImage", "TileSheets/furniture", "assets/Buneary01.png", new Rectangle(0, 0, 16, 16), new Vector2(64, 880), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Politoed", "EditImage", "TileSheets/furniture", "assets/Politoed.png", new Rectangle(0, 0, 32, 32), new Vector2(448, 1152), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Pachirisu", "EditImage", "TileSheets/furniture", "assets/Pachirisu.png", new Rectangle(0, 0, 16, 16), new Vector2(480, 1392), PatchMode.Replace));
        toReplace.Changes.Add(new Item("Pumpkaboo_03", "EditImage", "TileSheets/furniture", "assets/Pumpkaboo_03.png", new Rectangle(0, 0, 16, 32), new Vector2(464, 944), PatchMode.Replace));
        toReplace.Changes.Add(new Item("CastformPlushes", "EditImage", "TileSheets/furniture", "assets/CastformPlushes.png", new Rectangle(0, 0, 64, 16), new Vector2(0, 880), PatchMode.Replace));

        //Characters/Shane
        toReplace.Changes.Add(new Item("ShaneChicken", "EditImage", "Characters/Shane", "assets/ShaneChicken.png", new Rectangle(0, 0, 32, 32), new Vector2(0, 224), PatchMode.Overlay));

        //Load
        toReplace.Changes.Add(new Item("LooseSprites/GemBird", "Load", "LooseSprites/GemBird", "assets/GemBird.png"));
        toReplace.Changes.Add(new Item("LooseSprites/cowPhotosWinter", "Load", "LooseSprites/cowPhotosWinter", "assets/cowPhotosWinter.png"));
        toReplace.Changes.Add(new Item("LooseSprites/SeaMonster", "Load", "LooseSprites/SeaMonster", "assets/SeaMonster.png"));
        toReplace.Changes.Add(new Item("LooseSprites/submarine_tilesheet", "Load", "Maps/submarine_tilesheet", "assets/submarine_tilesheet.png"));
        toReplace.Changes.Add(new Item("LooseSprites/AquariumFish", "Load", "LooseSprites/AquariumFish", "assets/AquariumFish.png"));
        toReplace.Changes.Add(new Item("LooseSprites/cowPhotos", "Load", "LooseSprites/cowPhotos", "assets/cowPhotos.png"));
        toReplace.Changes.Add(new Item("LooseSprites/Bear", "Load", "LooseSprites/Bear", "assets/Bear.png"));

        toReplace.Changes.Add(new Item("TileSheets/critters", "Load", "TileSheets/critters", "assets/critters.png"));

        toReplace.Changes.Add(new Item("Portrait/Bear", "Load", "Portrait/Bear", "assets/Bear.png"));

        toReplace.Changes.Add(new Item("Characters/Monsters/Armored Bug", "Load", "Characters/Monsters/Armored Bug", "assets/Armored Bug.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Bat", "Load", "Characters/Monsters/Bat", "assets/Bat.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Carbon Ghost", "Load", "Characters/Monsters/Carbon Ghost", "assets/Carbon Ghost.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Duggy", "Load", "Characters/Monsters/Duggy", "assets/Duggy.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Dust Spirit", "Load", "Characters/Monsters/Dust Spirit", "assets/Dust Spirit.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Fly", "Load", "Characters/Monsters/Fly", "assets/Fly.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Frost Bat", "Load", "Characters/Monsters/Frost Bat", "assets/Frost Bat.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Ghost", "Load", "Characters/Monsters/Ghost", "assets/Ghost.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Green Slime", "Load", "Characters/Monsters/Green Slime", "assets/Green Slime.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Grub", "Load", "Characters/Monsters/Grub", "assets/Grub.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Iridium Bat", "Load", "Characters/Monsters/Iridium Bat", "assets/Iridium Bat.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Iridium Crab", "Load", "Characters/Monsters/Iridium Crab", "assets/Iridium Crab.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Lava Bat", "Load", "Characters/Monsters/Lava Bat", "assets/Lava Bat.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Lava Crab", "Load", "Characters/Monsters/Lava Crab", "assets/Lava Crab.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Metal Head", "Load", "Characters/Monsters/Metal Head", "assets/Metal Head.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Mummy", "Load", "Characters/Monsters/Mummy", "assets/Mummy.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Rock Crab", "Load", "Characters/Monsters/Rock Crab", "assets/Rock Crab.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Serpent", "Load", "Characters/Monsters/Serpent", "assets/Serpent.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Shadow Brute", "Load", "Characters/Monsters/Shadow Brute", "assets/Shadow Brute.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Shadow Shaman", "Load", "Characters/Monsters/Shadow Shaman", "assets/Shadow Shaman.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Skeleton", "Load", "Characters/Monsters/Skeleton", "assets/Skeleton.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Squid Kid", "Load", "Characters/Monsters/Squid Kid", "assets/Squid Kid.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Stone Golem", "Load", "Characters/Monsters/Stone Golem", "assets/Stone Golem.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Wilderness Golem", "Load", "Characters/Monsters/Wilderness Golem", "assets/Wilderness Golem.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Haunted Skull", "Load", "Characters/Monsters/Haunted Skull", "assets/Yamask.png"));
        toReplace.Changes.Add(new Item("Characters/Monsters/Big Slime", "Load", "Characters/Monsters/Big Slime", "assets/Big Slime.png"));


        toReplace.Changes.Add(new Item("Animals/BabyBlue Chicken", "Load", "Animals/BabyBlue Chicken", "assets/SkeBabyBlue Chickenleton.png"));
        toReplace.Changes.Add(new Item("Animals/BabyBrown Chicken", "Load", "Animals/BabyBrown Chicken", "assets/BabyBrown Chicken.png"));
        toReplace.Changes.Add(new Item("Animals/BabyBrown Cow", "Load", "Animals/BabyBrown Cow", "assets/BabyBrown Cow.png"));
        //toReplace.Changes.Add(new Item("Animals/BabyPig", "Load", "Animals/BabyPig", "assets/BabyPig.png"));
        toReplace.Changes.Add(new Item("Animals/BabySheep", "Load", "Animals/BabySheep", "assets/BabySheep.png"));
        toReplace.Changes.Add(new Item("Animals/BabyVoid Chicken", "Load", "Animals/BabyVoid Chicken", "assets/BabyVoid Chicken.png"));
        toReplace.Changes.Add(new Item("Animals/BabyWhite Chicken", "Load", "Animals/BabyWhite Chicken", "assets/BabyWhite Chicken.png"));
        toReplace.Changes.Add(new Item("Animals/Blue Chicken", "Load", "Animals/Blue Chicken", "assets/Blue Chicken.png"));
        toReplace.Changes.Add(new Item("Animals/BabyWhite Cow", "Load", "Animals/BabyWhite Cow", "assets/BabyWhite Cow.png"));
        toReplace.Changes.Add(new Item("Animals/Brown Chicken", "Load", "Animals/Brown Chicken", "assets/Brown Chicken.png"));
        toReplace.Changes.Add(new Item("Animals/Brown Cow", "Load", "Animals/Brown Cow", "assets/Brown Cow.png"));
        toReplace.Changes.Add(new Item("Animals/cat", "Load", "Animals/cat", "assets/cat.png"));
        toReplace.Changes.Add(new Item("Animals/cat2", "Load", "Animals/cat2", "assets/cat2.png"));
        toReplace.Changes.Add(new Item("Animals/cat1", "Load", "Animals/cat1", "assets/cat1.png"));
        toReplace.Changes.Add(new Item("Animals/Dinosaur", "Load", "Animals/Dinosaur", "assets/Dinosaur.png"));
        toReplace.Changes.Add(new Item("Animals/dog", "Load", "Animals/dog", "assets/Growlithe.png"));
        toReplace.Changes.Add(new Item("Animals/dog1", "Load", "Animals/dog1", "assets/Elektike.png"));
        toReplace.Changes.Add(new Item("Animals/dog2", "Load", "Animals/dog2", "assets/Poochyenaa.png"));
        toReplace.Changes.Add(new Item("Animals/Duck", "Load", "Animals/Duck", "assets/Duck.png"));
        toReplace.Changes.Add(new Item("Animals/Goat", "Load", "Animals/Goat", "assets/Goat.png"));
        toReplace.Changes.Add(new Item("Animals/BabyGoat", "Load", "Animals/BabyGoat", "assets/BabyGoat.png"));
        toReplace.Changes.Add(new Item("Animals/horse", "Load", "Animals/horse", "assets/horse.png"));
        toReplace.Changes.Add(new Item("Animals/Pig", "Load", "Animals/Pig", "assets/Pig.png"));
        toReplace.Changes.Add(new Item("Animals/Rabbit", "Load", "Animals/Rabbit", "assets/Rabbit.png"));
        toReplace.Changes.Add(new Item("Animals/ShearedSheep", "Load", "Animals/ShearedSheep", "assets/ShearedSheep.png"));
        toReplace.Changes.Add(new Item("Animals/Sheep", "Load", "Animals/Sheep", "assets/Sheep.png"));
        toReplace.Changes.Add(new Item("Animals/Void Chicken", "Load", "Animals/Void Chicken", "assets/Void Chicken.png"));
        toReplace.Changes.Add(new Item("Animals/White Chicken", "Load", "Animals/White Chicken", "assets/White Chicken.png"));
        toReplace.Changes.Add(new Item("Animals/White Cow", "Load", "Animals/White Cow", "assets/White Cow.png"));
        toReplace.Changes.Add(new Item("Animals/BabyRabbit", "Load", "Animals/BabyRabbit", "assets/Scorbunny.png"));

        //EditData
        IDictionary<string, string> entries = new Dictionary<string, string>();

        //Data/FarmAnimals
        entries.Add("White Chicken", "1/3/176/174/cluck/8/32/48/32/8/32/48/32/0/false/Coop/16/16/16/16/4/7/null/641/800/Prinplup/Coop");
        entries.Add("Brown Chicken", "1/3/180/182/cluck/8/32/48/32/8/32/48/32/0/false/Coop/16/16/16/16/7/4/null/641/800/Xatu/Coop");
        entries.Add("Blue Chicken", "1/3/176/174/cluck/8/32/48/32/8/32/48/32/0/false/Coop/16/16/16/16/7/4/null/641/800/Combusken/Coop");
        entries.Add("Void Chicken", "1/3/305/305/cluck/8/32/48/32/8/32/48/32/0/false/Coop/16/16/16/16/4/4/null/641/800/Banette/Coop");
        entries.Add("Duck", "2/5/442/444/Psyduck/8/32/48/32/8/32/48/32/0/false/Coop/16/16/16/16/3/8/null/642/1200/Psyduck/Coop");
        entries.Add("Rabbit", "4/6/440/446/Nidoran/8/32/48/32/8/32/48/32/0/false/Coop/16/16/16/16/10/5/null/643/8000/Shaymin/Coop");
        entries.Add("Dinosaur", "7/0/107/100/none/8/32/48/32/8/32/48/32/0/false/Coop/16/16/16/16/1/8/null/644/1000/Bagon/Coop");
        entries.Add("White Cow", "1/5/184/186/cow/36/64/64/64/36/64/64/64/1/false/Barn/32/32/32/32/15/5/Milk Pail/639/1500/Hippowdon/Barn");
        entries.Add("Brown Cow", "1/5/184/186/cow/36/64/64/64/36/64/64/64/1/false/Barn/32/32/32/32/15/5/Milk Pail/639/1500/Piloswine/Barn");
        entries.Add("Goat", "2/5/436/438/Gogoat/24/64/84/64/24/64/84/64/1/false/Barn/32/32/32/32/10/5/Milk Pail/644/4000/Gogoat/Barn");
        entries.Add("Pig", "1/10/430/100/Grumpig/24/64/84/64/24/64/84/64/1/false/Barn/32/32/32/32/20/5/null/640/16000/Pig/Barn");
        entries.Add("Sheep", "3/4/440/100/Mareep/24/64/84/64/24/64/84/64/1/true/Barn/32/32/32/32/15/5/Shears/644/8000/Flanfy/Barn");
        toReplace.Changes.Add(new Item("EditData", "Data/FarmAnimals", entries));

        //Data/TV/CookingChannel
        entries = new Dictionary<string, string>();
        entries.Add("10", "Phione Soup/Phione Soup! There's something about fresh-caught Phione that just gets me buzzing. Maybe it's the subtle taste of the river. At any rate, I've got a wonderful Phione soup recipe to share with you today...");
        entries.Add("21", "Magikarp Surprise/Hey, ever have a bunch of Magikarp laying around and no idea what to do with them? Yeah, me too. Well, I've devised a great solution to this all-too-common problem. I call it... Magikarp surprise. It's quite easy to make, but you'll need a lot of Magikarp...");
        entries.Add("24", "Roasted Chestis/Roasted Chestis! I've got a nice old hazelnut tree behind my house, and every year I invite the family over for a nut roasting party! Once we start roasting, it's inevitable that the neighbors will show up. That rich, nutty smell is irresistable. Now, here's the family recipe...");
        entries.Add("27", "Krabby Cakes/Krabby Cakes! Krabby meat is very flimsy on its own, but mixing it with bread crumbs and egg is a great way to give them some body. That's why these cakes are my favorite way to eat crab! But before you go cracking any shells, stay tuned for my essential seasoning mixture...");
        entries.Add("30", "Corphis Bisque / Corphis Bisque!You could serve this one to the governor himself. It's rich, creamy and delicious, with just the right amount of oceanic flavor. The hardest part is finding some lobster, but I'm sure you can do it.Heck, if you're feeling crafty you could catch one yourself with a Corphis pot!");

        toReplace.Changes.Add(new Item("EditData", "Data/TV/CookingChannel", entries));

        //Data/Mail
        entries = new Dictionary<string, string>();
        entries.Add("fall_6_2", "Wanted: 1 Fresh Corphish for a marvelous bisque I'm creating.^Who: Gus, proprieter of the Stardrop Saloon^Reward: 800g %item quest 121 %%");
        entries.Add("spring_6_2", "@-^I'm really craving a fresh Apicot. I haven't been able to find one at the store, so I'm asking you. I'll pay you well for it!^   -Emily%item quest 115 %%");
        entries.Add("fall_3_1", "Dear @,^I'd like to give my Piloswines a special treat. They're such good girls and hungry, too. Could you bring me one bunch of amaranth? They love the stuff. ^Thanks, Dear.^   -Marnie %item quest 106 %%");
        entries.Add("fall_8_1", "Hello,^It's Belue season right now. The bushes are full of them. I want to pick some, but I lost my basket. Can you help?^   -Linus%item quest 107 %%");
        entries.Add("fall_26", "Dear @,^Notice a chill in the air? It could just be the approach of winter...^Or it could be the tingle of a dark specter, here to help us celebrate tomorrow's festival... the Gourgeist Festival.^Come to town at 10 PM if you'd like to participate.^  -Mayor Lewis");
        entries.Add("spring_23", "Dear @,^Tomorrow we're all getting together for the Feather Carnival.^^If you can find a partner, you might even want to participate in the dance yourself!^There's a little clearing beyond the forest west of town where we hold the dance. Arrive between 9 AM and 2 PM if you're interested.^  -Mayor Lewis");
        entries.Add("winter_2_1", "Wanted: 1 Fresh Corphish for a marvelous bisque I'm creating.^Who: Gus, proprieter of the Stardrop Saloon^Reward: 800g %item quest 121 %%");
        entries.Add("guildQuest", "Wanted: 1 Fresh Corphish for a marvelous bisque I'm creating.^Who: Gus, proprieter of the Stardrop Saloon^Reward: 800g %item quest 121 %%");
        entries.Add("winter_13_2", "I've got another challenge for you: Catch me a Shiny Remoraid.^They don't go down easy, but I know you can do it.^  -Willy%item quest 124 %%");
        entries.Add("summer_28", "Dear @,^Tonight at around 10 o'clock PM, a rare and beautiful event will take place.^^The Frillish will be passing by Pelican Town on their long journey south for the winter.^^We're all gathering at the beach to watch. You don't want to miss this!^See you tonight,^ -Demetrius");
        entries.Add("summer_6_2", "Fisherman Wanted^I need a good Quilfish specimen. I'm conducting an experiment on the toxin created by the Quilfish.^Reward: 1000g^ -Demetrius%item quest 118 %%");

        toReplace.Changes.Add(new Item("EditData", "Data/Mail", entries));

        //Data/BigCraftablesInformation
        entries = new Dictionary<string, string>();
        entries.Add("161", "Missing No/0/-300/Crafting -9/Missing No/true/true/0/Missing No");
        entries.Add("155", "Venus De Loudred/0/-300/Crafting -9/Venus De Loudred/true/true/0/Venus De Loudred");
        entries.Add("167", "Mimikyu/50/-300/Crafting -9/Prevents crows and Pikachus from attacking your crops. Has a large radius (about 16 \"tiles\")./true/true/0/Mimikyu");
        entries.Add("101", "Incubator/0/-300/Crafting -9/Hatches eggs into baby Flying Types and Psyducks./true/false/2/Incubator");
        entries.Add("95", "Stone Noctowl/50/-300/Crafting -9/Garden art for your farm./true/true/0/Stone Noctowl");
        entries.Add("54", "Stone Honchcrow/50/-300/Crafting -9/Garden art for your farm./true/true/0/Stone Honchcrow");
        entries.Add("53", "Stone Dodrio/50/-300/Crafting -9/Garden art for your farm./true/true/0/Stone Dodrio");
        entries.Add("52", "Stone Politoed/50/-300/Crafting -9/Garden art for your farm./true/true/0/Stone Politoed");
        entries.Add("107", "Plush Buneary/0/-300/Crafting -9/It's big, it's soft, and it's cute./false/true/0/Plush Buneary");
        entries.Add("31", "Natu Statue/50/-300/Crafting -9/A wooden statue of a Natu./true/true/0/Natu Statue");

        toReplace.Changes.Add(new Item("EditData", "Data/BigCraftablesInformation", entries));

        //Data/Furniture
        entries = new Dictionary<string, string>();
        entries.Add("1541", "\"Umbreon Of Eco-Hill\"/painting/2 2/2 2/1/1000");
        entries.Add("1563", "\"Lunatone Street\"/painting/2 2/2 2/1/800");
        entries.Add("2584", "\"Jade Hills Mew\"/painting/4 2/4 2/1/6750");
        entries.Add("1554", "\"Jade Hills Mew\"/painting/3 2/3 2/1/1750");
        entries.Add("1453", "\"Path To Drowzee\"/painting/2 2/2 2/1/750");
        entries.Add("1547", "\"Lapras of the Gem Sea\"/painting/3 2/3 2/1/1200");
        entries.Add("1557", "\"Solrok #44\"/painting/2 2/2 2/1/800");
        entries.Add("1539", "\"The Wailmer\"/painting/2 2/2 2/1/1000");
        entries.Add("1850", "\"The Ekans\"/painting/2 2/2 2/1/1000");
        entries.Add("1852", "\"Fineons #173\"/painting/2 2/2 2/1/1000");
        entries.Add("1607", "\"Porygon  Paradise\"/painting/2 2/2 2/1/1200");
        entries.Add("1671", "\"Ursaring Statue\"/decor/2 4/2 1/1/4000");
        entries.Add("1305", "\"Combusken Statue\"/decor/1 2/1 1/1/500");
        entries.Add("1307", "Dried Sunflora/decor/1 2/1 1/1/500");
        entries.Add("1365", "Futan Panchan/decor/1 1/1 1/1/1500");
        entries.Add("1764", "Futan Buneary/decor/1 1/1 1/1/1500");
        entries.Add("2332", "Mr Mime Statue/decor/2 2/2 1/1/500");
        entries.Add("1294", "Alolan Exeggcutor/decor/1 3/1 1/1/600");
        entries.Add("1733", "Castform Plush/decor/2 2/2 1/1/4000");
        entries.Add("1306", "Tangela Sculpture/decor/1 2/1 1/1/500");
        entries.Add("1669", "Lg. Futan Pancham/decor/2 2/2 1/1/4000");
        entries.Add("2814", "Pachirisu Figurine/decor/1 1/1 1/1/500");
        entries.Add("1917", "Wall Pumpkaboo/painting/1 2/1 2/1/750");

        toReplace.Changes.Add(new Item("EditData", "Data/Furniture", entries));

        //Data/ObjectInformation
        entries = new Dictionary<string, string>();
        entries.Add("128", "Quilfish/200/-40/Fish -4/Quilfish/In order to attack the enemy all over the body with its poisonous sting, the Qwilfish has to take in a lot of water and expand up to several times of its actual size./Day^Summer");
        entries.Add("129", "Wishiwashi/200/-40/Fish -4/Wishiwashi/When it's in trouble, its eyes moisten and begin to shine./Day Night^Spring Fall");
        entries.Add("130", "Remoraid/100/15/Fish -4/Remoraid/Often found in large groups, Remoraid can fire water and hit targets up to 100 meters away./Day^Summer Winter");
        entries.Add("131", "Tynamo/105/12/Fish -4/Tynamo/These Pokémon move in schools. They have an electricity-generating organ, so they discharge electricity if in danger.Day^Spring Summer Fall Winter");
        entries.Add("132", "Feebas/45/5/Fish -4/Feebas/Although extremely ragged, it is a tough Pokémon that can live in almost any kind of water./Night^Spring Summer Fall Winter");
        entries.Add("136", "Blue-Striped Basculin/45/15/Fish -4/Blue-Striped Basculin/Blue-Striped Basculin used to be a common food source. They apparently have an inoffensive, light flavor./Night^Spring Summer Fall Winter");
        entries.Add("137", "White-Striped Basculin/45/15/Fish -4/White-Striped Basculin/Though it differs from other Basculin in several respects, including demeanor—this one is gentle./Day Night^Spring Summer Fall Winter");
        entries.Add("139", "Barraskewda/700/20/Fish -4/Barraskewda/This Pokémon has a jaw that's as sharp as a spear and as strong as steel./Day^Summer");
        entries.Add("142", "Magikarp/55/10/Fish -4/Magikarp/Because all Magikarp seem to do is splash around, some consider them weak, but they're actually a hardy Pokémon that can survive in water no matter how dirty it is./Day Night^Winter");
        entries.Add("143", "Barboach/200/20/Fish -4/Barboach/Hides in mud, leaving only its two whiskers exposed while it waits for prey to come along./Day^Spring Fall Winter");
        entries.Add("145", "Alomomola/30/5/Fish -4/Alomomola/It can use Heal Pulse to help friends recover./Day^Spring Summer");
        entries.Add("148", "Eelektrik/85/12/Fish -4/Eelektrik/They coil around foes and shock them with electricity-generating organs that seem simply to be circular patterns./Night^Spring Fall");
        entries.Add("149", "Octillery/150/-300/Fish -4/Octillery/It locks onto opponents with its leg suckers, then rams them with its rock-hard head./Day^Summer");
        entries.Add("150", "Goldeen/50/10/Fish -4/Goldeen/When the weather warms up, Goldeen form schools and swim upriver./Day^Summer Fall Winter");
        entries.Add("151", "Inkay/80/10/Fish -4/Inkay/It draws prey near with its blinking lights and then wraps them up in its long tentacles and holds them in place./Day^Winter");
        entries.Add("152", "Dragalge/20/5/Fish/Dragalge/Dragalge look very much like drifting kelp when they're swimming with the current./Day Night^Spring Summer Fall Winter");
        entries.Add("153", "Dragalge*/15/5/Fish/Dragalge*/Dragalge look very much like drifting algae when they're swimming with the current./Day Night^Spring Summer Fall Winter");
        entries.Add("154", "Pyukumuku/75/-10/Fish -4/Pyukumuku/Pyukumuku lives in shallow water and attacks enemies with a fist-like appendage./Day^Fall Winter");
        entries.Add("155", "Pyukumuku*/250/50/Fish -4/Pyukumuku*/It can expel its internal organs and use them to grab food or attack enemies./Night^Summer Fall");
        entries.Add("158", "Relicanth/300/-300/Fish -4/Relicanth/This species lives at the bottom of the sea for thousands of years./Day Night^Spring Summer Fall Winter");
        entries.Add("160", "Chinchou/900/10/Fish -4/Chinchou/Have the ability to conduct electrical currents from their two tentacles, which flow positive from one end and negative from the other./Day Night^Spring Summer Fall Winter");
        entries.Add("162", "Eelektros/700/20/Fish -4/Eelektros/Eelektross's mouth locks onto its opponents, where upon it delivers an electric shock./Day Night^Spring Summer Fall Winter");
        entries.Add("164", "Stunfisk/700/20/Fish -4/Stunfisk/Stunfisk hides itself in the mud and then delivers an electric jolt when its prey touches it, smiling all the while./Day Night^Spring Summer Fall Winter");
        entries.Add("165", "Magikarp/700/20/Fish -4/Magikarp/Because all Magikarp seem to do is splash around, some consider them weak, but they're actually a hardy Pokémon that can survive in water no matter how dirty it is./Day Night^Spring Summer Fall Winter");
        entries.Add("267", "Stunfisk(A)/700/20/Fish -4/Stunfisk/Stunfisk hides itself in the mud and then delivers an electric jolt when its prey touches it, smiling all the while./Day^Spring Summer");
        entries.Add("698", "Barraskewda*/700/20/Fish -4/Barraskewda/This Pokémon has a jaw that's as sharp as a spear and as strong as steel./Day^Spring Summer");

        //entries.Add("699", "Barraskewda*/700/20/Fish -4/Barraskewda/It spins its tail fins to propel itself, surging forward at speeds of over 100 knots before ramming prey and spearing into them./Day^Spring Summer");

        entries.Add("700", "Whiscash/700/20/Fish -4/Whiscash/Whiscash has strong territorial instincts and goes berserk when any enemy approaches, creating earthquakes./Day^Spring Summer");
        entries.Add("795", "Sharpedo/700/20/Fish -4/Sharpedo/Due to their sharp fangs, they're highly feared and known as \"The Gangs of the Sea.\"./Day^Spring Summer");
        entries.Add("796", "Grimer/700/20/Fish -4/Grimer/It was born when sludge in a dirty stream was exposed to X-rays from the moon./Day^Spring Summer");
        entries.Add("798", "Inkay/700/20/Fish -4/Inkay/By exposing foes to the blinking of its luminescent spots, Inkay demoralizes them, and then it seizes the chance to flee./Day^Spring Summer");
        entries.Add("799", "Mareanie/700/20/Fish -4/Mareanie/The first symptom of its sting is numbness. The next is an itching sensation so intense that it's impossible to resist the urge to claw at your skin./Day^Spring Summer");
        entries.Add("800", "Gulpin/700/20/Fish -4/Gulpin/Gulpin is able to swallow items of its own size whole, as its stomach comprises most of its body./Day^Spring Summer");
        entries.Add("734", "Shellos/700/20/Fish -4/Shellos/Shellos's shape and color varies depending on where it lives./Day^Spring Summer");
        entries.Add("138", "Bruxish/55/10/Fish -4/Bruxish/When the appendage on its head radiates psychic power, it gives off the sound of grinding teeth./Day Night^Winter");
        entries.Add("838", "Luvdisc/55/10/Fish -4/Luvdisc/It lives in warm seas. It is said that a couple finding this Pokémon will be blessed with eternal love./Day Night^Winter");
        entries.Add("718", "Shelmet/50/-300/Fish -4/Shelmet/When attacked, it defends itself by closing the lid of its shell. It can spit a sticky, poisonous liquid./Day^Spring Summer");
        entries.Add("171", "Old TM/0/-300/Fish -20/Old TM/This was used to teach a Pokemon moves./Day Night^Spring Summer Fall Winter");
        entries.Add("167", "Potion/25/5/Fish -20/Potion/A spray-type medicine for treating wounds./drink/0 0 0 0 0 0 0 0 0 0 0/0");
        entries.Add("168", "Strange Souvenir/0/-300/Fish -20/Strange Souvenir/An ornament depicting a Pokémon that is venerated as a protector in some region far from Kalos./Day Night^Spring Summer Fall Winter");
        entries.Add("775", "Arctovish/1000/10/Fish -4/Arctovish/Though it’s able to capture prey by freezing its surroundings, it has trouble eating the prey afterward because its mouth is on top of its head./Day^Winter");
        entries.Add("837", "Seaking/100/15/Fish -4/S/The horn on its head is sharp like a drill. It bores a hole in a boulder to make its nest./Day^Spring Summer");
        entries.Add("445", "Caviar/500/70/Basic -26/Caviar/The cured roe of a Barraskewda. Considered to be a luxurious delicacy!");
        entries.Add("202", "Fried Inkay/150/32/Cooking -7/Fried Inkay/It's so chewy./food/0 0 0 0 0 0 0 0 0 0 0/0");
        entries.Add("209", "Magikarp Surprise/150/36/Cooking -7/Magikarp Surprise/SURPRISE!/food/0 0 0 0 0 0 0 0 0 0 0/0");
        entries.Add("212", "Barraskewda Dinner/300/50/Cooking -7/Barraskewda Dinner/The lemon spritz makes it special./food/0 0 0 0 0 0 0 0 0 0 0/0");
        entries.Add("214", "Crispy Basculin/150/36/Cooking -7/Crispy Basculin/Wow, the breading is perfect./food/0 0 0 0 0 0 0 0 64 0 0/600");
        entries.Add("219", "Phione Soup/100/40/Cooking -7/Phione Soup/The saltiness is from tears./food/0 1 0 0 0 0 0 0 0 0 0/400");
        entries.Add("225", "Fried Eel/120/30/Cooking -7/Fried Eelektross/Shockingly good!/food/0 0 0 0 1 0 0 0 0 0 0/600");
        entries.Add("226", "Spicy Eel/175/46/Cooking -7/Spicy Eelektross/It's really spicy! Be careful./food/0 0 0 0 1 0 0 0 0 1 0/600");
        entries.Add("607", "Roasted Chestis/270/70/Cooking -7/Roasted Chestis/The roasting process creates a rich forest flavor./food/0 0 0 0 0 0 0 0 0 0 0/0");
        entries.Add("611", "Bluk Cobbler/260/70/Cooking -7/Bluk Cobbler/There's nothing quite like it./food/0 0 0 0 0 0 0 0 0 0 0/0");
        entries.Add("729", "Escargot/125/90/Cooking -7/Escargot/Butter-soaked Goomies cooked to perfection./food/0 2 0 0 0 0 0 0 0 0 0/1440");
        entries.Add("730", "Corphish Bisque/205/90/Cooking -7/Corphish Bisque/This delicate soup is a secret family recipe of Willy's./food/0 3 0 0 0 0 0 50 0 0 0/1440");
        entries.Add("732", "Krabby Cakes/275/90/Cooking -7/Krabby Cakes/Krabby, bread crumbs, and egg formed into patties then fried to a golden brown./food/0 0 0 0 0 0 0 0 0 1 1/1440");
        entries.Add("442", "Psyduck Egg/95/15/Basic -5/Psyduck Egg/It's still warm.");
        entries.Add("444", "Psyduck Feather/250/-300/Basic -18/Psyduck Feather/It's so colorful.");
        entries.Add("307", "Psyduck Mayonnaise/375/-300/Basic -26/Psyduck Mayonnaise/It's a rich, yellow mayonnaise.");
        entries.Add("88", "Exeggcute/100/-300/Basic -79/Exeggcute/Even though it appears to be eggs of some sort, it was discovered to be a life-form more like plant seeds.");
        entries.Add("791", "Exeggcute/100/-300/Basic -79/Exeggcute/Although they are the same size as other Exeggcute, the ones produced in Alola are quite heavy.");
        entries.Add("90", "Cactus Fruit/75/30/Basic -79/Cacnea/The sweet fruit of the prickly pear cactus.");
        entries.Add("802", "Cactus Seeds/0/-300/Seeds -74/Cacnea Seeds/Can only be grown indoors. Takes 12 days to mature, and then produces fruit every 3 days.");
        entries.Add("904", "Nanab Pudding/260/50/Cooking -7/Nanab Pudding/A creamy dessert with a wonderful tropical flavor./food/0 0 1 0 1 0 0 0 0 0 1/430");
        entries.Add("69", "Nanab Sapling/850/-300/Basic -74/Nanab Sapling/Takes 28 days to produce a mature Nanab tree. Bears fruit in the summer, or all year round when planted on Ginger Island.");
        entries.Add("309", "Seedot/20/-300/Crafting -74/Seedot/When it dangles from a tree branch, it looks just like an acorn.");
        entries.Add("613", "Applin/100/15/Basic -79/Applin/It hides from its natural enemies, bird Pokémon, by pretending it’s just an apple and nothing more.");
        entries.Add("633", "Applin Sapling/1000/-300/Basic -74/Applin Sapling/Takes 28 days to produce a mature Applin tree. Bears fruit in the fall. Only grows if the 8 surrounding \"tiles\" are empty.");
        entries.Add("234", "Belueberry Tart/150/50/Cooking -7/Belueberry Tart/It's subtle and refreshing./food/0 0 0 0 0 0 0 0 0 0 0/0");
        entries.Add("481", "Belueberry Seeds/40/-300/Seeds -74/Belueberry Seeds/Plant these in the summer. Takes 13 days to mature, and continues to produce after first harvest.");
        entries.Add("258", "Belueberry/50/10/Basic -79/Belueberry/A popular berry reported to have many health benefits. The blue skin has the highest nutrient concentration.");
        entries.Add("286", "Cherubi Bomb/50/-300/Crafting -8/Cherubi Bomb/Generates a small explosion. Stand back!");
        entries.Add("628", "Cherubi Sapling/850/-300/Basic -74/Cherubi Sapling/Takes 28 days to produce a mature Cherubi tree. Bears fruit in the spring. Only grows if the 8 surrounding \"tiles\" are empty.");
        entries.Add("638", "Cherubi/80/15/Basic -79/Cherubi/It nimbly dashes about to avoid getting pecked by bird Pokémon that would love to make off with its small, nutrient-rich storage ball.");
        entries.Add("372", "Shellder/50/-300/Basic -23/Shellder/Its hard shell repels any kind of attack. It is vulnerable only when its shell is open.");
        entries.Add("404", "Foongus/40/15/Basic -81/Foongus/Slightly nutty, with good texture.");
        entries.Add("393", "Corsola/80/-300/Basic -23/Corsola/In a south-sea nation, the people live in communities that are built on groups of these Pokémon.");
        entries.Add("717", "Krabby/100/-300/Fish -4/Krabby/Its pincers are not only powerful weapons, they are used for balance when walking sideways./Day^Spring Summer");
        entries.Add("710", "Krabby Pot/50/-300/Crafting/Krabby Pot/Place it in the water, load it with bait, and check the next day to see if you've caught anything. Works in streams, lakes, and the ocean.");
        entries.Add("716", "Clauncher/75/-300/Fish -4/Clauncher/They knock down flying prey by firing compressed water from their massive claws like shooting a pistol./Day^Spring Summer");
        entries.Add("260", "Spelonberry/40/5/Basic -79/Spelonberry/Can be ground up into a powder as an ingredient for medicine.");
        entries.Add("482", "Spelonberry Seeds/20/-300/Seeds -74/Spelonberry Seeds/Plant these in the summer. Takes 5 days to mature, and continues to produce after first harvest.");
        entries.Add("715", "Corphish/120/-300/Fish -4/Corphish/Its hardy vitality enables it to adapt to any environment. Its pincers will never release prey./Day^Spring Summer");
        entries.Add("254", "Watmel/250/45/Basic -79/Watmel/A cool, sweet summer treat.");
        entries.Add("479", "Watmel Seeds/40/-300/Seeds -74/Watmel Seeds/Plant these in the summer. Takes 12 days to mature.");
        entries.Add("257", "Morelull/150/8/Basic -81/Morelull/Sought after for its unique nutty flavor.");
        entries.Add("719", "Clamperl/30/-300/Fish -4/Clamperl/It clamps down on its prey with both sides of its shell and doesn’t let go until they stop moving./Day^Spring Summer");
        entries.Add("392", "Omanyte/120/-300/Basic -23/Omanyte/Omanyte is one of the ancient and long-since-extinct Pokémon that have been regenerated from fossils by people.");
        entries.Add("586", "Omanyte Fossil/80/-300/Arch/Omanyte Fossil/This must've washed up ages ago from an ancient coral reef. /Beach .03");
        entries.Add("635", "Oranberry/100/15/Basic -79/Oranberry/Juicy, tangy, and bursting with sweet summer aroma.");
        entries.Add("630", "Oranberry Sapling/1000/-300/Basic -74/Oranberry Sapling/Takes 28 days to produce a mature Orange tree. Bears fruit in the summer. Only grows if the 8 surrounding \"tiles\" are empty.");
        entries.Add("723", "Forretress/40/-300/Fish -4/Forretress/\tIt is encased in a steel shell. Its peering eyes are all that can be seen of its mysterious innards./Day^Spring Summer");
        entries.Add("636", "Pechaberry/140/15/Basic -79/Pechaberry/It's almost fuzzy to the touch.");
        entries.Add("631", "Pechaberry Sapling/1500/-300/Basic -74/Pechaberry Sapling/Takes 28 days to produce a mature Pechaberry tree. Bears fruit in the summer. Only grows if the 8 surrounding \"tiles\" are empty.");
        entries.Add("722", "Shellos/20/-300/Fish -4/Shellos/There's speculation that its appearance is determined by what it eats, but the truth remains elusive./Day^Spring Summer");
        entries.Add("311", "Pineco/5/-300/Crafting -74/Pineco/Pineco hangs from a tree branch and patiently waits for prey to come along.");
        entries.Add("397", "Pincurchin/160/-300/Basic -23/Pincurchin/A slow-moving, spiny creature that some consider a delicacy.");
        entries.Add("721", "Goomy/65/-300/Fish -4/Goomy/It's covered in a slimy membrane that makes any punches or kicks slide off it harmlessly./Day^Spring Summer");
        entries.Add("421", "Sunflora/80/18/Basic -80/Sunflora/A common misconception is that the flower turns so it's always facing the sun.");
        entries.Add("431", "Sunflora Seeds/20/-300/Seeds -74/Sunflora Seeds/Plant in summer or fall. Takes 8 days to produce a large Sunflora. Yields more seeds at harvest.");
        entries.Add("480", "Tamatoberry Seeds/25/-300/Seeds -74/Tamatoberry Seeds/Plant these in the summer. Takes 11 days to mature, and continues to produce after first harvest.");
        entries.Add("618", "Bruschetta/210/45/Cooking -7/Bruschetta/Roasted Tamatoberryes on a crisp white bread./food/0 0 0 0 0 0 0 0 0 0 0/0");
        entries.Add("865", "Gourmet Tamatoberry Salt/0/-300/Quest/Gourmet Tamatoberry Salt/A rare, delicious and savory salt.");
        entries.Add("272", "Eggplant/60/8/Basic -75/Eggplant/A rich and wholesome relative of the Tamatoberry. Delicious fried or stewed.");
        entries.Add("430", "Shroomish/625/5/Basic -17/Shroomish/Shroomish live in damp soil in the dark depths of forests. They are often found keeping still under fallen leaves. This Pokémon feeds on compost that is made up of fallen, rotted leaves.");
        entries.Add("432", "Shroomish Oil/1065/15/Basic -26/Shroomish Oil/A gourmet cooking ingredient./drink/0 0 0 0 0 0 0 0 0 0 0/0");
        entries.Add("604", "Lumberry Pudding/260/70/Cooking -7/Lumberry Pudding/A traditional holiday treat./food/0 0 0 0 0 0 0 0 0 0 0/0");
        entries.Add("406", "Wild Lumberry/80/10/Basic -79/Wild Lumberry/Tart and juicy with a pungent aroma.");
        entries.Add("629", "Apicotberry Sapling/500/-300/Basic -74/Apicotberry Sapling/Takes 28 days to produce a mature Apicotberry tree. Bears fruit in the spring. Only grows if the 8 surrounding \"tiles\" are empty.");
        entries.Add("634", "Apicotberry/50/15/Basic -79/Apicotberry/A tender little fruit with a rock-hard pit.");
        entries.Add("116", "Staryu/40/-300/Arch/Staryu/It appears in large numbers by seashores. At night, its central core flashes with a red light./Beach .1/Money 1 200");
        entries.Add("82", "Fire Stone/100/-300/Basic -17/Fire Stone/A peculiar stone that makes certain species of Pokemon evolve.");

        toReplace.Changes.Add(new Item("EditData", "Data/ObjectInformation", entries));












        return toReplace;
    }
}
