# ZeroReplay (ZeroMacroWindows)

A small, old-school **macro recorder & player for Windows**: record or script mouse
clicks, drags, movements and keyboard input, then replay them on a loop — with
conditional logic, per-command timing, global hotkeys and command-line launch.

Built on WinForms / .NET Framework 4.8. Single executable, no installation,
macros are plain text files (`.zmw`).

> **Provenance.** This is an open-source re-release of a personal application I
> originally wrote in 2010. The original source was lost, so the code was
> recovered by decompiling my own last build (ILSpy) and then modernised: the
> project was rebuilt against the modern SDK-style format and new features were
> added (global hotkeys, configuration list dialog, CLI start). All code is my
> own; no third-party decompiled code is included.

## Features

- **Mouse operations** — left/right click, double click, drag paths
  ("tratti"), move to point, screen-coordinate capture.
- **Keyboard operations** — typed strings, key sequences.
- **Flow control** — `If` conditions, `While` loops, `Process` (launch
  programs), variables, pauses.
- **Recording** — record a session of real input and turn it into a macro
  (`REC` window).
- **Per-command repetition count and delay** (milliseconds).
- **Global hotkeys** — bind any key combo to a saved configuration; bindings
  live in `hotkeys.ini` next to the executable (`<combo>=<macro path>`).
- **Configuration list dialog** — table of known macros and their hotkeys,
  tracked in `macroz.ini`.
- **Always-on-top** window option.
- **Command-line start**:

  ```bat
  ZeroMacroWindows.exe <macro> [--go]
  ```

  `<macro>` is resolved against the exe folder, the `configs\` subfolder, and
  the directory in the `ZEROREPLAY_CONFIGS` environment variable. Pass `--go`
  to start playback immediately after loading.

## Macro files

Macros are simple line-based text files (`.zmw`) written and read by the app;
one command per line with its repetition/time parameters. The interpreter is
in [`src/ZeroMacroWindows/Interpreta.cs`](src/ZeroMacroWindows/Interpreta.cs).
Macro files are **personal data** and are intentionally not part of this
repository.

## Downloads

Prebuilt binary for Windows x86 (.NET Framework 4.8 runtime required):

📦 **[Latest release](https://github.com/akalus69/ZeroReplay/releases/latest)** — download the zip, extract, run `ZeroReplay.exe`.

## Building

Requirements (Windows):

- .NET SDK 8+ (to drive the build)
- .NET Framework 4.8 targeting pack (installed with Visual Studio or the
  standalone developer pack)

```bat
dotnet build src\ZeroReplay.csproj -c Release
```

The executable is produced at `src\bin\Release\net48\ZeroMacroWindows.exe`
(the binary is named `ZeroMacroWindows` for backwards compatibility with
existing macros and hotkey files; the project name is **ZeroReplay**).

## Repository layout

```
src/                  C# sources (SDK-style project, net48, x86)
├── ZeroMacroWindows/ App code (one class per macro operation)
├── Properties/       AssemblyInfo
└── *.resx            WinForms designer resources
```

## License

[MIT](LICENSE). Use it, fork it, break it — attribution appreciated.

## Disclaimer

This is a general-purpose input-automation tool. Automating interactions with
software you do not own or that forbids automation in its terms of service
(online games, banking apps, exams…) is your responsibility. The authors accept
no liability for misuse.