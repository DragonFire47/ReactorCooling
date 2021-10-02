using HarmonyLib;
using UnityEngine;

namespace ReactorCooling
{
    [HarmonyPatch(typeof(PLAntiFireGrenadeInstance), "Explode")]
    class GrenadeExplode
    {
        private static void Prefix(PLAntiFireGrenadeInstance __instance, ref float ___m_FirefightingEffect_Strength)
        {
            if (__instance.MyTLI != null && __instance.MyTLI.MyShipInfo != null)
            {
                if (__instance.MyTLI.MyShipInfo.ReactorInstance != null)
                {
                    float sqrMagnitude2 = (__instance.MyTLI.MyShipInfo.ReactorInstance.transform.position - __instance.transform.position).sqrMagnitude;
                    if (sqrMagnitude2 < 18f)
                    {
                        __instance.MyTLI.MyShipInfo.MyStats.ReactorTempCurrent -= 150f * ___m_FirefightingEffect_Strength;
                    }
                }
            }
        }
    }
    [HarmonyPatch(typeof(PLAntiFireGrenadeInstance), "Update")]
    class GrenadePassive
    {
        private static void Prefix(PLAntiFireGrenadeInstance __instance, ref float ___m_FirefightingEffect_Strength)
        {
            if (__instance.MyTLI != null && __instance.MyTLI.MyShipInfo != null)
            {
                if (__instance.MyTLI.MyShipInfo.ReactorInstance != null)
                {
                    float sqrMagnitude2 = (__instance.MyTLI.MyShipInfo.ReactorInstance.transform.position - __instance.transform.position).sqrMagnitude;
                    if (sqrMagnitude2 < 18f)
                    {
                        __instance.MyTLI.MyShipInfo.MyStats.ReactorTempCurrent -= Time.deltaTime * 15f * ___m_FirefightingEffect_Strength;
                    }
                }
            }
        }
    }
}
