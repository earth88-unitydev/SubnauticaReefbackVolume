using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Nautilus.Handlers;


namespace earth88.ReefbackVolumeControl
{

    [BepInPlugin(MyGuid, PluginName, VersionString)]
    [BepInDependency("com.snmodding.nautilus")]
    public class ReefbackVolumePlugin : BaseUnityPlugin
    {
        private const string MyGuid = "com.earth88.ReefbackVolumePlugin";
        private const string PluginName = "Reefback Volume Control";
        private const string VersionString = "1.0.0";

        private static readonly Harmony Harmony = new Harmony(MyGuid);
        public static ManualLogSource Log;
        public static ModOptions ModOptions;
        private void Awake()
        {
            ModOptions = OptionsPanelHandler.RegisterModOptions<ModOptions>();
            Harmony.PatchAll();
            Logger.LogInfo($"{PluginName} {VersionString} Loaded.");
        }
    }
}
