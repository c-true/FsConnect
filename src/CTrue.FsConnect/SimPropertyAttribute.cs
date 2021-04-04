using System;
using Microsoft.FlightSimulator.SimConnect;

namespace CTrue.FsConnect
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SimPropertyAttribute : Attribute
    {
        public string Name { get; set; } = null;
        
        public string Unit { get; set; } = null;

        public FsUnit? UnitId { get; set; } = null;

        public SIMCONNECT_DATATYPE DataType { get; set; } = SIMCONNECT_DATATYPE.INVALID;
    }
}