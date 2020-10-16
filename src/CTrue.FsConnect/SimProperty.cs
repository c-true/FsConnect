using Microsoft.FlightSimulator.SimConnect;

namespace CTrue.FsConnect
{
    /// <summary>
    /// The <see cref="SimProperty"/> class is used to define a data definition.
    /// </summary>
    public class SimProperty
    {
        /// <summary>
        /// The name of the definition. See the SimVars class in the Simvars example in the SDK.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The unit of the definition. See the Units class in the Simvars example in the SDK.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// The data type of the definition.
        /// </summary>
        public SIMCONNECT_DATATYPE DataType { get; set; }

        /// <summary>
        /// Creates an uninitialized instance of the <see cref="SimProperty"/> class.
        /// </summary>
        public SimProperty()
        {
        }

        /// <summary>
        /// Creates an initialized instance of the <see cref="SimProperty"/> class.
        /// </summary>
        public SimProperty(string name, string unit, SIMCONNECT_DATATYPE dataType)
        {
            Name = name;
            Unit = unit;
            DataType = dataType;
        }

        /// <summary>
        /// Creates an initialized instance using enums for known values.
        /// </summary>
        /// <param name="simVar"></param>
        /// <param name="unit"></param>
        /// <param name="dataType"></param>
        public SimProperty(FsSimVar simVar, FsUnit unit, SIMCONNECT_DATATYPE dataType)
        {
            Name = FsSimVarFactory.GetSimVarCode(simVar);
            Unit = UnitFactory.GetUnitCode(unit);
            DataType = dataType;
        }
    }
}