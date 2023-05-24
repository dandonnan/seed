# Changelog

## [Unreleased]

## [0.0.1 - 2023-05-24]

### Added

#### Editor
- Tool to generate Materials from textures that are highlighted in the main Unity window

#### Runtime
- Addressable Catalogue for loading addressable assets and creating GameObjects with them
- CollidedWithPlayer extension method to return whether the collider belonged to an object with the Player tag
- ToColor extension method for turning Seed's controller colours into Unity colours
- GetRandom extension method for getting a random item from a list
- WasPressedThisFrame extension method for getting a Vector2 as an output
- WasCapturedThisFrame extension method for capturing input when checking it has occurred
- ToVector3 and ToQuaternion extension methods for creating the respective objects from a string
- FileParser to load files
- Controller icons
- InputActions file with actions for most controller buttons
- InputManager to handle and query input from the InputActions
- Functionality to quickly create menus, in list or shelf format using MenuListBuilder or MenuShelfBuilder
- Functionality to quickly create options menus using OptionsMenuListBuilder
- FormattedString script to provide a localised string and replace placeholder values
- Translations functionality to get localised string from a string table
- ControllerIcon script which displays an icon that changes depending on the input
- ControllerIconLibrary to get controller icons based on input (comes with an IconLibrary prefab)

Additionally there are ControllerIconText, Modals and UIManager, but these are still yet to be sorted for general use.