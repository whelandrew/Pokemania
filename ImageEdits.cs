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
        edits = new EditClass[20];
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
        edits[0].replacers = new replacer[]
        {
            //fish need to be reapplied and new Rects set
            new replacer("Fish_01", new Rectangle(128, 80, 80, 16)),
            new replacer("Fish_02", new Rectangle(256, 80, 128, 16)),
            new replacer("Fish_03", new Rectangle(0, 96, 144, 16)),
            new replacer("Fish_04", new Rectangle(160, 96, 48, 16)),
            new replacer("Fish_05", new Rectangle(224, 96, 128, 16)),
            new replacer("Fish_06", new Rectangle(160, 448, 32, 16)),
            //new replacer("Fish_07", new Rectangle(160, 448, 32, 16)),
            new replacer("Fish_08", new Rectangle(304, 464, 80, 16)),
            new replacer("Fish_09", new Rectangle(0, 480, 64, 16)),
            new replacer("Fish_10", new Rectangle(208, 479, 32, 16)),
            new replacer("Fish_11", new Rectangle(48, 528, 32, 16)),
            new replacer("Fish_12", new Rectangle(96, 528, 48, 16)),
            new replacer("Omanyte", new Rectangle(112, 512, 16, 16)),
            new replacer("Potion", new Rectangle(368, 96, 16, 16)),
            new replacer("Junk", new Rectangle(0, 112, 80, 16)),
            new replacer("Food_01", new Rectangle(96, 128, 16, 16)),
            new replacer("Fruit_01", new Rectangle(256, 160, 16, 16)),
            new replacer("Fruit_02", new Rectangle(288, 160, 16, 16)),
            new replacer("Fruit_03", new Rectangle(224, 256, 16, 16)),
            new replacer("Fruit_04", new Rectangle(256, 256, 16, 16)),
            new replacer("Fruit_05", new Rectangle(352, 256, 16, 16)),
            new replacer("Fruit_06", new Rectangle(0, 272, 16, 16)),
            new replacer("Fruit_07", new Rectangle(32, 272, 16, 16)),
            new replacer("Fruit_08", new Rectangle(160, 416, 80, 16)),
            new replacer("Shellder", new Rectangle(192, 240, 16, 16)),
            new replacer("Shells", new Rectangle(128, 256, 48, 16)),
            new replacer("Mareanie", new Rectangle(208, 256, 16, 16)),
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
                    asset.AsImage().PatchImage(tex, tex.Bounds, i.positions, PatchMode.Overlay);
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

