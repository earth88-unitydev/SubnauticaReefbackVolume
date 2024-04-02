using Nautilus.Json;
using Nautilus.Options.Attributes;

namespace earth88.ReefbackVolumeControl
{
    [Menu("Creature Volume Control")]
    public class ModOptions : ConfigFile
    {
        [Slider("Reefback Volume", 0f, 100f, DefaultValue = 100f, Step = 1f, Format = "{0:F2}")]
        public float Volume = 100;
        
    }
}