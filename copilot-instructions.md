# Copilot Instructions

This project is a Bannerlord singleplayer Harmony mod targeting .NET Framework 4.7.2.

## Goals

- Automatically refill recruits in towns and villages every day to maximum capacity.
- Make recruit availability predictable and abundant without breaking game balance.
- Maintain compatibility with campaign and sandbox gameplay.

## Project Conventions

- Keep source in `src/RecruitRefresher/`.
- Keep tests in `tests/RecruitRefresher.Tests/`.
- Use `internal` for test-targeted helpers and expose internals via `InternalsVisibleTo`.
- Favor small pure helper methods for logic that should be unit-tested.
- Keep patch classes in the `Patches` folder.

## Patch Safety Rules

- Patch `DefaultVolunteerModel.GetDailyVolunteerProductionProbability(Hero, int, Settlement)` to guarantee daily volunteer production.
- Patch `DefaultVolunteerModel.MaximumIndexHeroCanRecruitFromHero(Hero, Hero, int)` for player-only full recruit-slot access.
- Patch only `RecruitmentCampaignBehavior.UpdateVolunteersOfNotablesInSettlement(Settlement)`.
- Use a Postfix patch to top up any remaining empty volunteer slots after vanilla updates.
- Register `RecruitRefresherBehavior` on campaign start as a public-event fallback through `DailyTickSettlementEvent`.
- Do not modify recruitment costs, troop availability logic, or party mechanics.
- Preserve vanilla volunteer generation and upgrade behavior.
- Do not add save-data format changes.

## Recruitment Logic Rules

- **Town Recruits**: Base 10 + Prosperity / 500 (helper method).
- **Village Recruits**: Base 5 + Hearth / 100, capped at 20.
- Ensure values are reasonable and don't unbalance game economy.
- Volunteer slot filling happens in `RecruitVolunteerRuntime`.
- Volunteer model overrides live in `VolunteerModelRuntime`.

## Build and Test

- Build: `dotnet build src/RecruitRefresher/RecruitRefresher.csproj -c Release`
- Test: `dotnet test tests/RecruitRefresher.Tests/RecruitRefresher.Tests.csproj`
- Deploy: `./deploy.ps1`

## Deploy Expectations

- Deployment target: `<Bannerlord>/Modules/RecruitRefresher/`
- Required outputs:
  - `Module/SubModule.xml`
  - `bin/Win64_Shipping_Client/RecruitRefresher.dll`
  - `bin/Win64_Shipping_Client/0Harmony.dll`

## Testing Strategy

- Test all core logic methods in `RecruitRefresherLogicTests.cs`.
- Test public behavior hook behavior in `RecruitRefresherBehaviorTests.cs`.
- Test runtime slot-fill behavior in `RecruitVolunteerRuntimeTests.cs`.
- Test volunteer model override behavior in `VolunteerModelRuntimeTests.cs`.
- Test patch delegate/hook behavior in `RecruitmentCampaignBehaviorPatchTests.cs`.
- Test module initialization in `SubModuleTests.cs`.
- Prefer pure helper and delegate-injection tests when direct game objects are difficult to construct.
- Aim for >80% code coverage on core logic.

## Known Limitations

- Patch target names may need updates if Bannerlord internal method names/signatures change.
- The mod will be tested with Bannerlord v1.0+.

## Code Style

- Use C# 9.0 features where applicable.
- Add XML documentation comments to all public methods and classes.
- Keep methods small and focused on a single responsibility.
- Use descriptive variable names and comments for complex logic.
