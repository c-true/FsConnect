using System;
using System.Collections.Generic;
using Microsoft.FlightSimulator.SimConnect;

namespace CTrue.FsConnect
{
    /// <summary>
    /// A wrapper / helper class for connection to Microsoft Flight Simulator.
    /// </summary>
    /// <remarks>
    /// The <see cref="IFsConnect"/> wraps the SimConnect.dll and managed 
    /// </remarks>
    public interface IFsConnect : IDisposable
    {
        /// <summary>
        /// The <see cref="ConnectionChanged"/> event is raised when the connection status to Flight Simulator has changed.
        /// </summary>
        event EventHandler<bool> ConnectionChanged;

        /// <summary>
        /// The <see cref="FsDataReceived"/> event is raised when data has been received from Flight Simulator.
        /// </summary>
        event EventHandler<FsDataReceivedEventArgs> FsDataReceived;

        /// <summary>
        /// The <see cref="ObjectAddRemoveEventReceived"/> event is raised when sim objects have been added or removed from Flight Simulator.
        /// </summary>
        event EventHandler<ObjectAddRemoveEventReceivedEventArgs> ObjectAddRemoveEventReceived;

        /// <summary>
        /// The <see cref="FsError"/> event is raised when an error has been raised by SimConnect.
        /// </summary>
        event EventHandler<FsErrorEventArgs> FsError;

        /// <summary>
        /// The <see cref="AircraftLoaded"/> event is raised when the aircraft has loaded.
        /// </summary>
        event EventHandler AircraftLoaded;

        /// <summary>
        /// The <see cref="FlightLoaded"/> event is raised when the flight has loaded.
        /// </summary>
        event EventHandler FlightLoaded;

        /// <summary>
        /// The <see cref="PauseStateChanged"/> event is raised when the flight simulator has been paused or unpaused.
        /// </summary>
        event EventHandler<PauseStateChangedEventArgs> PauseStateChanged;

        /// <summary>
        /// The <see cref="SimStateChanged"/> event is raised when the flight simulator running state has changed.
        /// </summary>
        event EventHandler<SimStateChangedEventArgs> SimStateChanged;

        /// <summary>
        /// The <see cref="Crashed"/> event is raised when the aircraft has crashed.
        /// </summary>
        event EventHandler Crashed;

        /// <summary>
        /// Gets a boolean value indication whether a connection to Flight Simulator is established.
        /// </summary>
        bool Connected { get; }

        /// <summary>
        /// Gets or sets where to write the SimConnect.cfg file, that specifies how to connect to Flight Simulator. By default set to local.
        /// </summary>
        /// <remarks>
        /// The default beghavior is to write the file to the same location as the executing assembly, but this may cause problems if the application does not have write access to this location. As an alternative the file can be written to My Document, but this may cause issues with other SimConnect using applications.
        /// </remarks>
        SimConnectFileLocation SimConnectFileLocation { get; set; }

        /// <summary>
        /// The <see cref="ConnectionInfo"/> contains key information about the connection to the flight simulator, such as connection status and version information.
        /// </summary>
        FsConnectionInfo ConnectionInfo { get; }

        /// <summary>
        /// Gets whether the Flight Simulator is paused.
        /// </summary>
        bool Paused { get; }

        /// <summary>
        /// Connects to Flight Simulator using an existing SimConnect.cfg.
        /// </summary>
        /// <param name="applicationName">A name identifying this client to Flight Simulator.</param>
        /// <param name="configIndex">The index to a specified configuration in the SimConnect.cfg file. Default is index 0.</param>
        void Connect(string applicationName, uint configIndex = 0);

        /// <summary>
        /// Connects to Flight Simulator on the specified host name and port.
        /// </summary>
        /// <param name="applicationName">A name identifying this client to Flight Simulator.</param>
        /// <param name="hostName">A hostname or IP address.</param>
        /// <param name="port">A TCP or pipe port number.</param>
        /// <param name="protocol">The protocol to use to connect to Flight Simulator.</param>
        /// <remarks>
        /// A SimConnect.cfg file will be generated containing connection information.
        /// Flight Simulator must be configured for remote connections by editing the SimConnect.xml file that are part of the installation.
        /// </remarks>
        void Connect(string applicationName, string hostName, uint port, SimConnectProtocol protocol);
        
        /// <summary>
        /// Disconnects from Flight Simulator.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Registers data structures for requesting data from Flight Simulator.
        /// </summary>
        /// <remarks>
        /// A connection to Flight Simulator must have been established before registering data definitions.
        /// </remarks>
        void RegisterDataDefinition<T>(Enum id, List<SimProperty> definition) where T : struct;

        /// <summary>
        /// Displays a text in Flight Simulator.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="duration">Duration to display text, in seconds.</param>
        void SetText(string text, int duration);

        /// <summary>
        /// Toggle the pause status of the Flight Simulator.
        /// </summary>
        void Pause();

        /// <summary>
        /// Pauses or unpauses the simulator.
        /// </summary>
        /// <param name="pause">true to pause, false to unpause.</param>
        void Pause(bool pause);

        /// <summary>
        /// Requests data on a Sim object, periodically or/and when changed.
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="defineId"></param>
        /// <param name="objectId"></param>
        /// <param name="period"></param>
        /// <param name="flags"></param>
        /// <param name="interval"></param>
        /// <param name="origin"></param>
        /// <param name="limit"></param>
        void RequestDataOnSimObject(Enum requestId, Enum defineId, uint objectId, FsConnectPeriod period, FsConnectDRequestFlag flags, uint interval, uint origin, uint limit);

        /// <summary>
        /// Requests data from Flight Simulator.
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="defineId"></param>
        /// <param name="radius">Radius in meters. Should be less that 2000000 (200km).</param>
        /// <param name="type"></param>
        void RequestData(Enum requestId, Enum defineId, uint radius = 0, FsConnectSimobjectType type = FsConnectSimobjectType.User);

        /// <summary>
        /// Updated data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <param name="objectId"></param>
        /// <typeparam name="T"></typeparam>
        void UpdateData<T>(Enum id, T data, uint objectId = 1);

        /// <summary>
        /// Sets time
        /// </summary>
        /// <param name="hour"></param>
        void MapClientEvent(uint hour);
    }
}