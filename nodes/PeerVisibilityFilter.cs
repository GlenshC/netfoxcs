using Godot;
using Godot.Collections;

namespace Netfox;

public partial class PeerVisibilityFilter : NodeWrapper<Node>
{
#region Constructors
	public PeerVisibilityFilter()
	{
	}
	public PeerVisibilityFilter(Node resource) : base(resource)
	{
	}

#endregion

#region Enums

	/// <summary>Contains different options for when to automatically update visibility.</summary>
	public enum UpdateModes
	{
		/// <summary>Only update visibility when manually triggered.</summary>
		Never = 0,
		/// <summary>Update visibility when a peer joins or leaves.</summary>
		OnPeer = 1,
		/// <summary>Update visibility before each tick loop.</summary>
		PerTickLoop = 2,
		/// <summary>Update visibility before each network tick.</summary>
		PerTick = 3,
		/// <summary>Update visibility after each rollback tick.</summary>
		PerRollbackTick = 4
	}

#endregion

#region Properties
	/// <summary>Make all peers visible by default if true.</summary>
	public bool DefaultVisibility
	{
		get => (bool)ObjectInstance.Get(PropertyNameGd.DefaultVisibility);
		set => ObjectInstance.Set(PropertyNameGd.DefaultVisibility, value);
	}
	/// <summary>Sets whether and when automatic visibility updates should happen.</summary>
	public UpdateModes UpdateMode
	{
		get => (UpdateModes)(int)ObjectInstance.Get(PropertyNameGd.UpdateMode);
		set => ObjectInstance.Set(PropertyNameGd.UpdateMode, (int)value);
	}
#endregion

#region Methods
	/// <summary>
	/// <para>Register a visibility filter.</para>
	/// <para>The <see href="filter"/> must take a single <see langword="long"/> representing the
	/// peer ID as a parameter, and return <see langword="true"/> if the given peer should be
	/// visible. The same <see href="filter"/> won't be added multiple times.</para></summary>
	/// <param name="filter">The filter to add.</param>
	public void AddVisibilityFilter(Callable filter) =>
		ObjectInstance.Call(MethodNameGd.AddVisibilityFilter, filter);
	/// <summary>
	/// <para>Remove a visibility filter.</para>
	/// <para>If the visibility filter wasn't already registered, nothing happens.</para></summary>
	/// <param name="filter">The filter to remove.</param>
	public void RemoveVisibilityFilter(Callable filter) =>
		ObjectInstance.Call(MethodNameGd.RemoveVisibilityFilter, filter);
	/// <summary><para>Remove all previously registered visibility filters.</para></summary>
	public void ClearVisibilityFilters() =>
		ObjectInstance.Call(MethodNameGd.ClearVisibilityFilters);
	/// <summary>Gets the visibility for the specified peer.</summary>
	/// <param name="peer">The peer ID.</param>
	/// <returns><see langword="true"/> if the peer is visible.</returns>
	public bool GetVisibilityFor(long peer) =>
		(bool)ObjectInstance.Call(MethodNameGd.GetVisibilityFor, peer);
	/// <summary>Set visibility override for a given <see href="peer"/>.</summary>
	/// <param name="peer">The peer ID to override.</param>
	/// <param name="visibility">The value to override.</param>
	/// <returns><see langword="true"/> if the peer is visible.</returns>
	public void SetVisibilityFor(long peer, bool visibility) =>
		ObjectInstance.Call(MethodNameGd.SetVisibilityFor, peer, visibility);
	/// <summary>Unset visibility override for a given <see href="peer"/>.</summary>
	/// <param name="peer">The peer ID to remove the override of.</param>
	public void UnsetVisibilityFor(long peer) =>
		ObjectInstance.Call(MethodNameGd.UnsetVisibilityFor, peer);
	/// <summary>Recalculates visibility for each known peer.</summary>
	/// <param name="peers">The list of peers to update the visibility of.</param>
	public void UpdateVisibility(Array<int> peers) =>
		ObjectInstance.Call(MethodNameGd.UpdateVisibility, peers);
	/// <summary><para>Return a list of visible peers.</para>
	///
	/// <para>This list is only recalculated when <see cref="UpdateVisibility"/> runs, either by
	/// calling it manually, or via <see cref="UpdateMode"/>.</para></summary>
	/// <returns>List of peers that are currently visible.</returns>
	public Array<int> GetVisiblePeers() =>
		(Array<int>)ObjectInstance.Call(MethodNameGd.GetVisiblePeers);
	/// <summary><para>Return a list of visible peers for use with RPCs.</para>
	/// <para>In contrast to <see href="GetVisiblePeers"/>, this method will utilize Godot's RPC
	/// target peer rules to produce a shorter list if possible. For example, if all peers are
	/// visible, it will simply return 0, indicating a broadcast.</para>
	/// <para>This list will never explicitly include the local peer.</para></summary>
	/// <returns></returns>
	public Array<int> GetRpcTargetPeers() =>
		(Array<int>)ObjectInstance.Call(MethodNameGd.GetRpcTargetPeers);
	/// <summary>Sets the update mode.</summary>
	/// <param name="mode">The new update mode.</param>
	public void SetUpdateMode(UpdateModes mode) => UpdateMode = mode;
	/// <summary>Gets the update mode.</summary>
	/// <returns>The new update mode.</returns>
	public UpdateModes GetUpdateMode() => UpdateMode;
#endregion

#region StringName Constants
	static class MethodNameGd
	{
		public static readonly StringName
			AddVisibilityFilter = "add_visibility_filter",
			RemoveVisibilityFilter = "remove_visibility_filter",
			ClearVisibilityFilters = "clear_visibility_filters",
			GetVisibilityFor = "get_visibility_for",
			SetVisibilityFor = "set_visibility_for",
			UnsetVisibilityFor = "unset_visibility_for",
			UpdateVisibility = "update_visibility",
			GetVisiblePeers = "get_visible_peers",
			GetRpcTargetPeers = "get_rpc_target_peers";
	}
	static class PropertyNameGd
	{
		public static readonly StringName
			Name = "name",
			DefaultVisibility = "default_visibility",
			UpdateMode = "update_mode";
	}
#endregion
}
