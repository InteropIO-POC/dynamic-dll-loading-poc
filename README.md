# Dynamic DLL Loading POC

A proof-of-concept showing how .NET apps can integrate with Finsemble (and the underlying io.CD) without taking a hard dependency on the platform SDK.

The examples [WpfApp](ExampleApps/WpfApp) and [WinformApp](ExampleApps/WinformApp) reference only `Container.dll`, which dynamically loads `Container.Impl.dll` at runtime from a shared location. This means the implementation of Container or Finsemble can be updated independently of the apps.

See [ContainerLibraries/Container](ContainerLibraries/Container/Container.cs) for how `Container.dll` locates and loads `Container.Impl.dll` at runtime.

## Getting Started

### 1. Setup Finsemble

```bash
cd Finsemble && npm install
```

> This also runs `updateAppsJson.js`, which replaces `<PROJECT_ROOT>` in `apps.json` with the actual path.

To setup for iocd polyfill, additionally run:
```bash
npm run setup-iocd
```

### 2. Build the .NET libraries and apps

Build below solutions in Visual Studio or via CLI:

- `ContainerLibraries/ContainerLibraries.sln`
- `ExampleApps/ExampleApps.sln`

### 3. Start Finsemble

```bash
cd Finsemble && npm run dev
```
or
```bash
cd Finsemble && npm run dev-iocd
```

The example apps (`WpfExampleApp`, `WinformExampleApp`) will be available in the app menu.
