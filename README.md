# BeatsaberOptimizer (PC-Only) [![Build](https://github.com/Goobwabber/BeatsaberOptimizer/workflows/Build/badge.svg?event=push)](https://github.com/Goobwabber/BeatsaberOptimizer/actions?query=workflow%3ABuild+branch%3Amain)
A mod that optimizes some things to make the game run better on lower performance CPUs

## Features
* Makes wall maps much less laggy

More optimizations will be added when I find them or if they are reported.

## Installation
1. Ensure you have the [required mods](https://github.com/Goobwabber/BeatsaberOptimizer#requirements)
2. Download the `BeatsaberOptimizer` file listed under `Assets` **[Here](https://github.com/Goobwabber/BeatsaberOptimizer/releases)**.
    * Optionally, you can get a development build by downloading the file listed under `Artifacts` **[Here](https://github.com/Goobwabber/BeatsaberOptimizer/actions?query=workflow%3ABuild+branch%3Amain)** (pick the topmost successful build).
    * You must be logged into GitHub to download a development build.
3. Extract the zip file to your Beat Saber game directory (the one `Beat Saber.exe` is in).
    * The `BeatsaberOptimizer.dll` (and `BeatsaberOptimizer.pdb` if it exists) should end up in your `Plugins` folder (**NOT** the one in `Beat Saber_Data`).
4. **Optional**: Edit `Beat Saber IPA.json` (in your `UserData` folder) and change `Debug` -> `ShowCallSource` to `true`. This will enable BSIPA to get file and line numbers from the `PDB` file where errors occur, which is very useful when reading the log files. This may have a *slight* impact on performance.

## Requirements
These can be downloaded from [BeatMods](https://beatmods.com/#/mods) or using Mod Assistant.
* BSIPA 4.2.0+
* SiraUtil 3.0.0+

## Reporting Issues
* The best way to report issues is to click on the `Issues` tab at the top of the GitHub page. This allows any contributor to see the problem and attempt to fix it, and others with the same issue can contribute more information. **Please try the troubleshooting steps before reporting the issues listed there. Please only report issues after using the latest build, your problem may have already been fixed.**
* Include in your issue:
  * A detailed explanation of your problem (you can also attach videos/screenshots)
  * **Important**: The log file from the game session the issue occurred (restarting the game creates a new log file).
    * The log file can be found at `Beat Saber\Logs\_latest.log` (`Beat Saber` being the folder `Beat Saber.exe` is in).
* If you ask for help on Discord, at least include your `_latest.log` file in your help request.

## Contributing
Anyone can feel free to contribute bug fixes or enhancements to BeatsaberOptimizer. GitHub Actions for Pull Requests made from GitHub accounts that don't have direct access to the repository will fail. This is normal because the Action requires a `Secret` to download dependencies.
### Building
Visual Studio 2019 with the [BeatSaberModdingTools](https://github.com/Zingabopp/BeatSaberModdingTools) extension is the recommended development environment.
1. Check out the repository
2. Open `BeatsaberOptimizer.sln`
3. Right-click the `BeatsaberOptimizer` project, go to `Beat Saber Modding Tools` -> `Set Beat Saber Directory`
   * This assumes you have already set the directory for your Beat Saber game folder in `Extensions` -> `Beat Saber Modding Tools` -> `Settings...`
   * If you do not have the BeatSaberModdingTools extension, you will need to manually create a `BeatsaberOptimizer.csproj.user` file to set the location of your game install. An example is showing below.
4. The project should now build.

**Example csproj.user File:**
```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="Current" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <BeatSaberDir>Full\Path\To\Beat Saber</BeatSaberDir>
  </PropertyGroup>
</Project>
```
## Donate
You can support development of BeatsaberOptimizer by donating at the following links:
* https://ko-fi.com/goobwabber
* https://www.patreon.com/goobwabber
