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
        event EventHandler ConnectionChanged;

        /// <summary>
        /// The <see cref="FsDataReceived"/> event is raised when data has been received from Flight Simulator.
        /// </summary>
        event EventHandler<FsDataReceivedEventArgs> FsDataReceived;

        /// <summary>
        /// The <see cref="FsError"/> event is raised when an error has been raised by SimConnect.
        /// </summary>
        event EventHandler<FsErrorEventArgs> FsError;

        /// <summary>
        /// Gets a boolean value indication whether a connection to Flight Simulator is established.
        /// </summary>
        bool Connected { get; }

        /// <summary>
        /// Gets or sets where to write the SimConnect.cfg file, that specifies how to connect to Flight Simulator.
        /// </summary>
        SimConnectFileLocation SimConnectFileLocation { get; set; }

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
        /// Requests data from Flight Simulator.
        /// </summary>
        void RequestData(Enum requestId);

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
        /// Updated data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        void UpdateData<T>(Enum id, T data);
    }
}