using HarmonyLib;
using Pigeon.Movement;

[HarmonyPatch]
public static class AdditiveFOVPatches
{
    [HarmonyPatch(typeof(PlayerLook), nameof(PlayerLook.AddFOV))]
    [HarmonyPrefix]
    public static bool AddFOVPrefix()
    {
        // When disabled, block every temporary FOV punch (sprint, melee, dash, blink, FOV bursts, etc.).
        return SparrohPlugin.additiveFOVChange == null || SparrohPlugin.additiveFOVChange.Value;
    }
}
