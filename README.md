# Dynamic DLL Loading POC

A proof-of-concept showing how .NET apps can integrate with Finsemble (and the underlying io.CD) without taking a fixed dll version.

The example app [ConsoleApp](ExampleApps/ConsoleApp) references `FinsembleContainer.dll`, which dynamically loads Finsemble version at runtime.  
This is based on the launch argument `hostType` when Finsemble opens a .Net app:
- When running Finsemble v7, it does not pass `hostType`, the container loads v7 dll.
- When running Finsemble v9, it passes `hostType=finsemble`, the container loads v9 dll.
- When running Finsemble v9 iocd, it passes `hostType=iocd`, the container loads v9 dll, which is compatible to iocd.

See [FinsembleContainer.cs](FinsembleContainer/FinsembleContainer/FinsembleContainer.cs) for how Finsemble version is resolved at runtime.  
That projects `FinsembleContainer.Latest` and `FinsembleContainer.V7` contain their own Finsemble dll version, the main project `FinsembleContainer` combines them when building the bin.

## Getting Started

### 1. Build the .NET libraries and apps

Build below solutions in Visual Studio or via CLI:

- `FinsembleContainer/FinsembleContainer.sln`
- `ExampleApps/ExampleApps.sln`

### 2. Start Finsemble v7 (legacy)

```bash
cd FinsembleV7
npm install
npm run dev
```

> `npm install` also runs `updateAppsJson.js`, which replaces `<PROJECT_ROOT>` in `apps.json` with the actual path.

App `ConsoleExampleApp` will be available in the app menu.

### 3. Start Finsemble v9 (iocd)

```bash
cd FinsembleV9
npm install
npm run dev-iocd
```
> `npm install` also runs `updateAppsJson.js`, which replaces `<PROJECT_ROOT>` in `apps.json` with the actual path.

App `ConsoleExampleApp` will be available in the app menu.
