using HarmonyLib;
using XRL.World;
using XRL.World.Parts.Mutation;

namespace LocalMods
{
    [HarmonyPatch]
    public static class DisableSpacetimeVortex
    {
        [HarmonyPatch(typeof(SpacetimeVortex))]
        [HarmonyPatch("FireEvent")]
        static bool Prefix(SpacetimeVortex __instance, ref bool __result, Event E)
        {
            if (E.ID == "CommandSpaceTimeVortex")
            {
                // Allow player to use it
                if (__instance.ParentObject != null && __instance.ParentObject.IsPlayer())
                {
                    return true; // Continue to original
                }

                // Block NPCs
                __result = true;
                return false;
            }
            return true;
        }
    }
}
