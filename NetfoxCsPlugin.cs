#if TOOLS
using Godot;

namespace Netfox;

[Tool]
public partial class NetfoxCsPlugin : EditorPlugin
{
	public override void _EnterTree()
	{
		AddAutoloadSingleton("NetfoxCs", $"res://addons/netfoxcs/NetfoxCs.cs");
	}

	public override void _ExitTree()
	{
		RemoveAutoloadSingleton("NetfoxCs");
	}
}

#endif
