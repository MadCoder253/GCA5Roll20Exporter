# GCA5 Roll20 Exporter

GCA5 Plugin for Exporting to Roll20

## Resources

Initial source code provided by WoodmanX

[GCA5FantasyGroundsExporter](https://github.com/WoodmanX/GCA5FantasyGroundsExporter)

## Versions

### 1.0.1.20

- Update GetRepeatingRanged to use ModeManager
- Update GetRepeatingMelee to use ModeManager
- Update GetRepeatingTrait to use check for parent/child relationship

### 1.0.1.10

- Fix bug when checking base skill trait by capitalizing the value for `stepoff` value.
- Some templates have a base cost that is not reflected in the list of traits. Update template to get PreModsPoints.
- Added VTT Notes.
- Implemented modHelperFunctions.RTFtoPlainText() for notes.
- If a spell is a parent, set the points to zero. Temporary fix until parent/child relationships are handled.
- If a spell is a ritual magic, add the spell with zero point cast but also add an entry to the techniques table for that ritual magic spell.
- Fix bug with item cost and weight. Updated to get base cost and weight.

## File Locations

GCA5 Plugin Location: C:\ProgramData\Steve Jackson Games\GURPS Character Assistant 5\plugins\ExportToRoll20

## Development

### Debugging

This will send a message to the Log window of GCA5.

```csharp
modUIAssistance.Notify("parentKey: " + parentKey);
```

### Deploying to GCA5

- Make sure GCA5 is not running
- Build or Rebuild the Project
  - The post-build macro will copy source code files to the `GCA5 Plugin Location`.
- Start GCA%
  - You can test your updates
- Hint: Edit `~\ExportToRoll20\ExportToRoll20.cs` and change the value for `PLUGIN_VERSION`. This helps verify the code was copied over correctly.
