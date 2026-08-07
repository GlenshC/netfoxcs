using Godot;

namespace Netfox;

public partial class NodeWrapper<T> : NativeWrapper<T> where T : Node
{

	public NodeWrapper()
	{
	}

	public NodeWrapper(T resource) : base(resource)
	{

	}

	public override NodeWrapper<T> SetInstance(T node)
	{
		DisconnectNodeSignals();
		base.SetInstance(node);
		ConnectNodeSignals();

		return this;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			DisconnectNodeSignals();
		}
		base.Dispose(disposing);
	}

	private void ConnectNodeSignals()
	{
		if (ObjectInstance == null) return;
		ObjectInstance.Connect(SignalNameGd.ChildEnteredTree, Callable.From<Node>(EmitSignalChildEnteredTree));
		ObjectInstance.Connect(SignalNameGd.ChildExitingTree, Callable.From<Node>(EmitSignalChildExitingTree));
		ObjectInstance.Connect(SignalNameGd.ChildOrderChanged, Callable.From(EmitSignalChildOrderChanged));
		ObjectInstance.Connect(SignalNameGd.EditorDescriptionChanged, Callable.From<Node>(EmitSignalEditorDescriptionChanged));
		ObjectInstance.Connect(SignalNameGd.EditorStateChanged, Callable.From(EmitSignalEditorStateChanged));
		ObjectInstance.Connect(SignalNameGd.Ready, Callable.From(EmitSignalReady));
		ObjectInstance.Connect(SignalNameGd.Renamed, Callable.From(EmitSignalRenamed));
		ObjectInstance.Connect(SignalNameGd.ReplacingBy, Callable.From<Node>(EmitSignalReplacingBy));
		ObjectInstance.Connect(SignalNameGd.TreeEntered, Callable.From(EmitSignalTreeEntered));
		ObjectInstance.Connect(SignalNameGd.TreeExited, Callable.From(EmitSignalTreeExited));
		ObjectInstance.Connect(SignalNameGd.TreeExiting, Callable.From(EmitSignalTreeExiting));
	}

	private void DisconnectNodeSignals()
	{
		if (ObjectInstance == null) return;
		ObjectInstance.Disconnect(SignalNameGd.ChildEnteredTree, Callable.From<Node>(EmitSignalChildEnteredTree));
		ObjectInstance.Disconnect(SignalNameGd.ChildExitingTree, Callable.From<Node>(EmitSignalChildExitingTree));
		ObjectInstance.Disconnect(SignalNameGd.ChildOrderChanged, Callable.From(EmitSignalChildOrderChanged));
		ObjectInstance.Disconnect(SignalNameGd.EditorDescriptionChanged, Callable.From<Node>(EmitSignalEditorDescriptionChanged));
		ObjectInstance.Disconnect(SignalNameGd.EditorStateChanged, Callable.From(EmitSignalEditorStateChanged));
		ObjectInstance.Disconnect(SignalNameGd.Ready, Callable.From(EmitSignalReady));
		ObjectInstance.Disconnect(SignalNameGd.Renamed, Callable.From(EmitSignalRenamed));
		ObjectInstance.Disconnect(SignalNameGd.ReplacingBy, Callable.From<Node>(EmitSignalReplacingBy));
		ObjectInstance.Disconnect(SignalNameGd.TreeEntered, Callable.From(EmitSignalTreeEntered));
		ObjectInstance.Disconnect(SignalNameGd.TreeExited, Callable.From(EmitSignalTreeExited));
		ObjectInstance.Disconnect(SignalNameGd.TreeExiting, Callable.From(EmitSignalTreeExiting));
	}

	[Signal] public delegate void ChildEnteredTreeEventHandler(Node node);
	[Signal] public delegate void ChildExitingTreeEventHandler(Node node);
	[Signal] public delegate void ChildOrderChangedEventHandler();
	[Signal] public delegate void EditorDescriptionChangedEventHandler(Node node);
	[Signal] public delegate void EditorStateChangedEventHandler();
	[Signal] public delegate void ReadyEventHandler();
	[Signal] public delegate void RenamedEventHandler();
	[Signal] public delegate void ReplacingByEventHandler(Node node);
	[Signal] public delegate void TreeEnteredEventHandler();
	[Signal] public delegate void TreeExitedEventHandler();
	[Signal] public delegate void TreeExitingEventHandler();

	public static class SignalNameGd
	{
		public static readonly StringName
			Ready = "ready",
			Renamed = "renamed",
			TreeEntered = "tree_entered",
			TreeExiting = "tree_exiting",
			TreeExited = "tree_exited",
			ChildEnteredTree = "child_entered_tree",
			ChildExitingTree = "child_exiting_tree",
			ChildOrderChanged = "child_order_changed",
			ReplacingBy = "replacing_by",
			EditorDescriptionChanged = "editor_description_changed",
			EditorStateChanged = "editor_state_changed";
	}

}
