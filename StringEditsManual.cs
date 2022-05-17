using StardewModdingAPI;
using System;

public class StringEditsManual : IAssetEditor
{
    private IModHelper modHelper;
    public StringEditsManual(IModHelper helper)
    {
        modHelper = helper;
    }
    public bool CanEdit<T>(IAssetInfo asset)
    {
        if (asset.Name.IsEquivalentTo("Data/CookingRecipes"))
        {
            return true;
        }
        if (asset.Name.IsEquivalentTo("Data/Mail"))
        {
            return true;
        }
        if (asset.Name.Name == "Data/FarmAnimals")
        {
            return true;
        }

        return false;
    }
    public void Edit<T>(IAssetData asset)
    {
        if (asset.Name.Name=="Data/Mail")
        {
            asset.AsDictionary<string, string>().Data["fall_6_2"] = "Wanted: 1 Fresh Corphish for a marvelous bisque I'm creating.^Who: Gus, proprieter of the Stardrop Saloon^Reward: 800g %item quest 121 %%";
            asset.AsDictionary<string, string>().Data["spring_6_2"] = "@-^I'm really craving a fresh Apicot. I haven't been able to find one at the store, so I'm asking you. I'll pay you well for it!^   -Emily%item quest 115 %%";
            asset.AsDictionary<string, string>().Data["fall_3_1"] = "Dear @,^I'd like to give my Piloswines a special treat. They're such good girls and hungry, too. Could you bring me one bunch of amaranth? They love the stuff. ^Thanks, Dear.^   -Marnie %item quest 106 %%";
            asset.AsDictionary<string, string>().Data["fall_8_1"] = "Hello,^It's Belue season right now. The bushes are full of them. I want to pick some, but I lost my basket. Can you help?^   -Linus%item quest 107 %%";
            asset.AsDictionary<string, string>().Data["fall_26"] = "Dear @,^Notice a chill in the air? It could just be the approach of winter...^Or it could be the tingle of a dark specter, here to help us celebrate tomorrow's festival... the Gourgeist Festival.^Come to town at 10 PM if you'd like to participate.^  -Mayor Lewis";
            asset.AsDictionary<string, string>().Data["spring_23"] = "Dear @,^Tomorrow we're all getting together for the Feather Carnival.^^If you can find a partner, you might even want to participate in the dance yourself!^There's a little clearing beyond the forest west of town where we hold the dance. Arrive between 9 AM and 2 PM if you're interested.^  -Mayor Lewis";
            asset.AsDictionary<string, string>().Data["winter_2_1"] = "Wanted: 1 Fresh Corphish for a marvelous bisque I'm creating.^Who: Gus, proprieter of the Stardrop Saloon^Reward: 800g %item quest 121 %%";
            asset.AsDictionary<string, string>().Data["guildQuest"] = "Wanted: 1 Fresh Corphish for a marvelous bisque I'm creating.^Who: Gus, proprieter of the Stardrop Saloon^Reward: 800g %item quest 121 %%";
            asset.AsDictionary<string, string>().Data["winter_2_1"] = "Hey, I've got a little challenge for you:^    Catch me a Inkay.^You can fish them from the ocean at night. They only show up in the winter, though.^   -Willy%item quest 109 %%";
            asset.AsDictionary<string, string>().Data["winter_26_1"] = "Dear @-^I want to make fish stew, but I need a Totodile! I know they're almost out of season... sorry about the short notice. Could you catch one for me?^   -Gus%item quest 114 %%";
            asset.AsDictionary<string, string>().Data["winter_13_2"] = "I've got another challenge for you: Catch me a Shiny Remoraid.^They don't go down easy, but I know you can do it.^  -Willy%item quest 124 %%";
            asset.AsDictionary<string, string>().Data["summer_28"] = "Dear @,^Tonight at around 10 o'clock PM, a rare and beautiful event will take place.^^The Frillish will be passing by Pelican Town on their long journey south for the winter.^^We're all gathering at the beach to watch. You don't want to miss this!^See you tonight,^ -Demetrius";
            asset.AsDictionary<string, string>().Data["summer_6_2"] = "Fisherman Wanted^I need a good Quilfish specimen. I'm conducting an experiment on the toxin created by the Quilfish.^Reward: 1000g^ -Demetrius%item quest 118 %%";
        }
        if (asset.Name.Name == "Data/TV/CookingChannel")
        {
            asset.AsDictionary<string, string>().Data["10"] = "Phione Soup/Phione Soup! There's something about fresh-caught Phione that just gets me buzzing. Maybe it's the subtle taste of the river. At any rate, I've got a wonderful Phione soup recipe to share with you today...";
            asset.AsDictionary<string, string>().Data["21"] = "Magikarp Surprise/Hey, ever have a bunch of Magikarp laying around and no idea what to do with them? Yeah, me too. Well, I've devised a great solution to this all-too-common problem. I call it... Magikarp surprise. It's quite easy to make, but you'll need a lot of Magikarp...";
            asset.AsDictionary<string, string>().Data["24"] = "Roasted Chestis/Roasted Chestis! I've got a nice old hazelnut tree behind my house, and every year I invite the family over for a nut roasting party! Once we start roasting, it's inevitable that the neighbors will show up. That rich, nutty smell is irresistable. Now, here's the family recipe...";
            asset.AsDictionary<string, string>().Data["27"] = "Krabby Cakes/Krabby Cakes! Krabby meat is very flimsy on its own, but mixing it with bread crumbs and egg is a great way to give them some body. That's why these cakes are my favorite way to eat crab! But before you go cracking any shells, stay tuned for my essential seasoning mixture...";
            asset.AsDictionary<string, string>().Data["30"] = "Corphis Bisque / Corphis Bisque!You could serve this one to the governor himself. It's rich, creamy and delicious, with just the right amount of oceanic flavor. The hardest part is finding some lobster, but I'm sure you can do it.Heck, if you're feeling crafty you could catch one yourself with a Corphis pot!";            
        }
        if (asset.Name.Name == "Data/FarmAnimals")
        {
            asset.AsDictionary<string, string>().Data["White Chicken"] = "1/3/176/174/cluck/8/32/48/32/8/32/48/32/0/false/Coop/16/16/16/16/4/7/null/641/800/Prinplup/Coop";
            asset.AsDictionary<string, string>().Data["Brown Chicken"] = "1/3/180/182/cluck/8/32/48/32/8/32/48/32/0/false/Coop/16/16/16/16/7/4/null/641/800/Xatu/Coop";
            asset.AsDictionary<string, string>().Data["Blue Chicken"] = "1/3/176/174/cluck/8/32/48/32/8/32/48/32/0/false/Coop/16/16/16/16/7/4/null/641/800/Combusken/Coop";
            asset.AsDictionary<string, string>().Data["Void Chicken"] = "1/3/305/305/cluck/8/32/48/32/8/32/48/32/0/false/Coop/16/16/16/16/4/4/null/641/800/Banette/Coop";
            asset.AsDictionary<string, string>().Data["Duck"] = "2/5/442/444/Psyduck/8/32/48/32/8/32/48/32/0/false/Coop/16/16/16/16/3/8/null/642/1200/Psyduck/Coop";
            asset.AsDictionary<string, string>().Data["Rabbit"] = "4/6/440/446/Nidoran/8/32/48/32/8/32/48/32/0/false/Coop/16/16/16/16/10/5/null/643/8000/Shaymin/Coop";
            asset.AsDictionary<string, string>().Data["Dinosaur"] = "7/0/107/100/none/8/32/48/32/8/32/48/32/0/false/Coop/16/16/16/16/1/8/null/644/1000/Bagon/Coop";
            asset.AsDictionary<string, string>().Data["White Cow"] = "1/5/184/186/cow/36/64/64/64/36/64/64/64/1/false/Barn/32/32/32/32/15/5/Milk Pail/639/1500/Hippowdon/Barn";
            asset.AsDictionary<string, string>().Data["Brown Cow"] = "1/5/184/186/cow/36/64/64/64/36/64/64/64/1/false/Barn/32/32/32/32/15/5/Milk Pail/639/1500/Piloswine /Barn";
            asset.AsDictionary<string, string>().Data["Goat"] = "2/5/436/438/Gogoat/24/64/84/64/24/64/84/64/1/false/Barn/32/32/32/32/10/5/Milk Pail/644/4000/Gogoat/Barn";
            asset.AsDictionary<string, string>().Data["Pig"] = "1/10/430/100/Grumpig/24/64/84/64/24/64/84/64/1/false/Barn/32/32/32/32/20/5/null/640/16000/Pig/Barn";
            asset.AsDictionary<string, string>().Data["Sheep"] = "3/4/440/100/Mareep/24/64/84/64/24/64/84/64/1/true/Barn/32/32/32/32/15/5/Shears/644/8000/Flaafy/Barn";
        }
    }
}
