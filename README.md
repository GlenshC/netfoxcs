# NetfoxCs

A lightweight C# wrapper for [netfox](https://github.com/foxssake/netfox), the GDScript addon for building rollback-friendly multiplayer games in Godot.

NetfoxCs lets you interact with netfox's nodes (`RewindableAction`, `RollbackSynchronizer`, etc.) directly from C#, using PascalCase members that mirror the original GDScript API.

## How it's different from NetfoxSharp

[NetfoxSharp](https://github.com/CyFurStudios/NetfoxSharp) works by generating **proxy nodes**, new node types (e.g. `RollbackSynchronizerSharp`) that get added to Godot's "Add Node" menu alongside the original GDScript ones.

**NetfoxCs does not create or register any new nodes.** It's a thin wrapper: you keep using the original GDScript netfox nodes in your scene tree exactly as they are, and NetfoxCs simply wraps a reference to them so you can call their methods and read their properties from C#. Nothing is duplicated, nothing new shows up in the editor's node list, and your scene files stay untouched by NetfoxCs itself.

This means:
- Your `.tscn` files reference the same GDScript nodes netfox ships with, no vendor lock-in to a parallel node hierarchy.
- Mixing GDScript and C# in the same project is simpler, since there's only one "real" node type per feature.
- Upgrading netfox generally doesn't require regenerating anything on the NetfoxCs side.

## Requirements

- Godot 4.1+ with C# (Mono) support enabled
- [netfox](https://github.com/foxssake/netfox) installed and enabled in your project
- .NET SDK matching your Godot C# setup

## Installation

Install NetfoxCs by copying the repo directly into your project's `addons` folder.

1. Install and enable **netfox** in your Godot project first (via the AssetLib or by copying the `addons/netfox` folder into your project, then enabling it in **Project > Project Settings > Plugins**).
2. Clone or download this repository into your project's `addons` folder, so you end up with:
   ```
   your-project/
   └── addons/
       └── netfoxcs/
           ├── ... NetfoxCs source files
   ```
   For example, from your project root:
   ```
   git clone https://github.com/GlenshC/netfoxcs.git addons/netfoxcs
   ```
3. Enable the plugin in **Project > Project Settings > Plugins**.
4. Build your project so the C# assembly picks up the new classes.

> **Note:** NetfoxCs ships as a Godot addon with its own `plugin.cfg`, so after copying it in, enable it under **Project > Project Settings > Plugins** like any other addon.
## Usage

NetfoxCs classes wrap a reference to the actual GDScript node. You expose a `Node` in your `[Export]`, hint it to the matching GDScript node type, and then wrap it in the constructor.

```csharp
using Netfox;
using Godot;

public partial class MyCharacter : Node
{
    private RewindableAction _castAction;
    private RollbackSynchronizer _synchronizer;

    [Export(PropertyHint.NodeType, "RewindableAction")]
    public Node CastAction
    {
        get => _castAction;
        set => _castAction = new RewindableAction(value);
    }

    [Export(PropertyHint.NodeType, "RollbackSynchronizer")]
    public Node Synchronizer
    {
        get => _synchronizer;
        set => _synchronizer = new RollbackSynchronizer(value);
    }

    public override void _Ready()
    {
        // Use the wrapped C# API, e.g.:
        // _castAction.SetActive(true, someTick);
        // bool active = _castAction.IsActive(someTick);
    }
}
```

**Important:** the string passed to `PropertyHint.NodeType` (e.g. `"RewindableAction"`, `"RollbackSynchronizer"`) must match the **name of the GDScript node/class** you're wrapping. This is what tells the Godot editor which node type is valid to drag into that export slot, pick the wrong string and the editor won't let you assign the right node, or the wrapper won't find the members it expects.

Then in the editor:
1. Add the actual GDScript netfox node (e.g. `RewindableAction`) to your scene as normal.
2. Select your C# node and drag the GDScript node into the corresponding exported slot.

## Singletons (Autoloads)

netfox's autoload singletons, like `NetworkTime`, `NetworkRollback`, `NetworkEvents`, etc., are accessed as static members through the `Netfox` namespace, the same convention used by NetfoxSharp. This avoids extra `GetNode()` calls and keeps your project settings' autoload list untouched.

```csharp
using Netfox;

public override void _Ready()
{
    NetfoxCs.NetworkTime.BeforeTickLoop += Gather;
}

private void Gather()
{
    // Input gathering here
}
```

## API Coverage

NetfoxCs aims to mirror the original GDScript API 1:1, with method and property names converted to PascalCase per C# convention. For example:

| GDScript | NetfoxCs (C#) |
|---|---|
| `set_active(active, tick)` | `SetActive(active, tick)` |
| `is_active(tick)` | `IsActive(tick)` |
| `get_status(tick)` | `GetStatus(tick)` |
| `has_confirmed()` | `HasConfirmed()` |
| `get_context(tick)` | `GetContext(tick)` |

Refer to the [official netfox documentation](https://foxssake.github.io/netfox/latest/) for full behavioral details, NetfoxCs wraps the API surface, not the underlying rollback logic.

## Development notes

This repo is developed directly inside a Godot project's `addons/netfoxcs` folder (with its own `git init`), rather than as a standalone library synced in afterward. This is intentional, it makes it easy to iterate and test changes against a real project while working on the wrapper. If you clone this repo to contribute, you'll likely want to drop it into `addons/netfoxcs` of a Godot + netfox test project so you can run and verify changes in-editor.

## Credits
- [netfox](https://github.com/foxssake/netfox) by Fox's Sake Studios, the original GDScript addon this project wraps.
- [NetfoxSharp](https://github.com/CyFurStudios/NetfoxSharp) by CyFurStudios, much of NetfoxCs's code is adapted from NetfoxSharp. The `netfox.extras` `RewindableStateMachine` and `RewindableState` classes are copied as-is, since they're abstract/blueprint classes meant to be inherited from rather than wrapped. Most other classes started from NetfoxSharp's implementation and were modified to work as thin wrappers around the existing GDScript nodes instead of generating proxy nodes. Many thanks to the NetfoxSharp contributors for the groundwork.
## Contributing

Issues and PRs are welcome. If you're adding coverage for a new netfox class or method, please try to keep naming consistent with the PascalCase convention used throughout the wrapper.

## License

MIT, see [LICENSE](./LICENSE) for details.
