using Microsoft.Xna.Framework.Audio;
using StardewValley;
using System.IO;
using StardewModdingAPI;

public class SoundPlayer
{
    private static bool soundsLoaded { get; set; }
    private static IModHelper helper;
	public SoundPlayer(IModHelper _helper)
	{
        helper = _helper;
        LoadSound("Duck", "Psyduck.wav");
        LoadSound("cacklingWitch", "Mismagius.wav");
        LoadSound("crow", "Murkrow.wav");
        LoadSound("ghost", "Gastly.wav");
        LoadSound("junimoMeep1", "Castform.wav");
        LoadSound("monkey1", "Monferno.wav");
        LoadSound("owl", "Noctowl.wav");
        LoadSound("parrot", "Chatot.wav");
        LoadSound("seagulls", "Wingull.wav");
        LoadSound("squid_hit", "Voltorb.wav");
    }

	private static void LoadSound(string audioName, string audioFile)
	{
        // Get the cue to manipulate.
        var existingCueDef = Game1.soundBank.GetCueDefinition(audioName);

        // Get the audio file and add it to a new SoundEffect, to replace the old one.
        SoundEffect audio;

        if (audioFile == "")
        {
            audio = null;
        }
        else
        {
            string filePathCombined = Path.Combine(helper.DirectoryPath, "assets/audio", audioFile);
            using (var stream = new FileStream(filePathCombined, FileMode.Open))
            {
                audio = SoundEffect.FromStream(stream);
            }
        }
        // Assign the new audio to this cue.
        existingCueDef.SetSound(audio, Game1.audioEngine.GetCategoryIndex("Sound"), false);
    }
	

}
