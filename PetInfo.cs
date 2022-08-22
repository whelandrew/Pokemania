using StardewValley;
using StardewValley.Characters;
using System;
public class PetInfo
{
    public PetInfo(Pet newPet)
    {
        pet = newPet;
    }
    public Pet pet;
    public void receiveObject(Farmer who, StardewValley.Item curItem)
    {
        Console.WriteLine("yay");
        //who.Halt();
        pet.tryToReceiveActiveObject(who);

    }
}
