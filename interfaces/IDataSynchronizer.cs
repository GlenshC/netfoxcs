using Godot;
using Godot.Collections;

namespace Netfox;

public interface IDataSynchronizer: INativeWrapper<Node>
{
	public Node Root { get; set; }
	public Array<string> StateProperties { get; set; }
	public long SpawnTick { get; set; }

	public void ProcessSettings();
	public void AddState(Variant node, string property);
	public void Spawn();
	public void Spawn(long tick);
	public void Despawn();
	public void Despawn(long tick);
	public bool IsAlive();
	public bool IsAlive(long tick);

	public static IDataSynchronizer Create(Node node)
	{
		if (NativeWrapper<Node>.GetObjectClassName(node) == "PredictiveSynchronizer")
			return new PredictiveSynchronizer(node);
		return new RollbackSynchronizer(node);
	}
}
