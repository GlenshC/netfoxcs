using Godot;
using Godot.Collections;

namespace Netfox;

/// <summary><para>C# wrapper for Fox's Sake Studio's
/// <see href="https://github.com/foxssake/netfox/"> netfox</see> addon.</para>
/// <para>Responsible for synchronizing state from the node's authority to
/// other peers.</para></summary>
public partial class StateSynchronizer : NodeWrapper<Node>
{
	public StateSynchronizer()
	{
	}
	public StateSynchronizer(Node node) : base(node)
	{
	}

#region Properties
	/// <summary>The node from which the <see cref="Properties"/> paths from.</summary>
	public Node Root
	{
		get => (Node) ObjectInstance.Get(PropertyNameGd.Root);
		set => ObjectInstance.Set(PropertyNameGd.Root, value);
	}
	/// <summary>Properties to synchronize from the <see cref="Root"/> node.</summary>
	public Array<string> Properties
	{
		get => (Array<string>) ObjectInstance.Get(PropertyNameGd.Properties);
		set => ObjectInstance.Set(PropertyNameGd.Properties, value);
	}

	public long FullStateInterval
	{
		get => (long) ObjectInstance.Get(PropertyNameGd.FullStateInterval);
		set => ObjectInstance.Set(PropertyNameGd.FullStateInterval, value);
	}
	public long DiffAckInterval
	{
		get => (long) ObjectInstance.Get(PropertyNameGd.DiffAckInterval);
		set => ObjectInstance.Set(PropertyNameGd.DiffAckInterval, value);
	}

	private PeerVisibilityFilter _visibilityFilter = new (null);
	public PeerVisibilityFilter VisibilityFilter
		=> (PeerVisibilityFilter)_visibilityFilter
			.SetInstance(
				(Node)ObjectInstance.Get(PropertyNameGd.VisibilityFilter)
			);


	private long _fullStateInterval = 24;
	#endregion

#region Methods
	/// <summary>Call this after any change to configuration.</summary>
	public void ProcessSettings() { ObjectInstance.Call(MethodNameGd.ProcessSettings); }
	public void AddState(Variant node, string property)
	{
		ObjectInstance.Call(MethodNameGd.AddState, node, property);
	}
	public bool SetSchema(Dictionary schema) { return (bool)ObjectInstance.Call(MethodNameGd.SetSchema, schema); }
	public bool MergeSchema(Dictionary schema) { return (bool)ObjectInstance.Call(MethodNameGd.MergeSchema, schema); }
	public bool ClearSchema() { return (bool)ObjectInstance.Call(MethodNameGd.ClearSchema); }
#endregion

#region StringName Constants
	static class MethodNameGd
	{
		public static readonly StringName
			ProcessSettings = "process_settings",
			AddState = "add_state",
			SetSchema = "set_schema",
			MergeSchema = "merge_schema",
			ClearSchema = "clear_schema";
	}

	static class PropertyNameGd
	{
		public static readonly StringName
			Root = "root",
			Properties = "properties",
			FullStateInterval = "full_state_interval",
			DiffAckInterval = " 	diff_ack_interval",
			VisibilityFilter = "visibility_filter";
	}
#endregion
}
