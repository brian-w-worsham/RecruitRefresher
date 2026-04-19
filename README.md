# Recruit Refresher — Bannerlord Mod

Never worry about recruits again! This mod ensures that towns and villages automatically refill their available recruits to maximum capacity every day, making it much easier to recruit soldiers for your army.

## What This Mod Changes

- **Towns and Villages Daily Refresh**: Every day, all settlements (towns and villages) will have their available recruits automatically refilled to maximum capacity.
- **No Configuration Required**: Enable the mod and start playing. It works automatically.
- **Full Volunteer Slots**: Notables in towns and villages are topped up so all recruit slots are available each daily refresh.

## What This Mod Does Not Change

- Does not affect party composition, morale, or any other gameplay systems.
- Does not change the base recruitment mechanics or troop tier progression.
- Does not affect companion recruitment or noble recruitment.
- Works alongside other mods that don't directly conflict with recruitment systems.

## Features

- **Automatic Daily Refresh**: Recruits are replenished every day cycle.
- **Vanilla-Compatible Recruit Types**: Uses Bannerlord's volunteer model for the notable's basic volunteer troop type.
- **Zero Configuration**: No settings to adjust - enable and play.
- **Works in Campaign and Sandbox**: Compatible with all game modes.
- **Harmony Patching**: Uses minimal, safe patches to integrate with the game.

## Prerequisites

- Mount & Blade II: Bannerlord (Steam)
- .NET Framework 4.7.2 targeting pack
- Visual Studio 2022 or .NET SDK (for building)

## Project Structure

```text
RecruitRefresher/
├── RecruitRefresher.sln
├── deploy.ps1
├── README.md
├── copilot-instructions.md
├── Module/
│   └── SubModule.xml
├── src/
│   └── RecruitRefresher/
│       ├── RecruitRefresher.csproj
│       ├── RecruitRefresherLogic.cs
│       ├── RecruitVolunteerRuntime.cs
│       ├── SubModule.cs
│       └── Patches/
│           └── RecruitmentCampaignBehaviorPatch.cs
└── tests/
    └── RecruitRefresher.Tests/
        ├── RecruitRefresher.Tests.csproj
        ├── RecruitRefresherLogicTests.cs
      ├── RecruitVolunteerRuntimeTests.cs
      ├── RecruitmentCampaignBehaviorPatchTests.cs
        └── SubModuleTests.cs
```

## Build

```powershell
dotnet build src\RecruitRefresher\RecruitRefresher.csproj -c Release
```

Or with a custom game path:

```powershell
dotnet build src\RecruitRefresher\RecruitRefresher.csproj -c Release -p:GameFolder="D:\SteamLibrary\steamapps\common\Mount & Blade II Bannerlord"
```

## Run Tests

```powershell
dotnet test tests\RecruitRefresher.Tests\RecruitRefresher.Tests.csproj
```

## Deploy

```powershell
.\deploy.ps1
```

Or with a custom game path:

```powershell
.\deploy.ps1 -GameFolder "D:\SteamLibrary\steamapps\common\Mount & Blade II Bannerlord"
```

## Player Installation

1. Download or build the mod.
2. Copy the `RecruitRefresher` folder to `<Bannerlord>\Modules\`.
3. Make sure the folder structure is:
   - `RecruitRefresher\Module\SubModule.xml`
   - `RecruitRefresher\bin\Win64_Shipping_Client\RecruitRefresher.dll`
   - `RecruitRefresher\bin\Win64_Shipping_Client\0Harmony.dll`
4. Open the Bannerlord launcher.
5. Enable **Recruit Refresher** in the mod list.
6. Start or load a campaign save.

## How to Verify the Mod Is Working

1. **Enable the mod** and start a campaign (or load an existing save).
2. **Open a town or village** (visit the recruitment screen).
3. **Check the available recruits** for that settlement.
4. **Wait 1 in-game day** (advance time using the map).
5. **Return to the same settlement** and visit recruitment again.
6. **Verify that recruits refill to full slots**: If you previously hired available troops from a notable, those empty recruit slots should be refilled after the daily tick.
7. **Check different settlement types**:
   - **Towns** should have notables with all recruit slots available after daily refresh.
   - **Villages** should also refill notable recruit slots daily.

### What to Look For

- The green notification message when loading the game: "**Recruit Refresher: Loaded successfully.**"
- Recruits replenishing after 1 in-game day cycle.
- Consistent availability across all settlements you visit.
- If you fully recruit from a notable and wait one day, that notable has recruits again.

## Settings

This mod has **no settings file** and no in-game configuration menu. Once enabled, it is always active and operates automatically.

## Compatibility

- **Compatible with most other mods** that don't directly override settlement recruitment or daily tick behavior.
- **May conflict with**: Other recruitment overhaul mods, settlement population mods, or mods that change daily settlement ticks.
- **Tested with**: Base Bannerlord v1.0+

## Support

If you encounter any issues:

1. Verify the mod is enabled in the launcher.
2. Check that all required files are in the correct locations.
3. Ensure no conflicting mods are enabled.
4. Delete the `bin\` and `obj\` folders and rebuild if modifying source code.

## License

This mod is provided as-is for personal use. Feel free to modify it for your own needs.

---

Enjoy unlimited recruits and never worry about settlement recruitment again!
