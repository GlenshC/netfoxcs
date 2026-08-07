namespace Netfox;

using Godot;

/// <summary><para>C# wrapper for Fox's Sake Studio's <see href="https://github.com/foxssake/netfox/">
/// netfox</see> addon.</para>
///
/// <para>Provides convenience signals for multiplayer games.</para>
///
/// <para>While the client start/stop and peer join/leave events are trivial, the
/// server side has no similar events. This means that if you'd like to add some
/// funcionality that should happen on server start, you either have to couple
/// the code (IE call it wherever you start the server) or introduce a custom
/// event to decouple your code from your network init code.</para>
///
/// <para>By providing these convenience events, you can forego all that and instead
/// just listen to a single signal that should work no matter what.</para>
///
/// <para><b>NOTE:</b> This class also manages <see cref="NetworkTime"/> start/stop,
/// so as long as network events are enabled, you don't need to manually call start/stop.</para>
///
/// <para>See the <see href="https://foxssake.github.io/netfox/latest/netfox/guides/network-events/">
/// NetworkEvents</see> netfox guide for more information.</para></summary>
public partial class NetworkEvents : NativeWrapper<Node>
{
	protected override StringName GdClassName => "_NetworkEvents";

#region Properties

    /// <summary><para>Whether the events are enabled</para>
    /// <para>Events are only emitted when it's enabled. Disabling this can free up some
    /// performance, as when enabled, the multiplayer API and the host are
    /// continuously checked for changes.</para></summary>
    public static bool Enabled
    {
        get { return (bool)_networkEventsGd.Get(PropertyNameGd.Enabled); }
        set { _networkEventsGd.Set(PropertyNameGd.Enabled, value); }
    }

#endregion

    static GodotObject _networkEventsGd;

    internal NetworkEvents(Node networkTimeGd): base(networkTimeGd)
    {
	    _networkEventsGd = ObjectInstance;
        _networkEventsGd.Connect(SignalNameGd.OnMultiplayerChange, Callable.From<MultiplayerApi, MultiplayerApi>(EmitSignalOnMultiplayerChange));
        _networkEventsGd.Connect(SignalNameGd.OnServerStart, Callable.From(EmitSignalOnServerStart));
        _networkEventsGd.Connect(SignalNameGd.OnServerStop, Callable.From(EmitSignalOnServerStop));
        _networkEventsGd.Connect(SignalNameGd.OnClientStart, Callable.From<long>(EmitSignalOnClientStart));
        _networkEventsGd.Connect(SignalNameGd.OnClientStop, Callable.From(EmitSignalOnClientStop));
        _networkEventsGd.Connect(SignalNameGd.OnPeerJoin, Callable.From<long>(EmitSignalOnPeerJoin));
        _networkEventsGd.Connect(SignalNameGd.OnPeerLeave, Callable.From<long>(EmitSignalOnPeerLeave));
    }

    private void DisconnectSignals()
    {
        _networkEventsGd.Disconnect(SignalNameGd.OnMultiplayerChange, Callable.From<MultiplayerApi, MultiplayerApi>(EmitSignalOnMultiplayerChange));
        _networkEventsGd.Disconnect(SignalNameGd.OnServerStart, Callable.From(EmitSignalOnServerStart));
        _networkEventsGd.Disconnect(SignalNameGd.OnServerStop, Callable.From(EmitSignalOnServerStop));
        _networkEventsGd.Disconnect(SignalNameGd.OnClientStart, Callable.From<long>(EmitSignalOnClientStart));
        _networkEventsGd.Disconnect(SignalNameGd.OnClientStop, Callable.From(EmitSignalOnClientStop));
        _networkEventsGd.Disconnect(SignalNameGd.OnPeerJoin, Callable.From<long>(EmitSignalOnPeerJoin));
        _networkEventsGd.Disconnect(SignalNameGd.OnPeerLeave, Callable.From<long>(EmitSignalOnPeerLeave));
    }

    protected override void Dispose(bool disposing)
    {
	    if (disposing)
	    {
		    DisconnectSignals();
	    }
	    base.Dispose(disposing);
    }

#region Signals

    /// <summary>Event emitted when the <see cref="MultiplayerApi"/> is changed.</summary>
    /// <param name="oldApi">The old <see cref="MultiplayerApi"/></param>
    /// <param name="newApi">The new <see cref="MultiplayerApi"/></param>
    [Signal]
    public delegate void OnMultiplayerChangeEventHandler(MultiplayerApi oldApi, MultiplayerApi newApi);

    /// <summary>Event emitted when the server starts.</summary>
    [Signal]
    public delegate void OnServerStartEventHandler();

    /// <summary>Event emitted when the server stops for any reason.</summary>
    [Signal]
    public delegate void OnServerStopEventHandler();

    /// <summary>Event emitted when the client starts.</summary>
    /// <param name="clientId">The client ID.</param>
    [Signal]
    public delegate void OnClientStartEventHandler(long clientId);

    /// <summary><para>Event emitted when the client stops.</para>
    /// <para>This can happen due to either the client itself or the server disconnecting
    /// for whatever reason.</para></summary>
    [Signal]
    public delegate void OnClientStopEventHandler();

    /// <summary>Event emitted when a new peer joins the game.</summary>
    /// <param name="peerId">The ID of the peer that joined.</param>
    [Signal]
    public delegate void OnPeerJoinEventHandler(long peerId);

    /// <summary>Event emitted when a peer leaves the game.</summary>
    /// <param name="peerId">The ID of the peer that left.</param>
    [Signal]
    public delegate void OnPeerLeaveEventHandler(long peerId);
#endregion

#region Methods

    /// <summary>Check if we're running as server.</summary>
    /// <returns>Whether this instance is a server</returns>
    public static bool IsServer() { return (bool)_networkEventsGd.Call(MethodNameGd.IsServer); }

#endregion

#region StringName Constants
    static class MethodNameGd
    {
        public static readonly StringName
            IsServer = "is_server";
    }
    static class PropertyNameGd
    {
        public static readonly StringName
            Enabled = "enabled";
    }
    static class SignalNameGd
    {
        public static readonly StringName
            OnMultiplayerChange = "on_multiplayer_change",
            OnServerStart = "on_server_start",
            OnServerStop = "on_server_stop",
            OnClientStart = "on_client_start",
            OnClientStop = "on_client_stop",
            OnPeerJoin = "on_peer_join",
            OnPeerLeave = "on_peer_leave";
    }
#endregion
}

