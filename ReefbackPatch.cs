using HarmonyLib;
using UnityEngine;

namespace earth88.ReefbackVolumeControl
{
    [HarmonyPatch(typeof(Creature))]
    internal class PatchCreatures
    {
        [HarmonyPatch(nameof(Creature.OnEnable))]
        [HarmonyPostfix]
        public static void OnEnableCreature_Postfix(Creature __instance)
        {
            if(__instance.GetType() == typeof(Reefback) && __instance.gameObject.GetComponent<ReefbackHook>() == null)
            {
                __instance.gameObject.AddComponent<ReefbackHook>();
                Debug.Log("Reefback loaded and hooked");
            }
        }
    }

    public class ReefbackHook : MonoBehaviour
    {
        float lastVol;
        ModOptions modops = ReefbackVolumePlugin.ModOptions;
        void Update()
        {
            if (modops.Volume != lastVol)
            {
                Reefback reefcomp = gameObject.GetComponent<Reefback>();
                float currentVol = modops.Volume;
                reefcomp.gameObject.GetComponent<FMOD_CustomLoopingEmitter>().GetEventInstance().setVolume(currentVol * 0.01f);
                lastVol = currentVol;
            }
        }
    }
}


