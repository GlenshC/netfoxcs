using Godot;
using Limitless;

namespace Netfox;

public partial class NetfoxCs: Node
{
	public const string NetfoxDir = "res://addons/netfox";
	public static readonly (string name, string path)[] AutoloadsGd =
	[
		("NetworkTime", $"{NetfoxDir}/network-time.gd"),
		("NetworkTimeSynchronizer", $"{NetfoxDir}/network-time-synchronizer.gd"),
		("NetworkRollback", $"{NetfoxDir}/rollback/network-rollback.gd"),
		("NetworkEvents", $"{NetfoxDir}/network-events.gd"),
		("RollbackSimulationServer", $"{NetfoxDir}/servers/rollback-simulation-server.gd"),
		("NetworkHistoryServer", $"{NetfoxDir}/servers/network-history-server.gd"),
		("NetworkSynchronizationServer", $"{NetfoxDir}/servers/network-synchronization-server.gd"),
		("NetworkIdentityServer", $"{NetfoxDir}/servers/network-identity-server.gd"),
		("NetworkCommandServer", $"{NetfoxDir}/servers/network-command-server.gd"),
		("RollbackLivenessServer", $"{NetfoxDir}/servers/rollback-liveness-server.gd"),
		("InterpolationServer", $"{NetfoxDir}/servers/interpolation-server.gd")
	];


	/// <summary>Reference to the netfox autoload NetworkTime.</summary>
	public static NetworkTime NetworkTime;
	/// <summary>Reference to the netfox autoload NetworkTimeSynchronizer.</summary>
	public static NetworkTimeSynchronizer NetworkTimeSynchronizer;
	/// <summary>Reference to the netfox autoload NetworkRollback.</summary>
	public static NetworkRollback NetworkRollback;
	/// <summary>Reference to the netfox autoload NetworkEvents.</summary>
	public static NetworkEvents NetworkEvents;
	/// <summary>Reference to the netfox autoload NetworkCommandServer.</summary>
	public static NetworkCommandServer NetworkCommandServer;
	/// <summary>Reference to the netfox autoload NetworkHistoryServer.</summary>
	public static NetworkHistoryServer NetworkHistoryServer;

	/// <summary>Reload NetworkHistoryServer, this prevents tick rejection from previous game.</summary>
	public static void Reload()
	{
	}

	public override void _EnterTree()
	{
		NetworkTime = new(GetNode("/root/NetworkTime"));
		NetworkTimeSynchronizer = new(GetNode("/root/NetworkTimeSynchronizer"));
		NetworkRollback = new(GetNode("/root/NetworkRollback"));
		NetworkEvents = new(GetNode("/root/NetworkEvents"));
		NetworkCommandServer = new(GetNode("/root/NetworkCommandServer"));
		NetworkHistoryServer = new(GetNode("/root/NetworkHistoryServer"));
	}

}
