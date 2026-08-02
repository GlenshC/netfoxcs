using Godot;
namespace Netfox;

/// <summary><para>C# wrapper for Fox's Sake Studio's
/// <see href="https://github.com/foxssake/netfox/"> netfox</see> addon.</para>
/// <para>Responsible for interpolating fields between network ticks, resulting
/// in smoother motion.</para></summary>
public partial class TickInterpolator : NodeWrapper<Node>
{
	public TickInterpolator()
	{
	}

	public TickInterpolator(Node resource) : base(resource)
    {
    }

#region Properties
    public Node Root
    {
	    get => (Node) ObjectInstance.Get(PropertyNameGd.Root);
	    set => ObjectInstance.Set(PropertyNameGd.Root, value);
    }
    public bool Enabled
    {
	    get => (bool) ObjectInstance.Get(PropertyNameGd.Enabled);
	    set => ObjectInstance.Set(PropertyNameGd.Enabled, value);
    }
    public string[] Properties
    {
	    get => (string[]) ObjectInstance.Get(PropertyNameGd.Properties);
	    set => ObjectInstance.Set(PropertyNameGd.Properties, value);
    }
    public bool RecordFirstState
    {
	    get => (bool) ObjectInstance.Get(PropertyNameGd.RecordFirstState);
	    set => ObjectInstance.Set(PropertyNameGd.RecordFirstState, value);
    }
    public bool EnableRecording
    {
	    get => (bool) ObjectInstance.Get(PropertyNameGd.EnableRecording);
	    set => ObjectInstance.Set(PropertyNameGd.EnableRecording, value);
    }

#endregion

#region Methods

    /// <summary>Call this after any change to configuration.</summary>
    public void ProcessSettings() =>  ObjectInstance.Call(MethodNameGd.ProcessSettings);
    public void AddProperty(Variant node, string property) => ObjectInstance.Call(MethodNameGd.AddProperty, node, property);

    /// <summary><para>Check if interpolation can be done.</para>
    /// <para>Even if it's enabled, no interpolation will be done if there are no
    /// properties to interpolate.</para></summary>
    /// <returns>Whether the node is able to and has reason to interpolate.</returns>
    public bool CanInterpolate() => (bool)ObjectInstance.Call(MethodNameGd.CanInterpolate);
    /// <summary><para>Record current state for interpolation.</para>
    /// <para>Note that this will rotate the states, so the previous target becomes the new
    /// starting point for the interpolation. This is automatically called if
    /// <see cref="EnableRecording"/> is true.</para></summary>
    public void PushState() =>  ObjectInstance.Call(MethodNameGd.PushState);
    /// <summary>Record current state and transition without interpolation.</summary>
    public void Teleport() => ObjectInstance.Call(MethodNameGd.Teleport);

#endregion

#region StringName Constants
    static class MethodNameGd
    {
        public static readonly StringName
            ProcessSettings = "process_settings",
            AddProperty = "add_property",
            CanInterpolate = "can_interpolate",
            PushState = "push_state",
            Teleport = "teleport";
    }

    static class PropertyNameGd
    {
        public static readonly StringName
            Name = "name",
            Root = "root",
            Enabled = "enabled",
            Properties = "properties",
            RecordFirstState = "record_first_state",
            EnableRecording = "enable_recording";
    }
#endregion
}
