# Changelog

## 1.2.0

- Replaced sprint-only FOV toggle with **Additive FOV Change**
- Blocking additive FOV now stops all `PlayerLook.AddFOV` punches (sprint, melee, dash, blink, FOV bursts, etc.)
- Kept independent **Aim FOV Change** toggle (aim zoom does not use AddFOV)
- Simplified AddFOV patch (no stack-trace filtering)

## 1.1.0

- Initial release
- Toggle aim FOV zoom on/off
- Toggle sprint FOV changes on/off

1.0.1 (2025-10-07)
Added

    FOV disable functionality - removes zoom when aiming to reduce claustrophobia
    Harmony patches for PlayerLook.UpdateAiming and UpdateCameraFOV methods
    Configurable toggle to enable/disable FOV changes when aiming

1.0.0 (2025-10-16)
Features

    Disabled FOV zoom when sprinting to reduce motion sickness
    Essential for comfortable gameplay in fast-paced action
    Automatic detection of sprint-related FOV changes
    Stack trace inspection to prevent sprint-specific zoom

Tech

    Add MinVer
    Add thunderstore.toml for tcli
    Add LICENSE and CHANGELOG.md
