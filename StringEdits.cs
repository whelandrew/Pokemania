using StardewModdingAPI;
using StardewModdingAPI.Events;
using System.Collections.Generic;
using System.Diagnostics;

public class StringEdits
{
	public StringEdits(string _assetName, string indexStr, string _stringEdit)
    {
		assetName = _assetName;
		indexString = indexStr;
		stringEdit = _stringEdit;
	}
	public StringEdits(string _assetName, int _index, string _stringEdit)
	{
		assetName = _assetName;
		index = _index;
		stringEdit = _stringEdit;
	}

	public string assetName;
	public int index;
	public string indexString;
	public string stringEdit;
}

public class EditStrings : IAssetEditor
{
	private List<StringEdits> edits = new List<StringEdits>();
	private List<StringEdits> stringKeys = new List<StringEdits>();
	private IModHelper modHelper;
	private void SetupEdits()
	{
		//food
		FoodEdits();

		//fish
		FishEdits();

		//furniture
		FurnitureEdits();

		//big craftables
		BigCraftables();

		//misc
		MiscEdits();
	}
	private void BigCraftables()
	{
		edits.Add(new StringEdits("Data/BigCraftablesInformation", 161, "Missing No/0/-300/Crafting -9/Missing No/true/true/0/Missing No"));
		edits.Add(new StringEdits("Data/BigCraftablesInformation", 155, "Venus De Loudred/0/-300/Crafting -9/Venus De Loudred/true/true/0/Venus De Loudred"));
		edits.Add(new StringEdits("Data/BigCraftablesInformation", 167, "Mimikyu/50/-300/Crafting -9/Prevents crows and Pikachus from attacking your crops. Has a large radius (about 16 \"tiles\")./true/true/0/Mimik"));
		edits.Add(new StringEdits("Data/BigCraftablesInformation", 101, "Incubator/0/-300/Crafting -9/Hatches eggs into baby Flying Types and Psyducks./true/false/2/Incubator"));
		edits.Add(new StringEdits("Data/BigCraftablesInformation", 95, "Stone Noctowl/50/-300/Crafting -9/Garden art for your farm./true/true/0/Stone Noctowl"));
		edits.Add(new StringEdits("Data/BigCraftablesInformation", 54, "Stone Castform/50/-300/Crafting -9/Garden art for your farm./true/true/0/Stone Castform"));
		edits.Add(new StringEdits("Data/BigCraftablesInformation", 53, "Stone Dodrio/50/-300/Crafting -9/Garden art for your farm./true/true/0/Stone Dodrio"));
		edits.Add(new StringEdits("Data/BigCraftablesInformation", 52, "Stone Politoed/50/-300/Crafting -9/Garden art for your farm./true/true/0/Stone Politoed"));
		edits.Add(new StringEdits("Data/BigCraftablesInformation", 107, "Plush Buneary/0/-300/Crafting -9/It's big, it's soft, and it's cute./false/true/0/Plush Buneary"));
		edits.Add(new StringEdits("Data/BigCraftablesInformation", 31, "Natu Statue/50/-300/Crafting -9/A wooden statue of a Natu./true/true/0/Natu Statue"));
	}
	private void FurnitureEdits()
	{
		edits.Add(new StringEdits("Data/Furniture", 1541, "\"Umbreon Of Eco-Hill\"/painting/2 2/2 2/1/1000"));
		edits.Add(new StringEdits("Data/Furniture", 1563, "\"Lunatone Street\"/painting/2 2/2 2/1/800"));
		edits.Add(new StringEdits("Data/Furniture", 2584, "\"Jade Hills Mew\"/painting/4 2/4 2/1/6750"));
		edits.Add(new StringEdits("Data/Furniture", 1554, "\"Jade Hills Mew\"/painting/3 2/3 2/1/1750"));
		edits.Add(new StringEdits("Data/Furniture", 1543, "\"Path To Drowzee\"/painting/2 2/2 2/1/750"));
		edits.Add(new StringEdits("Data/Furniture", 1547, "\"Lapras of the Gem Sea\"/painting/3 2/3 2/1/1200"));
		edits.Add(new StringEdits("Data/Furniture", 1557, "\"Solrock #44\"/painting/2 2/2 2/1/800"));
		edits.Add(new StringEdits("Data/Furniture", 1539, "\"The Wailmer\"/painting/2 2/2 2/1/1000"));
		edits.Add(new StringEdits("Data/Furniture", 1850, "\"The Ekans\"/painting/2 2/2 2/1/1000"));
		edits.Add(new StringEdits("Data/Furniture", 1852, "\"Fineons #173\"/painting/2 2/2 2/1/1000"));
		edits.Add(new StringEdits("Data/Furniture", 1607, "\"Porygon  Paradise\"/painting/2 2/2 2/1/1200"));
		edits.Add(new StringEdits("Data/Furniture", 1671, "\"Ursaring Statue\"/decor/2 4/2 1/1/4000"));
		edits.Add(new StringEdits("Data/Furniture", 1305, "\"Combusken Statue\"/decor/1 2/1 1/1/500"));
		edits.Add(new StringEdits("Data/Furniture", 1307, "Dried Sunflora/decor/1 2/1 1/1/500"));
		edits.Add(new StringEdits("Data/Furniture", 1365, "Futan Panchan/decor/1 1/1 1/1/1500"));
		edits.Add(new StringEdits("Data/Furniture", 1764, "Futan Buneary/decor/1 1/1 1/1/1500"));
		edits.Add(new StringEdits("Data/Furniture", 2332, "Mr Mime Statue/decor/2 2/2 1/1/500"));
		edits.Add(new StringEdits("Data/Furniture", 1294, "Alolan Exeggutor/decor/1 3/1 1/1/600"));
		edits.Add(new StringEdits("Data/Furniture", 1733, "Castform Plush/decor/2 2/2 1/1/4000"));
		edits.Add(new StringEdits("Data/Furniture", 1306, "Tangela Sculpture/decor/1 2/1 1/1/500"));
		edits.Add(new StringEdits("Data/Furniture", 1669, "Lg. Futan Pancham/decor/2 2/2 1/1/4000"));
		edits.Add(new StringEdits("Data/Furniture", 2814, "Pachirisu Figurine/decor/1 1/1 1/1/500"));
		edits.Add(new StringEdits("Data/Furniture", 1917, "Wall Pumpkaboo/painting/1 2/1 2/1/750"));
	}
	private void FishEdits()
	{
		edits.Add(new StringEdits("Data/ObjectInformation", 128, "Quilfish/200/-40/Fish -4/Quilfish/In order to attack the enemy all over the body with its poisonous sting, the Qwilfish has to take in a lot of water and expand up to several times of its actual size./Day^Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 129, "Wishiwashi/200/-40/Fish -4/Wishiwashi/When it's in trouble, its eyes moisten and begin to shine./Day Night^Spring Fall"));
		edits.Add(new StringEdits("Data/ObjectInformation", 130, "Remoraid/100/15/Fish -4/Remoraid/Often found in large groups, Remoraid can fire water and hit targets up to 100 meters away./Day^Summer Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 131, "Tynamo/105/12/Fish -4/Tynamo/These Pokémon move in schools. They have an electricity-generating organ, so they discharge electricity if in danger.Day^Spring Summer Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 132, "Feebas/45/5/Fish -4/Feebas/Although extremely ragged, it is a tough Pokémon that can live in almost any kind of water./Night^Spring Summer Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 136, "Blue-Striped Basculin/45/15/Fish -4/Blue-Striped Basculin/Blue-Striped Basculin used to be a common food source. They apparently have an inoffensive, light flavor./Night^Spring Summer Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 137, "White-Striped Basculin/45/15/Fish -4/White-Striped Basculin/Though it differs from other Basculin in several respects, including demeanor—this one is gentle./Day Night^Spring Summer Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 139, "Barraskewda/700/20/Fish -4/Barraskewda/This Pokémon has a jaw that's as sharp as a spear and as strong as steel./Day^Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 142, "Magikarp/55/10/Fish -4/Magikarp/Because all Magikarp seem to do is splash around, some consider them weak, but they're actually a hardy Pokémon that can survive in water no matter how dirty it is./Day Night^Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 143, "Barboach/200/20/Fish -4/Barboach/Hides in mud, leaving only its two whiskers exposed while it waits for prey to come along./Day^Spring Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 145, "Alomomola/30/5/Fish -4/Alomomola/It can use Heal Pulse to help friends recover./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 148, "Eelektrik/85/12/Fish -4/Eelektrik/They coil around foes and shock them with electricity-generating organs that seem simply to be circular patterns./Night^Spring Fall"));
		edits.Add(new StringEdits("Data/ObjectInformation", 149, "Octillery/150/-300/Fish -4/Octillery/It locks onto opponents with its leg suckers, then rams them with its rock-hard head./Day^Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 150, "Goldeen/50/10/Fish -4/Goldeen/When the weather warms up, Goldeen form schools and swim upriver./Day^Summer Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 151, "Inkay/80/10/Fish -4/Inkay/It draws prey near with its blinking lights and then wraps them up in its long tentacles and holds them in place./Day^Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 152, "Dragalge/20/5/Fish/Dragalge/Dragalge look very much like drifting kelp when they're swimming with the current./Day Night^Spring Summer Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 153, "Dragalge/15/5/Fish/Dragalge/Dragalge look very much like drifting algae when they're swimming with the current./Day Night^Spring Summer Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 154, "Pyukumuku/75/-10/Fish -4/Pyukumuku/Pyukumuku lives in shallow water and attacks enemies with a fist-like appendage./Day^Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 155, "Pyukumuku/250/50/Fish -4/Pyukumuku/It can expel its internal organs and use them to grab food or attack enemies./Night^Summer Fall"));
		edits.Add(new StringEdits("Data/ObjectInformation", 158, "Relicanth/300/-300/Fish -4/Relicanth/This species lives at the bottom of the sea for thousands of years./Day Night^Spring Summer Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 160, "Chinchou/900/10/Fish -4/Chinchou/Have the ability to conduct electrical currents from their two tentacles, which flow positive from one end and negative from the other./Day Night^Spring Summer Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 162, "Eelektros/700/20/Fish -4/Eelektros/Eelektross's mouth locks onto its opponents, where upon it delivers an electric shock./Day Night^Spring Summer Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 164, "Stunfisk/700/20/Fish -4/Stunfisk/Stunfisk hides itself in the mud and then delivers an electric jolt when its prey touches it, smiling all the while./Day Night^Spring Summer Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 165, "Magikarp/700/20/Fish -4/Magikarp/Because all Magikarp seem to do is splash around, some consider them weak, but they're actually a hardy Pokémon that can survive in water no matter how dirty it is./Day Night^Spring Summer Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 267, "Stunfisk/700/20/Fish -4/Stunfisk/Stunfisk hides itself in the mud and then delivers an electric jolt when its prey touches it, smiling all the while./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 698, "Barraskewda/700/20/Fish -4/Barraskewda/This Pokémon has a jaw that's as sharp as a spear and as strong as steel./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 699, "Barraskewda/700/20/Fish -4/Barraskewda/It spins its tail fins to propel itself, surging forward at speeds of over 100 knots before ramming prey and spearing into them./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 700, "Whiscash/700/20/Fish -4/Whiscash/Whiscash has strong territorial instincts and goes berserk when any enemy approaches, creating earthquakes./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 795, "Sharpedo/700/20/Fish -4/Sharpedo/Due to their sharp fangs, they're highly feared and known as \"The Gangs of the Sea.\"./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 796, "Grimer/700/20/Fish -4/Grimer/It was born when sludge in a dirty stream was exposed to X-rays from the moon./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 798, "Inkay/700/20/Fish -4/Inkay/By exposing foes to the blinking of its luminescent spots, Inkay demoralizes them, and then it seizes the chance to flee./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 799, "Mareanie/700/20/Fish -4/Mareanie/The first symptom of its sting is numbness. The next is an itching sensation so intense that it's impossible to resist the urge to claw at your skin./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 800, "Gulpin/700/20/Fish -4/Gulpin/Gulpin is able to swallow items of its own size whole, as its stomach comprises most of its body./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 734, "Shellos/700/20/Fish -4/Shellos/Shellos's shape and color varies depending on where it lives./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 138, "Bruxish/55/10/Fish -4/Bruxish/When the appendage on its head radiates psychic power, it gives off the sound of grinding teeth./Day Night^Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 838, "Luvdisc/55/10/Fish -4/Luvdisc/It lives in warm seas. It is said that a couple finding this Pokémon will be blessed with eternal love./Day Night^Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 718, "Shelmet/50/-300/Fish -4/Shelmet/When attacked, it defends itself by closing the lid of its shell. It can spit a sticky, poisonous liquid./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 171, "Old TM/0/-300/Fish -20/Old TM/This was used to teach a Pokemon moves./Day Night^Spring Summer Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 167, "Potion/25/5/Fish -20/Potion/A spray-type medicine for treating wounds./drink/0 0 0 0 0 0 0 0 0 0 0/0"));
		edits.Add(new StringEdits("Data/ObjectInformation", 168, "Strange Souvenir/0/-300/Fish -20/Strange Souvenir/An ornament depicting a Pokémon that is venerated as a protector in some region far from Kalos./Day Night^Spring Summer Fall Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 775, "Arctovish/1000/10/Fish -4/Arctovish/Though it’s able to capture prey by freezing its surroundings, it has trouble eating the prey afterward because its mouth is on top of its head./Day^Winter"));
		edits.Add(new StringEdits("Data/ObjectInformation", 837, "Seaking/100/15/Fish -4/S/The horn on its head is sharp like a drill. It bores a hole in a boulder to make its nest./Day^Spring Summer"));

	}
	private void FoodEdits()
	{
		edits.Add(new StringEdits("Data/ObjectInformation", 445, "Caviar/500/70/Basic -26/Caviar/The cured roe of a Barraskewda. Considered to be a luxurious delicacy!"));
		edits.Add(new StringEdits("Data/ObjectInformation", 202, "Fried Inkay/150/32/Cooking -7/Fried Inkay/It's so chewy./food/0 0 0 0 0 0 0 0 0 0 0/0"));
		edits.Add(new StringEdits("Data/ObjectInformation", 209, "Magikarp Surprise/150/36/Cooking -7/Magikarp Surprise/SURPRISE!/food/0 0 0 0 0 0 0 0 0 0 0/0"));
		edits.Add(new StringEdits("Data/ObjectInformation", 214, "Crispy Basculin/150/36/Cooking -7/Crispy Basculin/Wow, the breading is perfect./food/0 0 0 0 0 0 0 0 64 0 0/600"));
		edits.Add(new StringEdits("Data/ObjectInformation", 219, "Phione Soup/100/40/Cooking -7/Phione Soup/The saltiness is from tears./food/0 1 0 0 0 0 0 0 0 0 0/400"));
		edits.Add(new StringEdits("Data/ObjectInformation", 225, "Fried Eelektross/120/30/Cooking -7/Fried Eelektross/Shockingly good!/food/0 0 0 0 1 0 0 0 0 0 0/600"));
		edits.Add(new StringEdits("Data/ObjectInformation", 226, "Spicy Eelektross/175/46/Cooking -7/Spicy Eelektross/It's really spicy! Be careful./food/0 0 0 0 1 0 0 0 0 1 0/600"));
		edits.Add(new StringEdits("Data/ObjectInformation", 607, "Roasted Chestis/270/70/Cooking -7/Roasted Chestis/The roasting process creates a rich forest flavor./food/0 0 0 0 0 0 0 0 0 0 0/0"));
		edits.Add(new StringEdits("Data/ObjectInformation", 611, "Bluk Cobbler/260/70/Cooking -7/Bluk Cobbler/There's nothing quite like it./food/0 0 0 0 0 0 0 0 0 0 0/0"));
		edits.Add(new StringEdits("Data/ObjectInformation", 729, "Escargot/125/90/Cooking -7/Escargot/Butter-soaked Goomies cooked to perfection./food/0 2 0 0 0 0 0 0 0 0 0/1440"));
		edits.Add(new StringEdits("Data/ObjectInformation", 730, "Corphish Bisque/205/90/Cooking -7/Corphish Bisque/This delicate soup is a secret family recipe of Willy's./food/0 3 0 0 0 0 0 50 0 0 0/1440"));
		edits.Add(new StringEdits("Data/ObjectInformation", 732, "Krabby Cakes/275/90/Cooking -7/Krabby Cakes/Krabby, bread crumbs, and egg formed into patties then fried to a golden brown./food/0 0 0 0 0 0 0 0 0 1 1/1440"));
	}
	private void MiscEdits()
	{
		edits.Add(new StringEdits("Data/ObjectInformation", 442, "Psyduck Egg/95/15/Basic -5/Psyduck Egg/It's still warm."));
		edits.Add(new StringEdits("Data/ObjectInformation", 444, "Psyduck Feather/250/-300/Basic -18/Psyduck Feather/It's so colorful."));
		edits.Add(new StringEdits("Data/ObjectInformation", 307, "Psyduck Mayonnaise/375/-300/Basic -26/Psyduck Mayonnaise/It's a rich, yellow mayonnaise."));
		edits.Add(new StringEdits("Data/ObjectInformation", 16, "Oddish/50/5/Basic -81/Oddish/It may be mistaken for a clump of weeds. If you try to yank it out of the ground, it shrieks horribly."));
		edits.Add(new StringEdits("Data/ObjectInformation", 18, "Jumpluff/30/0/Basic -81/Jumpluff/umpluff drifts around the world with the seasonal winds."));
		edits.Add(new StringEdits("Data/ObjectInformation", 20, "Chikorita/60/16/Basic -81/Chikorita/A sweet aroma gently wafts from the leaf on its head. It is docile and loves to soak up sunrays."));
		edits.Add(new StringEdits("Data/ObjectInformation", 22, "Bellsprout/40/10/Basic -81/Bellsprout/It plants its feet deep underground to replenish water. It can’t escape its enemy while it’s rooted."));
		edits.Add(new StringEdits("Data/ObjectInformation", 24, "Turtwig/35/10/Basic -75/Turtwig/Photosynthesis occurs across its body under the sun. The shell on its back is actually hardened soil."));
		edits.Add(new StringEdits("Data/ObjectInformation", 472, "Turtwig Seeds/10/-300/Seeds -74/Turtwig Seeds/Plant these in the spring. Takes 4 days to mature."));
		edits.Add(new StringEdits("Data/ObjectInformation", 88, "Exeggcute/100/-300/Basic -79/Exeggcute/Even though it appears to be eggs of some sort, it was discovered to be a life-form more like plant seeds."));
		edits.Add(new StringEdits("Data/ObjectInformation", 791, "Exeggcute/100/-300/Basic -79/Exeggcute/Although they are the same size as other Exeggcute, the ones produced in Alola are quite heavy."));
		edits.Add(new StringEdits("Data/ObjectInformation", 905, "Mango Sticky Rice/250/45/Cooking -7/Mango Sticky Rice/Sweet mango and Exeggcute transforms this rice into something very special./food/0 0 0 0 0 0 0 0 0 0 3/430"));
		edits.Add(new StringEdits("Data/ObjectInformation", 90, "Cactus Fruit/75/30/Basic -79/Cacnea/The sweet fruit of the prickly pear cactus."));
		edits.Add(new StringEdits("Data/ObjectInformation", 802, "Cactus Seeds/0/-300/Seeds -74/Cacnea Seeds/Can only be grown indoors. Takes 12 days to mature, and then produces fruit every 3 days."));
		edits.Add(new StringEdits("Data/ObjectInformation", 904, "Nanab/260/50/Cooking -7/Nanab/A creamy dessert with a wonderful tropical flavor./food/0 0 1 0 1 0 0 0 0 0 1/430"));
		edits.Add(new StringEdits("Data/ObjectInformation", 69, "Nanab Sapling/850/-300/Basic -74/Nanab Sapling/Takes 28 days to produce a mature Nanab tree. Bears fruit in the summer, or all year round when planted on Ginger Island."));
		edits.Add(new StringEdits("Data/ObjectInformation", 92, "Nanab/150/30/Basic -79/Nanab/A Berry to be used in cooking. This Berry is very rare and hard to obtain."));
		edits.Add(new StringEdits("Data/ObjectInformation", 309, "Seedot/20/-300/Crafting -74/Seedot/When it dangles from a tree branch, it looks just like an acorn. "));
		edits.Add(new StringEdits("Data/ObjectInformation", 613, "Applin/100/15/Basic -79/Applin/It hides from its natural enemies, bird Pokémon, by pretending it’s just an apple and nothing more."));
		edits.Add(new StringEdits("Data/ObjectInformation", 633, "Applin Sapling/1000/-300/Basic -74/Applin Sapling/Takes 28 days to produce a mature Applin tree. Bears fruit in the fall. Only grows if the 8 surrounding \"tiles\" are empty."));
		edits.Add(new StringEdits("Data/ObjectInformation", 234, "Belueberry Tart/150/50/Cooking -7/Belueberry Tart/It's subtle and refreshing./food/0 0 0 0 0 0 0 0 0 0 0/0"));
		edits.Add(new StringEdits("Data/ObjectInformation", 481, "Belueberry Seeds/40/-300/Seeds -74/Belueberry Seeds/Plant these in the summer. Takes 13 days to mature, and continues to produce after first harvest."));
		edits.Add(new StringEdits("Data/ObjectInformation", 258, "Belueberry/50/10/Basic -79/Belueberry/A popular berry reported to have many health benefits. The blue skin has the highest nutrient concentration."));
		edits.Add(new StringEdits("Data/ObjectInformation", 286, "Cherubi Bomb/50/-300/Crafting -8/Cherubi Bomb/Generates a small explosion. Stand back!"));
		edits.Add(new StringEdits("Data/ObjectInformation", 628, "Cherubi Sapling/850/-300/Basic -74/Cherubi Sapling/Takes 28 days to produce a mature Cherubi tree. Bears fruit in the spring. Only grows if the 8 surrounding \"tiles\" are empty."));
		edits.Add(new StringEdits("Data/ObjectInformation", 638, "Cherubi/80/15/Basic -79/Cherubi/It nimbly dashes about to avoid getting pecked by bird Pokémon that would love to make off with its small, nutrient-rich storage ball."));
		edits.Add(new StringEdits("Data/ObjectInformation", 372, "Shellder/50/-300/Basic -23/Shellder/Its hard shell repels any kind of attack. It is vulnerable only when its shell is open."));
		edits.Add(new StringEdits("Data/ObjectInformation", 404, "Foongus/40/15/Basic -81/Foongus/Slightly nutty, with good texture."));
		edits.Add(new StringEdits("Data/ObjectInformation", 393, "Corsola/80/-300/Basic -23/Corsola/In a south-sea nation, the people live in communities that are built on groups of these Pokémon."));
		edits.Add(new StringEdits("Data/ObjectInformation", 717, "Krabby/100/-300/Fish -4/Krabby/Its pincers are not only powerful weapons, they are used for balance when walking sideways./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 710, "Krabby Pot/50/-300/Crafting/Krabby Pot/Place it in the water, load it with bait, and check the next day to see if you've caught anything. Works in streams, lakes, and the ocean."));
		edits.Add(new StringEdits("Data/ObjectInformation", 732, "Krabby Cakes/275/90/Cooking -7/Krabby Cakes/Krabby, bread crumbs, and egg formed into patties then fried to a golden brown./food/0 0 0 0 0 0 0 0 0 1 1/1440"));
		edits.Add(new StringEdits("Data/ObjectInformation", 716, "Clauncher/75/-300/Fish -4/Clauncher/They knock down flying prey by firing compressed water from their massive claws like shooting a pistol./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 772, "Oil of Peilil/1000/80/Cooking -7/Oil of Peilil/Drink this and weaker monsters will avoid you./drink/0 0 0 0 0 0 0 0 0 0 0/0"));
		edits.Add(new StringEdits("Data/ObjectInformation", 748, "Peilil/60/8/Basic -75/Peilil/Some say if you dry the leaves on its head, boil them down, and drink the infusion, your vigor will return, so Petilil is popular with the elderly."));
		edits.Add(new StringEdits("Data/ObjectInformation", 260, "Spelonberry/40/5/Basic -79/Spelonberry/Can be ground up into a powder as an ingredient for medicine."));
		edits.Add(new StringEdits("Data/ObjectInformation", 482, "Spelonberry Seeds/20/-300/Seeds -74/Spelonberry Seeds/Plant these in the summer. Takes 5 days to mature, and continues to produce after first harvest."));
		edits.Add(new StringEdits("Data/ObjectInformation", 715, "Corphish/120/-300/Fish -4/Corphish/Its hardy vitality enables it to adapt to any environment. Its pincers will never release prey./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 254, "Watmel/250/45/Basic -79/Watmel/A cool, sweet summer treat."));
		edits.Add(new StringEdits("Data/ObjectInformation", 479, "Watmel Seeds/40/-300/Seeds -74/Watmel Seeds/Plant these in the summer. Takes 12 days to mature."));
		edits.Add(new StringEdits("Data/ObjectInformation", 257, "Morelull/150/8/Basic -81/Morelull/Sought after for its unique nutty flavor."));
		edits.Add(new StringEdits("Data/ObjectInformation", 719, "Clamperl/30/-300/Fish -4/Clamperl/It clamps down on its prey with both sides of its shell and doesn’t let go until they stop moving./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 392, "Omanyte/120/-300/Basic -23/Omanyte/Omanyte is one of the ancient and long-since-extinct Pokémon that have been regenerated from fossils by people."));
		edits.Add(new StringEdits("Data/ObjectInformation", 586, "Omanyte Fossil/80/-300/Arch/Omanyte Fossil/This must've washed up ages ago from an ancient coral reef. /Beach .03"));
		edits.Add(new StringEdits("Data/ObjectInformation", 635, "Oranberry/100/15/Basic -79/Oranberry/Juicy, tangy, and bursting with sweet summer aroma."));
		edits.Add(new StringEdits("Data/ObjectInformation", 630, "Oranberry Sapling/1000/-300/Basic -74/Oranberry Sapling/Takes 28 days to produce a mature Orange tree. Bears fruit in the summer. Only grows if the 8 surrounding \"tiles\" are empty."));
		edits.Add(new StringEdits("Data/ObjectInformation", 723, "Forretress/40/-300/Fish -4/Forretress/	It is encased in a steel shell. Its peering eyes are all that can be seen of its mysterious innards./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 636, "Pechaberry/140/15/Basic -79/Pechaberry/It's almost fuzzy to the touch."));
		edits.Add(new StringEdits("Data/ObjectInformation", 631, "Pechaberry Sapling/1500/-300/Basic -74/Pechaberry Sapling/Takes 28 days to produce a mature Pechaberry tree. Bears fruit in the summer. Only grows if the 8 surrounding \"tiles\" are empty."));
		edits.Add(new StringEdits("Data/ObjectInformation", 722, "Shellos/20/-300/Fish -4/Shellos/There's speculation that its appearance is determined by what it eats, but the truth remains elusive./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 311, "Pineco/5/-300/Crafting -74/Pineco/Pineco hangs from a tree branch and patiently waits for prey to come along."));
		edits.Add(new StringEdits("Data/ObjectInformation", 397, "Pincurchin/160/-300/Basic -23/Pincurchin/A slow-moving, spiny creature that some consider a delicacy."));
		edits.Add(new StringEdits("Data/ObjectInformation", 721, "Goomy/65/-300/Fish -4/Goomy/It's covered in a slimy membrane that makes any punches or kicks slide off it harmlessly./Day^Spring Summer"));
		edits.Add(new StringEdits("Data/ObjectInformation", 729, "Escargot/125/90/Cooking -7/Escargot/Butter-soaked Goomies cooked to perfection./food/0 2 0 0 0 0 0 0 0 0 0/1440"));
		edits.Add(new StringEdits("Data/ObjectInformation", 421, "Sunflora/80/18/Basic -80/Sunflora/A common misconception is that the flower turns so it's always facing the sun."));
		edits.Add(new StringEdits("Data/ObjectInformation", 431, "Sunflora Seeds/20/-300/Seeds -74/Sunflora Seeds/Plant in summer or fall. Takes 8 days to produce a large Sunflora. Yields more seeds at harvest."));
		edits.Add(new StringEdits("Data/ObjectInformation", 480, "Tamatoberry Seeds/25/-300/Seeds -74/Tamatoberry Seeds/Plant these in the summer. Takes 11 days to mature, and continues to produce after first harvest."));
		edits.Add(new StringEdits("Data/ObjectInformation", 618, "Bruschetta/210/45/Cooking -7/Bruschetta/Roasted Tamatoberryes on a crisp white bread./food/0 0 0 0 0 0 0 0 0 0 0/0"));
		edits.Add(new StringEdits("Data/ObjectInformation", 865, "Gourmet Tamatoberry Salt/0/-300/Quest/Gourmet Tamatoberry Salt/A rare, delicious and savory salt."));
		edits.Add(new StringEdits("Data/ObjectInformation", 257, "Tamatoberry/60/8/Basic -75/Tamatoberry/Rich and slightly tangy, the Tamatoberry has a wide variety of culinary uses."));
		edits.Add(new StringEdits("Data/ObjectInformation", 272, "Eggplant/60/8/Basic -75/Eggplant/A rich and wholesome relative of the Tamatoberry. Delicious fried or stewed."));
		edits.Add(new StringEdits("Data/ObjectInformation", 430, "Shroomish/625/5/Basic -17/Shroomish/Shroomish live in damp soil in the dark depths of forests. They are often found keeping still under fallen leaves. This Pokémon feeds on compost that is made up of fallen, rotted leaves."));
		edits.Add(new StringEdits("Data/ObjectInformation", 432, "Shroomish Oil/1065/15/Basic -26/Shroomish Oil/A gourmet cooking ingredient./drink/0 0 0 0 0 0 0 0 0 0 0/0"));
		edits.Add(new StringEdits("Data/ObjectInformation", 604, "Lumberry Pudding/260/70/Cooking -7/Lumberry Pudding/A traditional holiday treat./food/0 0 0 0 0 0 0 0 0 0 0/0"));
		edits.Add(new StringEdits("Data/ObjectInformation", 406, "Wild Lumberry/80/10/Basic -79/Wild Lumberry/Tart and juicy with a pungent aroma."));
		edits.Add(new StringEdits("Data/ObjectInformation", 629, "Apicotberry Sapling/500/-300/Basic -74/Apicotberry Sapling/Takes 28 days to produce a mature Apicotberry tree. Bears fruit in the spring. Only grows if the 8 surrounding \"tiles\" are empty."));
		edits.Add(new StringEdits("Data/ObjectInformation", 634, "Apicotberry/50/15/Basic -79/Apicotberry/A tender little fruit with a rock-hard pit."));
		edits.Add(new StringEdits("Data/ObjectInformation", 116, "Staryu/40/-300/Arch/Staryu/	It appears in large numbers by seashores. At night, its central core flashes with a red light./Beach .1/Money 1 200"));

	}
	public EditStrings(IModHelper helper)
	{
		modHelper = helper;
		SetupEdits();
	}
	public bool CanEdit<T>(IAssetInfo asset)
	{
		if (GetReplacer(asset.Name.Name) != null)
		{
			return true;
		}
		return false;
	}
	public void Edit<T>(IAssetData asset)
	{				
		EditWithIntKeys(asset);		
	}
	private void EditWithIntKeys(IAssetData asset)
    {
		StringEdits currentAsset = GetReplacer(asset.Name.Name);
		if (currentAsset != null)
		{
			var data = asset.AsDictionary<int, string>().Data;
			if (data != null)
			{
				foreach (StringEdits i in edits)
				{
					if (i != null)
					{
						if (i.indexString != null)
						{
							data[i.index] = i.stringEdit;
						}
					}
				}
			}
		}
	}

	private void EditWithStringKeys(IAssetData asset)
    {
		StringEdits currentAsset = GetReplacer(asset.Name.Name);
		if (currentAsset != null)
		{
			var stringData = asset.AsDictionary<string, string>().Data;
			if (stringData != null)
			{
				foreach (StringEdits i in stringKeys)
				{
					if (i != null)
					{
						stringData[i.indexString] = i.indexString;
					}
				}
			}
		}
	}
	private StringEdits GetReplacer(string name)
	{
		foreach (StringEdits i in edits)
		{
			if (i != null && i.assetName == name)
			{
				return i;
			}
		}

		return null;
	}
}