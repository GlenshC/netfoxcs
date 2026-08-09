using Godot;

namespace Netfox;

public partial class Command: NativeWrapper<RefCounted>
{
	protected override StringName GdClassName => "RefCounted";

	public Command(RefCounted resource) : base(resource)
	{}

	#region Methods

	public void Send(byte[] data, int targetPeer = 0)
	{
		ObjectInstance.Call(MethodNameGd.Send, data, targetPeer);
	}

	#endregion

	#region StringName Constants

	static class MethodNameGd
	{
		public static readonly StringName
			Send = "send";
	}

	#endregion
}
