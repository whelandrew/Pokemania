using StardewModdingAPI;
using StardewValley;
using StardewValley.Characters;
using System;
using System.Numerics;

public class ObjectPatches
{
    private static IMonitor Monitor;

    // call this method from your Entry class
    public static void Initialize(IMonitor monitor)
    {
        Monitor = monitor;
    }

    public static bool CanGiveObjectToPet(StardewValley.Object __instance, Pet pet, ref bool __result)
    {
        try
        {
            pet.tryToReceiveActiveObject(Game1.player);
            return false;
        }
        catch
        {
            Monitor.Log($"Failed in {nameof(CanGiveObjectToPet)}:\n(ex)", LogLevel.Error);
            return true;
        }
    }

    public static bool CanBePlacedHere_Prefix(StardewValley.Object __instance, GameLocation location, Vector2 tile, ref bool __result)
    {
        try
        {
            //...; // your patch logic here
            return false; // don't run original logic
        }
        catch (Exception ex)
        {
            Monitor.Log($"Failed in {nameof(CanBePlacedHere_Prefix)}:\n{ex}", LogLevel.Error);
            return true; // run original logic
        }
    }
}