using Godot;

namespace Netfox;

public partial class NetfoxCs: Node
{
	/// <summary>Reference to the netfox autoload NetworkTime.</summary>
	public static NetworkTime NetworkTime;
	/// <summary>Reference to the netfox autoload NetworkTimeSynchronizer.</summary>
	public static NetworkTimeSynchronizer NetworkTimeSynchronizer;
	/// <summary>Reference to the netfox autoload NetworkRollback.</summary>
	public static NetworkRollback NetworkRollback;
	/// <summary>Reference to the netfox autoload NetworkEvents.</summary>
	public static NetworkEvents NetworkEvents;

	public override void _EnterTree()
	{
		NetworkTime = new(GetNode("/root/NetworkTime"));
		NetworkTimeSynchronizer = new(GetNode("/root/NetworkTimeSynchronizer"));
		NetworkRollback = new(GetNode("/root/NetworkRollback"));
		NetworkEvents = new(GetNode("/root/NetworkEvents"));
	}
}
