using Microsoft.FlightSimulator.SimConnect;

namespace CTrue.FsConnect
{
    /// <summary>
    /// Represents a simulation variable, used to define a data definition.
    /// </summary>
    public class SimVar
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
        /// Creates an uninitialized instance of the <see cref="SimVar"/> class.
        /// </summary>
        public SimVar()
        {
        }

        /// <summary>
        /// Creates an initialized instance of the <see cref="SimVar"/> class.
        /// </summary>
        /// <param name="simVarName"></param>
        /// <param name="unitName"></param>
        /// <param name="dataType"></param>
        public SimVar(string simVarName, string unitName, SIMCONNECT_DATATYPE dataType)
        {
            Name = simVarName;
            Unit = unitName;
            DataType = dataType;
        }

        /// <summary>
        /// Creates an initialized instance of the <see cref="SimVar"/> class.
        /// </summary>
        /// <param name="simVarName"></param>
        /// <param name="unitId"></param>
        /// <param name="dataType"></param>
        public SimVar(string simVarName, FsUnit unitId, SIMCONNECT_DATATYPE dataType)
        {
            Name = simVarName;
            Unit = FsUnitFactory.GetUnitName(unitId);
            DataType = dataType;
        }

        /// <summary>
        /// Creates an initialized instance of the <see cref="SimVar"/> class.
        /// </summary>
        /// <param name="simVarId"></param>
        /// <param name="unitName"></param>
        /// <param name="dataType"></param>
        public SimVar(FsSimVar simVarId, string unitName, SIMCONNECT_DATATYPE dataType)
        {
            Name = FsSimVarFactory.GetSimVarName(simVarId);
            Unit = unitName;
            DataType = dataType;
        }

        /// <summary>
        /// Creates an initialized instance using enums for known values.
        /// </summary>
        /// <param name="simVarId"></param>
        /// <param name="unitId"></param>
        /// <param name="dataType"></param>
        public SimVar(FsSimVar simVarId, FsUnit unitId, SIMCONNECT_DATATYPE dataType)
        {
            Name = FsSimVarFactory.GetSimVarName(simVarId);
            Unit = FsUnitFactory.GetUnitName(unitId);
            DataType = dataType;
        }

        /// <summary>
        /// Gets a textual representation of the SimVar.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name} in {Unit} as {DataType}";
        }
    }
}