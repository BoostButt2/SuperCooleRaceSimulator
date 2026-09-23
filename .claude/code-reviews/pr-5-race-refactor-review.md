# Code Review: PR #5 — some-test-branch-claude-skill → master

https://github.com/BoostButt2/SuperCooleRaceSimulator/pull/5

**Stats:**

- Files Modified: 2 (`Controller/Race.cs`, `SuperCooleRace/Visualisation.cs`)
- Files Added: 3 (`.claude/skills/SKILL.md`, `.mcp.json`, `ControllerTest/RaceShould.cs`)
- Files Deleted: 0
- New lines: 604
- Deleted lines: 276

## Issues

```
severity: critical
file: RaceTrackMooi/VisualisationMooi.cs
line: 118 (and ~30 more call sites throughout the file)
issue: References to Data.CurrentRace._positions no longer compile
detail: Controller/Race.cs renames the public field `_positions` to the property `Positions`
  in this PR. RaceTrackMooi/VisualisationMooi.cs is not touched by this PR and still uses
  `Data.CurrentRace._positions[...]` at dozens of call sites (e.g. inside PlaatsLinks,
  PlaatsRechts, PlaatsBeide, and every SectionType branch of DrawTrack). This is a member that
  no longer exists on Race, so RaceTrackMooi will fail to compile.
suggestion: Rename every `_positions` reference in VisualisationMooi.cs to `Positions`, or keep
  a temporary internal alias while this rename lands, in the same commit as the Race.cs rename.
```

```
severity: critical
file: RaceTrackMooi/DataContext.cs
line: 29
issue: Data.CurrentRace.Driverschanged no longer compiles
detail: Controller/Race.cs renames the event `Driverschanged` to `DriversChanged`. This file
  (untouched by the PR) still subscribes with `Data.CurrentRace.Driverschanged += DataChanged;`.
  RaceTrackMooi/MainWindow.xaml.cs:52 has the identical problem
  (`Data.CurrentRace.Driverschanged += AnEventHandler;`).
suggestion: Update both call sites to `DriversChanged` in this PR.
```

```
severity: critical
file: ControllerTest/Model_Competition_NextTrackShould.cs
line: 97
issue: Data.CurrentRace.getEindstand() no longer compiles
detail: Controller/Race.cs renames `getEindstand()` to `GetFinalStandings()`. This existing test
  file still calls `Data.CurrentRace.getEindstand()`. Because ControllerTest.csproj references
  RaceTrackMooi.csproj (which is itself broken, see above) and this file directly, the
  ControllerTest project fails to build entirely — meaning the new RaceShould.cs tests added by
  this PR can never actually run in CI or locally.
suggestion: Update the call to `GetFinalStandings()` in the same commit, and confirm `dotnet
  build`/`dotnet test` succeeds for the whole solution, not just the Controller project, before
  merging.
```

```
severity: high
file: Controller/Race.cs
line: 283 (MoveDriverToNextAvailableSection)
issue: No bounds check when advancing participant.Position into the next section
detail: `MoveDriverToNextAvailableSection` does `participant.Position++` and then immediately
  indexes `sections[participant.Position]`. If the last section on the track already has both
  Left and Right occupied when another driver reaches it, this increments Position past the end
  of the `sections` array and throws an IndexOutOfRangeException, crashing the race loop.
suggestion: Bound the increment (e.g. wrap/modulo by `sections.Length`, or check
  `participant.Position < sections.Length` before indexing) and decide what should happen when
  a driver truly has nowhere to go this tick.
```

```
severity: medium
file: Controller/Race.cs
line: 94, 268, 283 (PlaceDriverInSection, PlaceDriverOnTrack, MoveDriverToNextAvailableSection)
issue: "assign to Left slot else Right slot" logic is duplicated three times
detail: The same `if (sectionData.Left == null) { sectionData.Left = participant; } else { ...
  Right ... }` shape appears in three different methods with only minor variations. This makes
  future changes (e.g. the missing bounds check above) easy to fix in one place and forget in
  another, as already happened here.
suggestion: Extract a single `TryPlaceInSection(SectionData sectionData, Driver participant)`
  helper and call it from all three methods.
```

If no issues found: N/A — 5 issues found (3 critical, 1 high, 1 medium).
