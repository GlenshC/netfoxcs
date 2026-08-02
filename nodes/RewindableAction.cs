using Godot;

namespace Netfox;

public enum RewindableActionStatus
{
	Inactive = 0,
	Confirming = 1,
	Active = 2,
	Cancelling = 3
}
public partial class RewindableAction : NodeWrapper<Node>
{

#region Constructors

	public RewindableAction(): base()
	{
	}

	public RewindableAction(Node resource = null) : base(resource)
	{
	}

#endregion

#region Methods

	/// <summary>
	/// Toggles the action for a given <paramref name="tick"/>.
	/// </summary>
	/// <param name="active">Whether the action is active.</param>
	/// <param name="tick">The tick to set the action's activity for.</param>

	public void SetActive(bool active) => ObjectInstance.Call(MethodNameGd.SetActive, active);

	/// <inheritdoc cref="SetActive(bool)"/>
	public void SetActive(bool active, long tick) => ObjectInstance.Call(MethodNameGd.SetActive, active, tick);

	/// <summary>
	/// Check if the action is happening for the given <paramref name="tick"/>.
	/// </summary>
	/// <param name="tick">The tick to check.</param>
	/// <returns>True if the action is active at the given tick.</returns>
	public bool IsActive() => (bool)ObjectInstance.Call(MethodNameGd.IsActive);

	/// <inheritdoc cref="IsActive()"/>
	public bool IsActive(long tick) => (bool)ObjectInstance.Call(MethodNameGd.IsActive, tick);


	/// <summary>
	/// Check the action's status for the given <paramref name="tick"/>.
	/// <para>Returns <c>ACTIVE</c> if the action is happening.</para>
	/// <para>Returns <c>INACTIVE</c> if the action is not happening.</para>
	/// <para>Returns <c>CONFIRMING</c> if the action was previously known as not happening, but now it is.</para>
	/// <para>Returns <c>CANCELLING</c> if the action was previously known to be happening, but now it is not.</para>
	/// <para>The <c>CONFIRMING</c> and <c>CANCELLING</c> statuses may occur if the action was just toggled, or data was received from the action's authority.</para>
	/// </summary>
	/// <param name="tick">The tick to check.</param>
	/// <returns>The action's status at the given tick.</returns>
	public RewindableActionStatus GetStatus() => (RewindableActionStatus)(int)ObjectInstance.Call(MethodNameGd.GetStatus);

	/// <inheritdoc cref="GetStatus()"/>
	public RewindableActionStatus GetStatus(long tick) => (RewindableActionStatus)(int)ObjectInstance.Call(MethodNameGd.GetStatus, tick);


	/// <summary>
	/// Returns true if the action has been in <c>CONFIRMING</c> status during the last tick loop.
	/// </summary>
	/// <returns>True if the action has confirmed during the last tick loop.</returns>

	public bool HasConfirmed() => (bool)ObjectInstance.Call(MethodNameGd.HasConfirmed);

	/// <summary>
	/// Returns true if the action has been in <c>CANCELLING</c> status during the last tick loop.
	/// </summary>
	/// <returns>True if the action has cancelled during the last tick loop.</returns>

	public bool HasCancelled() => (bool)ObjectInstance.Call(MethodNameGd.HasCancelled);


	/// <summary>
	/// Get the action's current status as a string.
	/// </summary>
	/// <param name="tick">The tick to check.</param>
	/// <returns>The action's status at the given tick, as a string.</returns>
	/// <seealso cref="GetStatus"/>
	public string GetStatusString() => (string)ObjectInstance.Call(MethodNameGd.GetStatusString);

	/// <inheritdoc cref="GetStatusString()"/>
	public string GetStatusString(long tick) => (string)ObjectInstance.Call(MethodNameGd.GetStatusString, tick);


	/// <summary>
	/// Returns true if the action has any stored context for the given <paramref name="tick"/>.
	/// </summary>
	/// <param name="tick">The tick to check.</param>
	/// <returns>True if context is stored for the given tick.</returns>
	public bool HasContext() => (bool)ObjectInstance.Call(MethodNameGd.HasContext);

	/// <inheritdoc cref="HasContext()"/>
	public bool HasContext(long tick) => (bool)ObjectInstance.Call(MethodNameGd.HasContext, tick);


	/// <summary>
	/// Get the context stored for the given <paramref name="tick"/>, or null.
	/// </summary>
	/// <param name="tick">The tick to check.</param>
	/// <returns>The stored context, or null.</returns>
	public Variant GetContext() => (Variant)ObjectInstance.Call(MethodNameGd.GetContext);

	/// <inheritdoc cref="GetContext()"/>
	public Variant GetContext(long tick) => (Variant)ObjectInstance.Call(MethodNameGd.GetContext, tick);

	/// <summary>
	/// Store <paramref name="value"/> as the context for the given <paramref name="tick"/>.
	/// </summary>
	/// <param name="value">The value to store.</param>
	/// <param name="tick">The tick to store the context for.</param>
	public void SetContext(Variant value) => ObjectInstance.Call(MethodNameGd.SetContext, value);

	/// <inheritdoc cref="SetContext(Variant)"/>
	public void SetContext(Variant value, long tick) => ObjectInstance.Call(MethodNameGd.SetContext, value, tick);

	/// <summary>
	/// Erase the context for the given <paramref name="tick"/>.
	/// </summary>
	/// <param name="tick">The tick to erase the context for.</param>
	public void EraseContext() => ObjectInstance.Call(MethodNameGd.EraseContext);

	/// <inheritdoc cref="EraseContext()"/>
	public void EraseContext(long tick) => ObjectInstance.Call(MethodNameGd.EraseContext, tick);


	/// <summary>
	/// Whenever the action happens, mutate the <paramref name="target"/> object.
	/// </summary>
	/// <param name="target">The object to mutate.</param>
	/// <seealso cref="NetworkRollback.Mutate"/>
	public void Mutate(GodotObject target) => ObjectInstance.Call(MethodNameGd.Mutate, target);


	/// <summary>
	/// Remove the <paramref name="target"/> object from the list of objects to <see cref="Mutate"/>.
	/// </summary>
	/// <param name="target">The object to remove from the mutate list.</param>
	/// <seealso cref="NetworkRollback.Mutate"/>
	public void DontMutate(GodotObject target) => ObjectInstance.Call(MethodNameGd.DontMutate, target);


#endregion

#region StringName Constants
	static class MethodNameGd
	{
		public static readonly StringName
			SetActive = "set_active",
			IsActive = "is_active",
			GetStatus = "get_status",
			HasConfirmed = "has_confirmed",
			HasCancelled = "has_cancelled",
			GetStatusString = "get_status_string",
			HasContext = "has_context",
			GetContext = "get_context",
			SetContext = "set_context",
			EraseContext = "erase_context",
			Mutate = "mutate",
			DontMutate = "dont_mutate";
	}
#endregion
}
