using Microsoft.Xna.Framework;
using StardewModdingAPI;
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
    private ToReplace toAdd = new ToReplace();
    public Pokedex()
    {
        toReplace.Changes = new List<Item>();
        toAdd.Changes = new List<Item>();
    }

    public ToReplace AddToLists()
    {


        return toAdd;
    }

    public ToReplace GetAllPokemon()
    {      
        //EditData
        IDictionary<string, string> entries = new Dictionary<string, string>();

        

        return toReplace;
    }
}
