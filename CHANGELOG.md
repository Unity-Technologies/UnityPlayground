# Changelog
All notable changes to this package are documented in this file.

## [1.8.0] - 2026-05-01
### Changed
- Downgraded the project back to Unity 6.0, to ensure it's compatible with 6.0, 6.1, etc. (tested until 6.3 LTS).
- Changed input handling from the old Input Manager to the Input System package.

### Fixed
- Fixed an issue where the sprites would show with the wrong Z-sorting.
- Fixed text not appearing for dialogues and resources in the inventory.
- Fixed ConditionRepeat to work well even with object spawned after game starts (Community PR).

## [1.7]
### Changed
- Updated to 6000.3.0f1 LTS.

## [1.6]
### Changed
- Made compatible with URP.
- Updated Github branch.

### Fixed
- Fixed dropdown bug in inspector.
- Fixed wording for movement inputs in inspector.

## [1.5]
### Changed
- Updated to 2022.2
- Varela Font removed for simplicity.
- Changed from Gamma to Linear color space due to SRGB textures.

## [1.4]
### Changed
- Updated to 2021.3
- Asset includes 3rd party component Varela Font under included OFL 1.1 license.

## [1.3]
### Changed
- Updated to 2019.4.

## [1.0] - 2018-12-13
### Added
- Original Asset Store release.