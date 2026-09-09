using Godot;

namespace Netfox;

public partial class NetworkHistoryServer : NodeWrapper<Node>
{
	protected override StringName GdClassName => "_NetworkHistoryServer";

	internal NetworkHistoryServer(Node node) : base(node)
	{}

    public void Reload() { } // => ObjectInstance.Call(MethodNameGd.Reload);
	/// <summary>
    /// Register a rollback state property.
    /// </summary>
    public void RegisterRollbackState(Node node, NodePath property)
    {
        ObjectInstance.Call(MethodNameGd.RegisterRollbackState, node, property);
    }

    /// <summary>
    /// Deregister a rollback state property.
    /// </summary>
    public void DeregisterRollbackState(Node node, NodePath property)
    {
        ObjectInstance.Call(MethodNameGd.DeregisterRollbackState, node, property);
    }

    /// <summary>
    /// Register a rollback input property.
    /// </summary>
    public void RegisterRollbackInput(Node node, NodePath property)
    {
        ObjectInstance.Call(MethodNameGd.RegisterRollbackInput, node, property);
    }

    /// <summary>
    /// Deregister a rollback input property.
    /// </summary>
    public void DeregisterRollbackInput(Node node, NodePath property)
    {
        ObjectInstance.Call(MethodNameGd.DeregisterRollbackInput, node, property);
    }

    /// <summary>
    /// Register a synchronized state property.
    /// </summary>
    public void RegisterSyncState(Node node, NodePath property)
    {
        ObjectInstance.Call(MethodNameGd.RegisterSyncState, node, property);
    }

    /// <summary>
    /// Deregister a synchronized state property.
    /// </summary>
    public void DeregisterSyncState(Node node, NodePath property)
    {
        ObjectInstance.Call(MethodNameGd.DeregisterSyncState, node, property);
    }

    /// <summary>
    /// Deregister a node, no longer tracking any property it had registered using any of the Register*() methods.
    /// </summary>
    public void Deregister(Node node)
    {
        ObjectInstance.Call(MethodNameGd.Deregister, node);
    }

    /// <summary>
    /// Do not record subject.
    /// Can be used in _RollbackTick() in case node prediction is enabled, but state can't be reasonably predicted.
    /// Subjects stay ignored until FlushIgnores() is called. This is done by default after every rollback tick.
    /// </summary>
    public void Ignore(Node subject)
    {
        ObjectInstance.Call(MethodNameGd.Ignore, subject);
    }

    /// <summary>
    /// Clear the list of ignored subjects.
    /// Calling this method undoes all previous Ignore() calls.
    /// </summary>
    public void FlushIgnores()
    {
        ObjectInstance.Call(MethodNameGd.FlushIgnores);
    }

    /// <summary>
    /// Return the latest tick where any of the subjects had rollback state data available.
    /// </summary>
    public int GetLatestStateTickFor(Godot.Collections.Array subjects, int tick)
    {
        return (int)ObjectInstance.Call(MethodNameGd.GetLatestStateTickFor, subjects, tick);
    }

    /// <summary>
    /// Return how old is the latest rollback state data for any of the subjects, in ticks.
    /// </summary>
    public int GetStateAgeFor(Godot.Collections.Array subjects, int tick)
    {
        return (int)ObjectInstance.Call(MethodNameGd.GetStateAgeFor, subjects, tick);
    }

    /// <summary>
    /// Return the latest tick where any of the subjects had rollback input data available.
    /// </summary>
    public int GetLatestInputFor(Godot.Collections.Array subjects, int tick)
    {
        return (int)ObjectInstance.Call(MethodNameGd.GetLatestInputFor, subjects, tick);
    }

    /// <summary>
    /// Return how old is the latest rollback input data for any of the subjects, in ticks.
    /// </summary>
    public int GetInputAgeFor(Godot.Collections.Array subjects, int tick)
    {
        return (int)ObjectInstance.Call(MethodNameGd.GetInputAgeFor, subjects, tick);
    }

    /// <summary>
    /// Record currently registered rollback state properties for subject at tick.
    /// </summary>
    public void PushRollbackState(Node subject, int tick)
    {
        ObjectInstance.Call(MethodNameGd.PushRollbackState, subject, tick);
    }

	#region StringName Constants

	static class MethodNameGd
	{
		public static readonly StringName
			Reload = "reload",
			RegisterRollbackState = "register_rollback_state",
			DeregisterRollbackState = "deregister_rollback_state",
			RegisterRollbackInput = "register_rollback_input",
			DeregisterRollbackInput = "deregister_rollback_input",
			RegisterSyncState = "register_sync_state",
			DeregisterSyncState = "deregister_sync_state",
			Deregister = "deregister",
			Ignore = "ignore",
			FlushIgnores = "flush_ignores",
			GetLatestStateTickFor = "get_latest_state_tick_for",
			GetStateAgeFor = "get_state_age_for",
			GetLatestInputFor = "get_latest_input_for",
			GetInputAgeFor = "get_input_age_for",
			PushRollbackState = "push_rollback_state";
	}

	#endregion
}
