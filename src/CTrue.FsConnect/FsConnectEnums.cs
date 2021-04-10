using System;

namespace CTrue.FsConnect
{
    /// <summary>
    /// Describes how often data should be returned.
    /// </summary>
    public enum FsConnectPeriod
    {
        /// <summary>
        /// Specifies that the data is not to be sent.
        /// </summary>
        Never,
        /// <summary>
        /// Specifies that the data should be sent once only. Note that this is not an efficient way of receiving data frequently, use one of the other periods if there is a regular frequency to the data request.
        /// </summary>
        Once,
        /// <summary>
        /// Specifies that the data should be sent every visual (rendered) frame.
        /// </summary>
        VisualFrame,
        /// <summary>
        /// Specifies that the data should be sent every simulated frame, whether that frame is rendered or not.
        /// </summary>
        SimFrame,
        /// <summary>
        /// Specifies that the data should be sent once every second.
        /// </summary>
        Second,
    }

    [Flags]
    public enum FsConnectDRequestFlag
    {
        /// <summary>
        /// The default, data will be sent strictly according to the defined period.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Data will only be sent to the client when one or more values have changed. If this is the only flag set, then all the variables in a data definition will be returned if just one of the values changes.
        /// </summary>
        Changed = 1,
        /// <summary>
        /// 	Requested data will be sent in tagged format (datum ID/value pairs). Tagged format requires that a datum reference ID is returned along with the data value, in order that the client code is able to identify the variable. This flag is usually set in conjunction with the previous flag, but it can be used on its own to return all the values in a data definition in datum ID/value pairs. See the SIMCONNECT_RECV_SIMOBJECT_DATA structure for more details.
        /// </summary>
        Tagged = 2,
    }

    public enum FsConnectSimobjectType
    {
        User,
        All,
        Aircraft,
        Helicopter,
        Boat,
        Ground,
    }

#pragma warning disable 1591

    public enum FsException
    {
        None,
        Error,
        SizeMismatch,
        UnrecognizedId,
        Unopened,
        VersionMismatch,
        TooManyGroups,
        NameUnrecognized,
        TooManyEventNames,
        EventIdDuplicate,
        TooManyMaps,
        TooManyObjects,
        TooManyRequests,
        WeatherInvalidPort,
        WeatherInvalidMetar,
        WeatherUnableToGetObservation,
        WeatherUnableToCreateStation,
        WeatherUnableToRemoveStation,
        InvalidDataType,
        InvalidDataSize,
        DataError,
        InvalidArray,
        CreateObjectFailed,
        LoadFlightplanFailed,
        OperationInvalidForObjectType,
        IllegalOperation,
        AlreadySubscribed,
        InvalidEnum,
        DefinitionError,
        DuplicateId,
        DatumId,
        OutOfBounds,
        AlreadyCreated,
        ObjectOutsideRealityBubble,
        ObjectContainer,
        ObjectAi,
        ObjectAtc,
        ObjectSchedule,
    };

#pragma warning restore 1591
}