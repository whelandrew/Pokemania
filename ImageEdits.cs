using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;

//relocate fish to better fit their replacements. Not all fish had a pokemeon equivelant (doing a search for red mullet was very amusing)
public class EditClass
{
    public EditClass(string _assetName)
    {
        assetName = _assetName;
    }

    public string assetName;
    public replacer[] replacers = new replacer[30];
}
public class replacer
{
    public replacer(string _fileName, Rectangle _positions)
    {
        fileName = _fileName;
        positions = _positions;
    }

    public string fileName;
    public Rectangle positions;
}

public class ImageEdits : IAssetEditor
{
    private EditClass[] edits;
	private IModHelper modHelper;
    private void SetupEdits()
    {
        edits = new EditClass[25];
        edits[0] = new EditClass("LooseSprites/Cursors");
        edits[0].replacers = new replacer[]
        {
            new replacer("TrainAnimals", new Rectangle(320, 575, 32, 32)),
            new replacer("TrainGraffiti_01", new Rectangle(223, 371, 32, 32)),
            new replacer("TrainGraffiti_02", new Rectangle(319, 639, 32, 32)),
            new replacer("TrainGraffiti_03", new Rectangle(415, 639, 32, 32)),
            new replacer("TrainGraffiti_04", new Rectangle(351, 607, 32, 32)),
            new replacer("TrainGraffiti_05", new Rectangle(415, 575, 32, 32)),
            new replacer("TrainGraffiti_06", new Rectangle(319, 704, 32, 32)),
            new replacer("TrainGraffiti_06", new Rectangle(224, 607, 32, 32)),
            new replacer("Zubat", new Rectangle(640, 1664, 64, 16)),
            new replacer("Pokeballs", new Rectangle(370, 32, 59, 11)),
            new replacer("Mew", new Rectangle(362, 86, 58, 21)),
            new replacer("Chingling_02", new Rectangle(0, 164, 192, 28)),
            new replacer("Chingling_01", new Rectangle(52, 147, 112, 15)),
            new replacer("PetHeads", new Rectangle(160, 208, 95, 16)),
            new replacer("Pokedex", new Rectangle(79, 368, 16, 16)),
            new replacer("FarmHeads", new Rectangle(0, 448, 96, 48)),
            new replacer("Tangella", new Rectangle(127, 687, 16, 30)),
            new replacer("Tangrowth", new Rectangle(159, 676, 32, 43)),
            new replacer("Drifloon", new Rectangle(640, 768, 64, 18)),
            new replacer("Drifblim", new Rectangle(0, 1182, 84, 143)),
            new replacer("Voltorb", new Rectangle(289, 1182, 63, 48)),
            new replacer("Farfetchd", new Rectangle(181, 1428, 22, 22)),
            new replacer("Nidorino_01", new Rectangle(97, 1423, 61, 26)),
            new replacer("Castform_Grey", new Rectangle(288, 1431, 69, 20)),
            new replacer("Misdreavus_02", new Rectangle(282, 1885, 21, 55)),
            new replacer("Houndoom", new Rectangle(323, 1916, 72, 40)),
            new replacer("Pelipper", new Rectangle(387, 1893, 144, 21)),
            new replacer("Lopad", new Rectangle(0, 1920, 64, 16))
            };

        edits[1] = new EditClass("Maps/springobjects");
        edits[1].replacers = new replacer[]
        {
            //fish need to be reapplied and new Rects set
            new replacer("Fish_01", new Rectangle(128, 80, 79, 16)),
            new replacer("Fish_02", new Rectangle(256, 80, 127, 16)),
            new replacer("Fish_03", new Rectangle(0, 96, 380, 16)),
            new replacer("Fish_04", new Rectangle(50, 176, 46, 16)),
            new replacer("Fish_05", new Rectangle(32, 464, 79, 16)),
            new replacer("Fish_06", new Rectangle(0, 480, 64, 16)),
            new replacer("Fish_07", new Rectangle(48, 528, 96, 16)),
            new replacer("Fish_08", new Rectangle(320, 544, 48, 16)),
            new replacer("Fish_09", new Rectangle(112, 512, 16, 16)),
            new replacer("Fish_10", new Rectangle(224, 480, 16, 16)),
            new replacer("Fish_14", new Rectangle(304, 464, 79, 16)),
            
            //new replacer("Omanyte", new Rectangle(112, 512, 16, 16)),
            new replacer("Potion", new Rectangle(368, 96, 16, 16)),
            new replacer("Junk", new Rectangle(0, 112, 16, 16)),
            new replacer("Food_01", new Rectangle(96, 128, 15, 16)),

            new replacer("Jumpluff", new Rectangle(288, 0, 16, 16)),
            new replacer("BeluBerry", new Rectangle(288, 160, 16, 16)),
            new replacer("Oddish_03", new Rectangle(256, 0, 16, 16)),
            new replacer("Chikorita", new Rectangle(320, 0, 16, 16)),
            new replacer("Bellsprout", new Rectangle(352, 0, 16, 16)),
            new replacer("Turtwig", new Rectangle(0, 16, 16, 16)),
            new replacer("Nanab", new Rectangle(304, 48, 16, 16)),
            new replacer("NanabTree", new Rectangle(336, 32, 16, 16)),
            new replacer("Cacnea", new Rectangle(288, 48, 16, 16)),
            new replacer("Torchic", new Rectangle(272, 64, 16, 16)),
            new replacer("Exeggutor", new Rectangle(256, 48, 16, 16)),
            new replacer("Petilil", new Rectangle(128, 160, 16, 16)),
            new replacer("Watmel", new Rectangle(224, 160, 16, 16)),
            new replacer("Tamato", new Rectangle(256, 160, 16, 16)),
            new replacer("Spelon", new Rectangle(320, 160, 16, 16)),
            new replacer("Egg", new Rectangle(16, 192, 16, 16)),
            new replacer("Seedot", new Rectangle(336, 192, 16, 16)),
            new replacer("Pineco", new Rectangle(368, 192, 16, 16)),
            new replacer("Shellder", new Rectangle(192, 240, 16, 16)),
            new replacer("Omanyte", new Rectangle(128, 256, 16, 16)),
            new replacer("Corsola", new Rectangle(144, 256, 16, 16)),
            new replacer("Shroomish", new Rectangle(352, 272, 16, 16)),
            new replacer("Foongus", new Rectangle(320, 256, 16, 16)),
            new replacer("Morelull", new Rectangle(272, 160, 16, 16)),
            new replacer("Sunflora", new Rectangle(208, 272, 16, 16)),
            new replacer("Applin", new Rectangle(208, 400, 16, 16)),
            new replacer("Oran", new Rectangle(176, 416, 16, 16)),
            new replacer("Cherubi", new Rectangle(224, 416, 16, 16)),
            new replacer("Pinap", new Rectangle(256, 544, 16, 16)),
            new replacer("Pincurchin", new Rectangle(208, 256, 16, 16)),
            new replacer("AnorinthCocktail", new Rectangle(208, 480, 16, 16)),
            new replacer("Lumberry", new Rectangle(352, 256, 16, 16)),
            new replacer("Apicotberry", new Rectangle(192, 416, 16, 16)),
            new replacer("Exeggutor02", new Rectangle(368, 512, 16, 16)),
            new replacer("Staryu02", new Rectangle(320, 64, 16, 16)),

        };

        edits[2] = new EditClass("LooseSprites/JunimoNote");
        edits[2].replacers = new replacer[]
        {
            new replacer("Hippowdon", new Rectangle(128, 180, 21, 22)),
            new replacer("Lapras", new Rectangle(255,180,32,32)),
            new replacer("Krabby", new Rectangle(352,180,32,32)),
            new replacer("Staryu", new Rectangle(447,180,32,32)),
        };

        edits[3] = new EditClass("Maps/Festivals");
        edits[3].replacers = new replacer[]
        {
            new replacer("Frillish", new Rectangle(256, 16, 96, 32)),
            new replacer("Fish_10", new Rectangle(111,431,16,16)),
            new replacer("Spinarak", new Rectangle(256,288,16,16)),
            new replacer("Jynx", new Rectangle(32,32,16,48)),
            new replacer("Fish_10", new Rectangle(111,431,16,16)),
            new replacer("FishBox", new Rectangle(464,55,48,48)),
            new replacer("Castform_02", new Rectangle(303,160,31,31)),
            new replacer("Castform_01", new Rectangle(116,160,31,31)),
            new replacer("Drifloons", new Rectangle(192,208,94,30)),
            new replacer("Pumpkaboo_01", new Rectangle(0,288,128,48)),
            new replacer("Ariados", new Rectangle(256,256,32,32)),
            new replacer("Gengar", new Rectangle(320,336,64,16)),
            new replacer("Clefairy", new Rectangle(96,352,32,48)),
            new replacer("Bellossom", new Rectangle(128,32,32,32)),
            new replacer("Bronzor", new Rectangle(368,112,48,48)),
            new replacer("Chimecho", new Rectangle(64,0,48,32)),
        };

        edits[4] = new EditClass("TileSheets/SecretNotesImages");
        edits[4].replacers = new replacer[]
        {
            new replacer("SecretNotesImages", new Rectangle(129,65,60,52)),
        };

        edits[5] = new EditClass("Maps/DesertTiles");
        edits[5].replacers = new replacer[]
        {
            new replacer("MeowthMachine", new Rectangle(191,287,32,48)),
            new replacer("Salamance", new Rectangle(31,239,64,64)),
            new replacer("Sandshrew", new Rectangle(0,335,32,32)),
        };

        edits[6] = new EditClass("Characters/Emily");
        edits[6].replacers = new replacer[]
        {
            new replacer("Emily", new Rectangle(0,224,48,32)),
        };

        edits[7] = new EditClass("Maps/spring_town");
        edits[7].replacers = new replacer[]
        {
            new replacer("springPokemart", new Rectangle(111,208,92,112)),
            new replacer("springTownCenterpiece", new Rectangle(367,469,48,43)),
            new replacer("PokeCenter", new Rectangle(0,224,80,48)),
            new replacer("OttselSeat", new Rectangle(162,527,29,32)),
            new replacer("Solrok_02", new Rectangle(15,80,18,32)),
            new replacer("Solrok_01", new Rectangle(197,560,18,18)),
            new replacer("Rowlet", new Rectangle(304,79,16,32)),
            new replacer("TownSquare", new Rectangle(416,416,96,96)),
            new replacer("Noctowl_02", new Rectangle(272,592,96,48)),
            new replacer("Noctowl_01", new Rectangle(208,512,112,48)),
            new replacer("Lileep", new Rectangle(384,16,16,31)),
        };

        edits[8] = new EditClass("Maps/winter_town");
        edits[8].replacers = new replacer[]
        {
            new replacer("winterPokemart", new Rectangle(111,208,92,111)),
            new replacer("winterTownCenterpiece", new Rectangle(368,432,48,80)),
            new replacer("PokeCenter", new Rectangle(0,224,80,48)),
            new replacer("OttselSeatWinter", new Rectangle(162,428,29,32)),
            new replacer("SolrokWinter_02", new Rectangle(15,80,18,32)),
            new replacer("SolrokWinter", new Rectangle(197,560,32,16)),
            new replacer("RowletWinter", new Rectangle(304,79,16,32)),
            new replacer("TownSquareWinter", new Rectangle(416,416,96,96)),
            new replacer("NoctowlWinter_02", new Rectangle(272,592,96,32)),
            new replacer("NoctowlWinter_01", new Rectangle(208,512,128,48)),
        };

        edits[9] = new EditClass("Maps/summer_town");
        edits[9].replacers = new replacer[]
        {
            new replacer("summerPokemart", new Rectangle(111,208,92,112)),
            new replacer("summerTownCenterpiece_02", new Rectangle(368,448,48,64)),
            new replacer("summerTownCenterpiece_01", new Rectangle(383,432,32,16)),
            new replacer("PokeCenter", new Rectangle(0,224,80,48)),
            new replacer("OttselSeat", new Rectangle(162,527,29,32)),
            new replacer("Solrok_02", new Rectangle(15,80,18,32)),
            new replacer("Solrok_01", new Rectangle(197,560,18,18)),
            new replacer("Rowlet", new Rectangle(304,79,16,32)),
            new replacer("TownSquare", new Rectangle(416,416,96,96)),
            new replacer("Noctowl_02", new Rectangle(272,592,96,48)),
            new replacer("Noctowl_01", new Rectangle(208,512,112,48)),
        };

        edits[10] = new EditClass("Minigames/TitleButtons");
        edits[10].replacers = new replacer[]
        {
            new replacer("LegendaryTitle", new Rectangle(0,0,398,187)),
            new replacer("Unown", new Rectangle(0,187,296,116)),
            new replacer("Unown_02", new Rectangle(8,458,44,25)),
            new replacer("Chatot", new Rectangle(296,226,104,28)),
            new replacer("MewTwo", new Rectangle(177,376,167,67)),
            new replacer("Castform_Title", new Rectangle(136,464,264,16)),
            new replacer("Clefable", new Rectangle(0,492,378,68)),
        };

        edits[11] = new EditClass("Maps/fall_town");
        edits[11].replacers = new replacer[]
        {
            new replacer("fallPokemart", new Rectangle(111,208,86,112)),
            new replacer("fallTownCenterpiece", new Rectangle(368,462,48,51)),
            new replacer("PokeCenter", new Rectangle(0,224,80,48)),
            new replacer("OttselSeat", new Rectangle(162,527,29,32)),
            new replacer("Solrok_02", new Rectangle(15,80,18,32)),
            new replacer("Solrok_01", new Rectangle(197,560,18,18)),
            new replacer("Rowlet", new Rectangle(304,79,16,32)),
            new replacer("fallTownSquare", new Rectangle(416,416,96,96)),
            new replacer("Noctowl_04", new Rectangle(272,592,96,48)),
            new replacer("Noctowl_03", new Rectangle(208,512,112,48)),
        };

        edits[12] = new EditClass("Maps/spring_outdoorsTileSheet");
        edits[12].replacers = new replacer[]
        {
            new replacer("MrMime_02", new Rectangle(272,704,32,16)),
            new replacer("MrMime_01", new Rectangle(240,688,32,48)),
            new replacer("Lopad", new Rectangle(288,816,64,16)),
            new replacer("Abra", new Rectangle(336,512,16,32)),
        };

        edits[13] = new EditClass("Maps/fall_outdoorsTileSheet");
        edits[13].replacers = new replacer[]
        {
            new replacer("MrMime_02", new Rectangle(272,704,32,16)),
            new replacer("MrMime_01", new Rectangle(240,688,32,48)),
            new replacer("Lopad", new Rectangle(288,816,64,16)),
            new replacer("Abra", new Rectangle(336,512,16,32)),
        };

        edits[14] = new EditClass("Maps/winter_outdoorsTileSheet");
        edits[14].replacers = new replacer[]
        {
            new replacer("MrMime_02", new Rectangle(272,704,32,16)),
            new replacer("MrMime_01", new Rectangle(240,688,32,48)),
            new replacer("Lopad", new Rectangle(288,816,64,16)),
            new replacer("Abra", new Rectangle(336,512,16,32)),
        };

        edits[15] = new EditClass("Maps/night_market_tilesheet_objects");
        edits[15].replacers = new replacer[]
        {
            new replacer("VileBloom", new Rectangle(337,106,27,15)),
            new replacer("Rotom", new Rectangle(976,175,96,32)),
            new replacer("Ekans", new Rectangle(208,176,32,32)),
            new replacer("Lanturn_02", new Rectangle(111,271,32,32)),
            new replacer("Lanturn_01", new Rectangle(47,127,32,32)),
            new replacer("Manaphy", new Rectangle(975,90,27,27)),
            new replacer("NidorinoFloat_01", new Rectangle(704,48,48,48)),
            new replacer("NidorinoFloat_02", new Rectangle(544,48,48,48)),
        };

        edits[16] = new EditClass("Maps/townInterior");
        edits[16].replacers = new replacer[]
        {
            new replacer("Smeargle", new Rectangle(351,559,16,32)),
            new replacer("Pancham", new Rectangle(0,271,16,16)),
            new replacer("Machoke", new Rectangle(287,160,16,16)),
            new replacer("Marowak", new Rectangle(319,384,64,32)),
            new replacer("ShinyP", new Rectangle(128,624,16,14)),
            new replacer("Tangella", new Rectangle(351,528,16,30)),
            new replacer("Ursaring", new Rectangle(0,688,32,64)),
            new replacer("Pangoro", new Rectangle(0,640,32,32)),
            new replacer("SlowPoke", new Rectangle(320,480,48,32)),
            new replacer("Koffing", new Rectangle(224,1024,32,32)),
            new replacer("Oddish", new Rectangle(480,960,32,32)),
        };

        edits[17] = new EditClass("Maps/SewerTiles");
        edits[17].replacers = new replacer[]
        {
            new replacer("Spinda", new Rectangle(96,144,30,32)),
        };

        edits[18] = new EditClass("Maps/HarveyBalloonTiles");
        edits[18].replacers = new replacer[]
        {
            new replacer("HarveyBalloon", new Rectangle(0,0,93,106)),
        };

        edits[19] = new EditClass("MiniGames/Intro");
        edits[19].replacers = new replacer[]
        {
            new replacer("Pidgey", new Rectangle(16,64,95,16)),
            new replacer("Venusaur", new Rectangle(48,175,64,80)),
        };

        edits[20] = new EditClass("TileSheets/Craftables");
        edits[20].replacers = new replacer[]
        {
            new replacer("Altaria", new Rectangle(16,64,16,32)),
            new replacer("MissingNo", new Rectangle(16,640,16,32)),
            new replacer("Noctowl", new Rectangle(112,352,16,32)),
            new replacer("Elgyem", new Rectangle(96,480,16,32)),
            new replacer("Regirock", new Rectangle(96,352,16,32)),
            new replacer("Statues", new Rectangle(64,191,64,32)),
            new replacer("Buneary", new Rectangle(48,416,16,32)),
            new replacer("Misdreavus", new Rectangle(16,448,16,32)),
            new replacer("GoldMeowth", new Rectangle(112,480,16,29)),
            new replacer("IridiumMeowth", new Rectangle(0,640,16,32)),
            new replacer("Sentrent", new Rectangle(48,455,16,32)),
            new replacer("StatueNatu", new Rectangle(112,96,15,29)),
            new replacer("Loudred", new Rectangle(32,640,16,32)),
            new replacer("Mimikyu", new Rectangle(112,640,16,32)),
        };

        edits[21] = new EditClass("TileSheets/furniture");
        edits[21].replacers = new replacer[]
        {
            new replacer("Combusken", new Rectangle(400,640,16,32)),
            new replacer("Eggxecutor", new Rectangle(224,641,16,48)),
            new replacer("Pancham", new Rectangle(336,672,16,16)),
            new replacer("Paintings", new Rectangle(48,769,415,31)),
            new replacer("Paintings02", new Rectangle(416,918,64,18)),
            new replacer("Porygon", new Rectangle(111,800,32,29)),
            new replacer("Pangoro", new Rectangle(80,831,32,32)),
            new replacer("Ursaring", new Rectangle(111,831,32,64)),
            new replacer("Castform", new Rectangle(80,864,32,32)),
            new replacer("Tangella", new Rectangle(416,640,16,30)),
            new replacer("Sunflora02", new Rectangle(336,976,32,46)),
            new replacer("Buneary01", new Rectangle(64,880,16,16)),
            new replacer("MrMime_03", new Rectangle(448,1152,32,32)),
            new replacer("Pachirisu", new Rectangle(480,1392,16,16)),
            new replacer("Pumpkaboo_03", new Rectangle(464,944,16,32)),
        };

        edits[22] = new EditClass("LooseSprites/Cursors2");
        edits[22].replacers = new replacer[]
        {
            new replacer("Chatot_02", new Rectangle(0,299,201,21)),
            new replacer("Remoraid", new Rectangle(172,33,84,28)),
            new replacer("Chatot_03", new Rectangle(148,62,42,28)),
            new replacer("Trubbish", new Rectangle(39,0,16,32)),
            new replacer("Tortera", new Rectangle(152,94,104,53)),
            new replacer("Snorlax", new Rectangle(0,80,92,56)),
            new replacer("Bellosom_01", new Rectangle(194,167,16,17)),
        };
    }
	public ImageEdits(IModHelper  helper)      
	{
		modHelper = helper;
        SetupEdits();
	}
	public bool CanEdit<T>(IAssetInfo asset)
	{
        if(GetReplacer(asset.AssetName) !=null)
        {
            return true;
        }
        return false;
	}
    public void Edit<T>(IAssetData asset)
    {
        EditClass currentAsset = GetReplacer(asset.AssetName);
        if (currentAsset != null)
        {
            foreach (replacer i in currentAsset.replacers)
            {
                if (i != null)
                {
                    Texture2D tex = modHelper.Content.Load<Texture2D>("assets/Edits/" + i.fileName + ".png", ContentSource.ModFolder);
                    asset.AsImage().PatchImage(tex, tex.Bounds, i.positions, PatchMode.Replace);
                }
            }
        }
    }
    private EditClass GetReplacer(string name)
    {
        foreach(EditClass i in edits)
        {
            if(i!=null && i.assetName==name)
            {
                return i;
            }
        }

        return null;
    }
}

