using System;
using Microsoft.FlightSimulator.SimConnect;

namespace CTrue.FsConnect
{
    /// <summary>
    /// The <see cref="SimVarAttribute"/> decorates a field in a SimVar structure so that the correct data definition can be generated automatically.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SimVarAttribute : Attribute
    {
        /// <summary>
        /// The name of the SimVar.
        /// </summary>
        public string Name { get; set; } = null;

        /// <summary>
        /// The id of the SimVar, see the <see cref="FsSimVar"/> enum for supported ids.
        /// </summary>
        public FsSimVar NameId { get; set; } = FsSimVar.None;

        /// <summary>
        /// The instance id of the SimVar, such as the engine for a SimVar that can return data for individual instances.
        /// </summary>
        public int Instance { get; set; } = 0;

        /// <summary>
        /// The unit name of the SimVar.
        /// </summary>
        public string Unit { get; set; } = null;

        /// <summary>
        /// The unit id of the SimVar, see the <see cref="FsUnit"/> enum for supported id.
        /// </summary>
        public FsUnit UnitId { get; set; } = FsUnit.Undefined;

        /// <summary>
        /// The SimConnect data type representing the SimVar data.
        /// </summary>
        public SIMCONNECT_DATATYPE DataType { get; set; } = SIMCONNECT_DATATYPE.INVALID;
    }
}