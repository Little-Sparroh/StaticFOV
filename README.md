# FOV Toggles

A BepInEx mod for Mycopunk that lets you independently enable or disable aim FOV zoom and sprint FOV changes.

## Features

- **Aim FOV Change**: Toggle the FOV zoom that normally happens when aiming. When disabled, aiming no longer zooms the camera FOV.
- **Sprint FOV Change**: Toggle the FOV punch that normally happens while sprinting. When disabled, sprinting no longer alters FOV.

Both options default to **enabled** (vanilla behavior). Turn either off in the config if you prefer a stable FOV.

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
1. Place the built `FOVToggles.dll` in your `<Mycopunk Directory>/BepInEx/plugins/` folder

### Executing

The mod loads automatically through BepInEx when the game starts. Check the BepInEx console for a load confirmation message.

## Configuration

Settings are stored at:

`<Mycopunk Directory>/BepInEx/config/sparroh.fovtoggles.cfg`

| Setting | Default | Description |
|---------|---------|-------------|
| Aim FOV Change | `true` | Enables FOV zoom when aiming |
| Sprint FOV Change | `true` | Enables FOV changes while sprinting |

Config changes are reloaded when the config file is updated.

## Help

* **Mod not loading?** Verify BepInEx is installed correctly and check console logs for errors
* **FOV still changing?** Confirm the relevant config option is set to `false` and that the config file was reloaded
* **Conflicts?** Other camera/FOV mods may override or fight these patches

## Authors

- Sparroh

## License

This project is licensed under the MIT License - see the LICENSE file for details
