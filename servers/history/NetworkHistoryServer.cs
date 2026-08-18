using Godot;

namespace Netfox;

public partial class NetworkHistoryServer : NodeWrapper<Node>
{
	protected override StringName GdClassName => "_NetworkHistoryServer";

	internal NetworkHistoryServer(Node node) : base(node)
	{}

	public void Reload() => ObjectInstance.Call(MethodNameGd.Reload);


	#region StringName Constants

	static class MethodNameGd
	{
		public static readonly StringName
			Reload = "reload";
	}

	#endregion
}
