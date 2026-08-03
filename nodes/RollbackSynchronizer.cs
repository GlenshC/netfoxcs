namespace Netfox;

using Godot;
using Godot.Collections;


public partial class RollbackSynchronizer : NodeWrapper<Node>, IDataSynchronizer
{

#region Constructors
    public RollbackSynchronizer(Node node)
	    : base(node)
    {
    }

    public RollbackSynchronizer()
    {
    }

#endregion

#region Properties
	/// <summary>The node from which the <see cref="InputProperties"/> and
	/// <see cref="StateProperties"/> paths from.</summary>

	public Node Root
	{
		get => (Node) ObjectInstance.Get(PropertyNameGd.Root);
		set => ObjectInstance.Set(PropertyNameGd.Root, value);
	}


	public bool EnablePrediction
	{
		get => (bool)ObjectInstance.Get(PropertyNameGd.EnablePrediction);
		set => ObjectInstance.Set(PropertyNameGd.EnablePrediction, value);

	}

	public Array<string> StateProperties
	{
		get => (Array<string>)ObjectInstance.Get(PropertyNameGd.StateProperties);
		set => ObjectInstance.Set(PropertyNameGd.StateProperties, value);
	}

	/// <summary><para>Ticks to wait between sending full states.</para>
	/// <para>If set to 0, full states will never be sent. If set to 1, only full states
	/// will be sent. If set higher, full states will be sent regularly, but not
	/// for every tick.</para>
	/// <para>Only considered if <see cref="NetworkRollback.EnableDiffStates"/> is true.</para></summary>
	public int FullStateInterval
	{
		get  => (int)ObjectInstance.Get(PropertyNameGd.FullStateInterval);
		set => ObjectInstance.Set(PropertyNameGd.FullStateInterval, value);

	}
	public int DiffAckInterval
	{
		get  => (int)ObjectInstance.Get(PropertyNameGd.DiffAckInterval);
		set => ObjectInstance.Set(PropertyNameGd.DiffAckInterval, value);

	}

	public Array<string> InputProperties
	{
		get  => (Array<string>)ObjectInstance.Get(PropertyNameGd.InputProperties);
		set => ObjectInstance.Set(PropertyNameGd.InputProperties, value);
	}


	/// <summary>This will broadcast input to all peers, turning this off will limit to sending it
	/// to the server only. Recommended not to use unless needed due to bandwidth considerations.</summary>
	public bool EnableInputBroadcast
	{
		get  => (bool)ObjectInstance.Get(PropertyNameGd.EnableInputBroadcast);
		set => ObjectInstance.Set(PropertyNameGd.EnableInputBroadcast, value);
	}

	public long SpawnTick
	{
		get => (long)ObjectInstance.Call(PropertyNameGd.SpawnTick);
		set => ObjectInstance.Call(PropertyNameGd.SpawnTick, value);
	}

	private PeerVisibilityFilter _visibilityFilter = new (null);
	public PeerVisibilityFilter VisibilityFilter
		=> (PeerVisibilityFilter)_visibilityFilter
			.SetInstance(
				(Node)ObjectInstance.Get(PropertyNameGd.VisibilityFilter)
			);

#endregion

#region Methods

	/// <summary>Call this after any change to configuration and updates based on authority.
	/// Internally calls <see cref="ProcessAuthority"/>.</summary>
	public void ProcessSettings() { ObjectInstance.Call(MethodNameGd.ProcessSettings); }

	/// <summary>Call this whenever the authority of any of the nodes  managed by
	/// this node changes. Make sure to do this at the
	/// same time on all peers.</summary>
	public void ProcessAuthority() { ObjectInstance.Call(MethodNameGd.ProcessAuthority); }

	/// <summary><para>Add a state property.</para>
	/// <para>If the given property is already tracked, this method does nothing.</para></summary>
	/// <param name="node">A string, a <see cref="NodePath"/> pointing to a node, or a <see cref="Node"/> instance.</param>
	/// <param name="property">the property to be added.</param>
	public void AddState(Variant node, string property)
	{
		ObjectInstance.Call(MethodNameGd.AddState, node, property);
	}
	/// <summary><para>Add an input property.</para>
	/// <para>If the given property is already tracked, this method does nothing.</para></summary>
	/// <param name="node">A string, a <see cref="NodePath"/> pointing to a node, or a <see cref="Node"/> instance.</param>
	/// <param name="property">the property to be added.</param>
	public void AddInput(Variant node, string property)
	{
		ObjectInstance.Call(MethodNameGd.AddInput, node, property);
	}

	/// <summary><para>Check if input is available for the current tick.</para>
	/// <para>This input is not always current, it may be from multiple ticks ago.</para>
	/// <returns>True if input is available.</returns>
	public bool HasInput() { return (bool)ObjectInstance.Call(MethodNameGd.HasInput); }
	/// <summary><para>Get the age of currently available input in ticks.</para>
	/// <para>The available input may be from the current tick, or from multiple ticks ago.
	/// This number of tick is the input's age.</para>
	/// <para>Calling this when <see cref="HasInput"/> is false will yield an error.</para></summary>
	/// <returns>How many ticks elapsed since the input tick.</returns>
	public long GetInputAge() { return (long)ObjectInstance.Call(MethodNameGd.GetInputAge); }
	/// <summary><para>Check if the current tick is predicted.</para>
	/// <para>A tick becomes predicted if there's no up-to-date input available. It will be
	/// simulated and recorded, but will not be broadcast, nor considered
	/// authoritative.</para></summary>
	/// <returns>If the current tick is being predicted.</returns>
	///
	public bool IsPredicting() { return (bool)ObjectInstance.Call(MethodNameGd.IsPredicting); }
	/// <summary><para>Ignore a node's prediction for the current rollback tick.</para>
	/// <para>Call this when the input is too old to base predictions on. This call is
	/// ignored if <see cref="EnablePrediction"/> is false.</para></summary>
	/// <param name="node"></param>
	public void IgnorePrediction(Node node) { ObjectInstance.Call(MethodNameGd.IgnorePrediction, node); }
	/// <summary><para>Get the tick of the last known input.</para>
	/// <para>This is the latest tick where input information is available. If there's
	/// locally owned input for this instance ( e.g. running as client ), this value
	/// will be the current tick. Otherwise, this will be the latest tick received
	/// from the input owner.</para>
	/// <para>If <see cref="EnableInputBroadcast"/> is false, there may be no input available
	/// for peers who own neither state nor input.</para></summary>
	/// <returns>Last known input.</returns>
	public long GetLastKnownInput() { return (long)ObjectInstance.Call(MethodNameGd.GetLastKnownInput); }
	/// <summary><para>Get the tick of the last known state.</para>
	/// <para>This is the latest tick where information is available for state. For state
	/// owners ( usually the host ), this is the current tick. Note that even this
	/// data may change as new input arrives. For peers that don't own state, this
	/// will be the tick of the latest state received from the state owner.</para>
	/// <para>If <see cref="EnableInputBroadcast"/> is false, there may be no input available
	/// for peers who own neither state nor input.</para></summary>
	/// <returns>Last known state.</returns>
	public long GetLastKnownState() { return (long)ObjectInstance.Call(MethodNameGd.GetLastKnownState); }

	public void Spawn() { ObjectInstance.Call(MethodNameGd.Spawn); }
	public void Spawn(long tick) { ObjectInstance.Call(MethodNameGd.Spawn, tick); }
	public void Despawn() { ObjectInstance.Call(MethodNameGd.Despawn); }
	public void Despawn(long tick) { ObjectInstance.Call(MethodNameGd.Despawn, tick); }
	public bool IsAlive() { return (bool)ObjectInstance.Call(MethodNameGd.IsAlive); }
	public bool IsAlive(long tick) { return (bool)ObjectInstance.Call(MethodNameGd.IsAlive, tick); }
	public bool SetSchema(Dictionary schema) { return (bool)ObjectInstance.Call(MethodNameGd.SetSchema, schema); }
	public bool MergeSchema(Dictionary schema) { return (bool)ObjectInstance.Call(MethodNameGd.MergeSchema, schema); }
	public bool ClearSchema() { return (bool)ObjectInstance.Call(MethodNameGd.ClearSchema); }
#endregion

#region StringName Constants
	static class MethodNameGd
	{
		public static readonly StringName
			ProcessSettings = "process_settings",
			ProcessAuthority = "process_authority",
			AddState = "add_state",
			AddInput = "add_input",
			SetSchema = "set_schema",
			MergeSchema = "merge_schema",
			ClearSchema = "clear_schema",
			HasInput = "has_input",
			GetInputAge = "get_input_age",
			IsPredicting = "is_predicting",
			IgnorePrediction = "ignore_prediction",
			GetLastKnownInput = "get_last_known_input",
			GetLastKnownState = "get_last_known_state",
			Spawn = "spawn",
			Despawn = "despawn",
			IsAlive = "is_alive";
	}

	static class PropertyNameGd
	{
		public static readonly StringName
			Root = "root",
			EnablePrediction = "enable_prediction",
			StateProperties = "state_properties",
			FullStateInterval = "full_state_interval",
			DiffAckInterval = "diff_ack_interval",
			InputProperties = "input_properties",
			EnableInputBroadcast = "enable_input_broadcast",
			VisibilityFilter = "visibility_filter",
			SpawnTick = "spawn_tick";
	}
#endregion

}

