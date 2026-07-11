# Changelog

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
