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
        /// <param name="simVarName"></param>
        /// <param name="unitName"></param>
        /// <param name="dataType"></param>
        public SimProperty(string simVarName, string unitName, SIMCONNECT_DATATYPE dataType)
        {
            Name = simVarName;
            Unit = unitName;
            DataType = dataType;
        }

        /// <summary>
        /// Creates an initialized instance of the <see cref="SimProperty"/> class.
        /// </summary>
        /// <param name="simVarName"></param>
        /// <param name="unitId"></param>
        /// <param name="dataType"></param>
        public SimProperty(string simVarName, FsUnit unitId, SIMCONNECT_DATATYPE dataType)
        {
            Name = simVarName;
            Unit = FsUnitFactory.GetUnitName(unitId);
            DataType = dataType;
        }

        /// <summary>
        /// Creates an initialized instance of the <see cref="SimProperty"/> class.
        /// </summary>
        /// <param name="simVarId"></param>
        /// <param name="unitName"></param>
        /// <param name="dataType"></param>
        public SimProperty(FsSimVar simVarId, string unitName, SIMCONNECT_DATATYPE dataType)
        {
            Name = FsSimVarFactory.GetSimVarCode(simVarId);
            Unit = unitName;
            DataType = dataType;
        }

        /// <summary>
        /// Creates an initialized instance using enums for known values.
        /// </summary>
        /// <param name="simVarId"></param>
        /// <param name="unit"></param>
        /// <param name="dataType"></param>
        public SimProperty(FsSimVar simVarId, FsUnit unitId, SIMCONNECT_DATATYPE dataType)
        {
            Name = FsSimVarFactory.GetSimVarCode(simVarId);
            Unit = FsUnitFactory.GetUnitName(unitId);
            DataType = dataType;
        }
    }
}