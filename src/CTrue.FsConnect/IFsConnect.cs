using System;
using System.Collections.Generic;
using Microsoft.FlightSimulator.SimConnect;

namespace CTrue.FsConnect
{
    /// <summary>
    /// A wrapper / helper class for connection to Flight Simulator.
    /// </summary>
    /// <remarks>
    /// This wrapper supports TCP IPv4 only, for the moment.
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
        /// Connects to Flight Simulator on the specified host name and TCP port.
        /// </summary>
        /// <param name="applicationName"></param>
        /// <param name="hostName"></param>
        /// <param name="port"></param>
        /// <remarks>
        /// A SimConnect.cfg file will be generated containing TCP connection information.
        /// Flight Simulator must be configured for remote TCP connections by editing the SimConnect.xml file that are part of the installation.
        /// </remarks>
        void Connect(string applicationName, string hostName, uint port);

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