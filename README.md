# Static FOV

A BepInEx mod for Mycopunk that lets you disable aim FOV zoom and all temporary additive FOV punches independently.

## Features

- **Aim FOV Change**: Toggle the FOV zoom that normally happens when aiming. When disabled, aiming no longer zooms the camera FOV.
- **Additive FOV Change**: Toggle all temporary FOV punches that go through `PlayerLook.AddFOV` (sprint, melee, air dash, blink, FOV bursts, and similar). When disabled, those effects no longer alter FOV.

Both options default to **disabled** (stable FOV). Set either to `true` in the config if you want vanilla behavior for that path.

## Getting Started

### Dependencies

* Mycopunk (base game)
* [BepInEx](https://github.com/BepInEx/BepInEx) - Version 5.4.2403 or compatible (BepInExPack_Mycopunk)
* .NET Framework 4.8
* HarmonyLib (included via NuGet / BepInEx)

### Building/Compiling

1. Clone this repository
2. Open the solution file in Visual Studio, Rider, or your preferred C# IDE
3. Build the project in Release mode to generate the `.dll` file

Alternatively, use the dotnet CLI:

```bash
dotnet build --configuration Release
```

### Installing

**Via Thunderstore (Recommended)**:
1. Download and install via Thunderstore Mod Manager / r2modman
2. The mod will be installed to the correct directory automatically

**Manual Installation**:
1. Place the built `StaticFOV.dll` in your `<Mycopunk Directory>/BepInEx/plugins/` folder

### Executing

The mod loads automatically through BepInEx when the game starts. Check the BepInEx console for a load confirmation message.

## Configuration

Settings are stored at:

`<Mycopunk Directory>/BepInEx/config/sparroh.staticfov.cfg`

| Setting | Default | Description |
|---------|---------|-------------|
| Aim FOV Change | `false` | Enables FOV zoom when aiming |
| Additive FOV Change | `false` | Enables temporary FOV punches (sprint, melee, dash, blink, bursts, etc.) |

Config changes are reloaded when the config file is updated.

**Note:** Aim zoom does not use `AddFOV`; it is controlled only by **Aim FOV Change**. Additive punches are controlled only by **Additive FOV Change**.

## Help

* **Mod not loading?** Verify BepInEx is installed correctly and check console logs for errors
* **FOV still changing?** Confirm the relevant config option is set to `false` and that the config file was reloaded
* **Conflicts?** Other camera/FOV mods may override or fight these patches

## Authors

- Sparroh

## License

This project is licensed under the MIT License - see the LICENSE file for details
