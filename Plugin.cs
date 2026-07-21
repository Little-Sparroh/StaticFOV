using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using Pigeon.Movement;
using System;
using System.IO;
using System.Reflection;

[BepInPlugin(PluginGUID, PluginName, PluginVersion)]

[MycoMod(null, ModFlags.IsClientSide)]
public class SparrohPlugin : BaseUnityPlugin
{
    public const string PluginGUID = "sparroh.staticfov";
    public const string PluginName = "StaticFOV";
    public const string PluginVersion = "1.2.0";

    internal static new ManualLogSource Logger;

    internal static ConfigEntry<bool> aimFOVChange;
    internal static ConfigEntry<bool> additiveFOVChange;

    private FileSystemWatcher configWatcher;

    internal static MethodInfo defaultFOVGetter;
    internal static FieldInfo isAimingPLField;
    internal static FieldInfo fovField;
    internal static FieldInfo aimFOVPLField;
    internal static FieldInfo aimDurationPLField;
    internal static FieldInfo aimStateChangeTimeField;

    internal static SparrohPlugin Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        Logger = base.Logger;

        aimFOVChange = Config.Bind(
            "General",
            "Aim FOV Change",
            false,
            "If true, enables FOV zoom changes when aiming.");

        additiveFOVChange = Config.Bind(
            "General",
            "Additive FOV Change",
            false,
            "If true, enables temporary FOV punches from AddFOV (sprint, melee, dash, blink, FOV bursts, etc.). If false, all additive FOV changes are blocked.");

        try
        {
            SetupFileWatcher();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error setting up file watcher: {ex.Message}");
        }

        try
        {
            SetupAccessTools();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error setting up access tools: {ex.Message}");
        }

        try
        {
            var harmony = new Harmony(PluginGUID);
            harmony.PatchAll(typeof(AimFOVPatches));
            harmony.PatchAll(typeof(AdditiveFOVPatches));
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error applying patches: {ex.Message}");
        }

        Logger.LogInfo($"{PluginName} v{PluginVersion} loaded. Aim FOV={aimFOVChange.Value}, Additive FOV={additiveFOVChange.Value}");
    }

    private void SetupFileWatcher()
    {
        configWatcher = new FileSystemWatcher(Paths.ConfigPath, $"{PluginGUID}.cfg");
        configWatcher.Changed += (s, e) => { Config.Reload(); };
        configWatcher.EnableRaisingEvents = true;
    }

    private void SetupAccessTools()
    {
        defaultFOVGetter = AccessTools.PropertyGetter(typeof(PlayerLook), "DefaultFOV");
        isAimingPLField = AccessTools.Field(typeof(PlayerLook), "isAiming");
        fovField = AccessTools.Field(typeof(PlayerLook), "_fov");
        aimFOVPLField = AccessTools.Field(typeof(PlayerLook), "aimFOV");
        aimDurationPLField = AccessTools.Field(typeof(PlayerLook), "aimDuration");
        aimStateChangeTimeField = AccessTools.Field(typeof(PlayerLook), "aimStateChangeTime");
    }

    private void OnDestroy()
    {
        if (configWatcher != null)
        {
            configWatcher.EnableRaisingEvents = false;
            configWatcher.Dispose();
        }
    }
}
