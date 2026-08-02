using System;
using Godot;

namespace Netfox;

public partial class PredictiveSynchronizer : NodeWrapper<Node>
{
#region Constructors

	public PredictiveSynchronizer(): base()
	{
	}

	public PredictiveSynchronizer(Node resource = null) : base(resource)
	{
	}

#endregion

#region Properties
	public Node Root
	{
		get => (Node)ObjectInstance.Call(PropertyNameGd.Root);
		set => ObjectInstance.Call(PropertyNameGd.Root, value);
	}
	public string[] StateProperties
	{
		get => (string[])ObjectInstance.Call(PropertyNameGd.StateProperties);
		set => ObjectInstance.Call(PropertyNameGd.StateProperties, value);
	}
	public long SpawnTick
	{
		get => (long)ObjectInstance.Call(PropertyNameGd.SpawnTick);
		set => ObjectInstance.Call(PropertyNameGd.SpawnTick, value);
	}
#endregion

#region Methods
	public void ProcessSettings()
	{
		ObjectInstance.Call(MethodNameGd.ProcessSettings);
	}

	public void Spawn()
	{
		ObjectInstance.Call(MethodNameGd.Spawn);
	}
	public void Spawn(long tick)
	{
		ObjectInstance.Call(MethodNameGd.Spawn, tick);
	}

	public void Despawn()
	{
		ObjectInstance.Call(MethodNameGd.Despawn);
	}
	public void Despawn(long tick)
	{
		ObjectInstance.Call(MethodNameGd.Despawn, tick);
	}

	public bool IsAlive()
	{
		return (bool)ObjectInstance.Call(MethodNameGd.IsAlive);
	}
	public bool IsAlive(long tick)
	{
		return (bool)ObjectInstance.Call(MethodNameGd.IsAlive, tick);
	}

	public bool AddState(Variant node, string property)
	{
		return (bool)ObjectInstance.Call(MethodNameGd.AddState, node, property);
	}
#endregion

#region StringName Constants
	static class MethodNameGd
	{
		public static readonly StringName
			ProcessSettings = "process_settings",
			AddState = "add_state",
			Spawn = "spawn",
			Despawn = "despawn",
			IsAlive = "is_alive";
	}

	static class PropertyNameGd
	{
		public static readonly StringName
			Name = "name",
			Root = "root",
			StateProperties = "state_properties",
			SpawnTick = "spawn_tick";
	}
#endregion
}
