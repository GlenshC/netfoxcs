using System;
using Godot;

namespace Netfox;
using TransferMode = MultiplayerPeer.TransferModeEnum;
public partial class NetworkCommandServer : NativeWrapper<Node>
{
	protected override StringName GdClassName => "_NetworkCommandServer";

	internal NetworkCommandServer(Node node) : base(node)
	{}

	#region Methods

	/// <summary>
	/// Registers a command at the next available ID.
	/// </summary>
	/// <param name="handler">The callable handler to execute when the command is invoked.</param>
	/// <param name="mode">The transfer mode to use for the command.</param>
	/// <param name="channel">The channel to use for the command.</param>
	/// <returns>The registered <see cref="_NetworkCommandServer.Command"/> object.</returns>
	public Command RegisterCommand(Action<int, byte[]> handler, TransferMode mode = TransferMode.Reliable, int channel = 0)
	{
		return new Command((RefCounted)ObjectInstance.Call(MethodNameGd.RegisterCommand, Callable.From(handler), (int)mode, channel));
	}
	/// <summary>
	/// Registers a command at a specific index.
	/// </summary>
	/// <remarks>
	/// A specific ID should only be registered once. Doing otherwise will trigger an assert in the editor, but will overwrite the previous command in release.
	/// </remarks>
	/// <param name="command">The specific index/ID to register the command at.</param>
	/// <param name="handler">The callable handler to execute when the command is invoked.</param>
	/// <param name="mode">The transfer mode to use for the command.</param>
	/// <param name="channel">The channel to use for the command.</param>
	/// <returns>The registered <see cref="_NetworkCommandServer.Command"/> object.</returns>
	public Command RegisterCommandAt(int command, Action<int, byte[]> handler, TransferMode mode = TransferMode.Reliable, int channel = 0)
	{
		return new Command((RefCounted)ObjectInstance.Call(MethodNameGd.RegisterCommandAt, command, Callable.From(handler), (int)mode, channel));
	}
	/// <summary>
	/// Sends a command with a specified index and data.
	/// </summary>
	/// <param name="command">The index of the command to send.</param>
	/// <param name="data">The payload data to transmit with the command.</param>
	/// <param name="targetPeer">The target peer ID to send the command to.</param>
	/// <param name="mode">The transfer mode to use for sending.</param>
	/// <param name="channel">The channel to use for sending.</param>
	public void SendCommand(int command, byte[] data, int targetPeer = 0, TransferMode mode = TransferMode.Reliable, int channel = 0)
	{
		ObjectInstance.Call(MethodNameGd.SendCommand, command, data, targetPeer, (int)mode, channel);
	}
	/// <summary>
	/// Returns a value indicating whether the specified packet is a command packet.
	/// </summary>
	/// <remarks>
	/// Always returns true if RPCs are used for transmitting commands.
	/// </remarks>
	/// <param name="packet">The packet bytes to check.</param>
	/// <returns><c>true</c> if the packet is a command packet; otherwise, <c>false</c>.</returns>
	public bool IsCommandPacket(byte[] packet)
	{
		return (bool)ObjectInstance.Call(MethodNameGd.IsCommandPacket, packet);
	}
	/// <summary>
	/// Returns the prefix bytes for command packets.
	/// </summary>
	/// <remarks>
	/// Can be used to avoid conflicts between command packets and game packets.
	/// </remarks>
	/// <returns>A <see cref="PackedByteArray"/> containing the prefix bytes.</returns>
	public byte[] GetCommandPacketPrefix(int sender, int command, byte[] packet)
	{
		return (byte[])ObjectInstance.Call(MethodNameGd.GetCommandPacketPrefix, sender, command, packet);
	}

	#endregion

	#region StringName Constants

	static class MethodNameGd
	{
		public static readonly StringName
			RegisterCommand = "register_command",
			RegisterCommandAt = "register_command_at",
			SendCommand = "send_command",
			IsCommandPacket = "is_command_packet",
			GetCommandPacketPrefix = "get_command_packet_prefix";
	}

	#endregion
}
