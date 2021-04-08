using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Microsoft.FlightSimulator.SimConnect;

namespace CTrue.FsConnect
{
    /// <summary>
    /// The <see cref="SimVarReflector"/> analyzes a type and determines a SimVar definition based on types, property names and the use of the <see cref="SimVarAttribute"/>.
    /// </summary>
    public class SimVarReflector
    {
        /// <summary>
        /// Gets a collection of <see cref="SimVar"/> instances based on reflection of the provided stuct.
        /// </summary>
        /// <typeparam name="T">The struct</typeparam>
        /// <returns>A list of <see cref="SimVar"/> instances.</returns>
        public List<SimVar> GetSimVars<T>() where T : struct
        {
            List<SimVar> simProperties = new List<SimVar>();

            Type type = typeof(T);

            var fields = type.GetFields();

            foreach (var field in fields)
            {
                SimVar simVar = new SimVar();

                SimVarAttribute attr = field.GetCustomAttribute<SimVarAttribute>();

                //
                // Name
                //

                simVar.Name = GetName(field, attr);

                //
                // Unit
                //

                simVar.Unit = GetUnit(field, attr);

                //
                // Data type
                // 

                simVar.DataType = GetDataType(field, attr);

                simProperties.Add(simVar);
            }

            return simProperties;
        }

        private string GetName(FieldInfo fieldInfo, SimVarAttribute attr)
        {
            if (attr != null && attr.NameId != FsSimVar.None)
            {
                string theSimVarName = FsSimVarFactory.GetSimVarName(attr.NameId);

                return attr.Instance > 0 ? $"{theSimVarName}:{attr.Instance}" : theSimVarName;
            }

            if (!string.IsNullOrEmpty(attr?.Name))
            {
                return attr.Name;
            }

            // Find any instance put in the name.
            Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
            Match result = re.Match(fieldInfo.Name);

            string name = fieldInfo.Name;
            int? instance = attr?.Instance;

            if (result.Groups.Count > 1)
            {
                name = result.Groups[1].Value;
                instance = int.Parse(result.Groups[2].Value);
            }

            // Try to lookup variations of the SimVar name using aNyCaSe and Under_Score
            string simVarName = FsSimVarFactory.GetSimVarName(name);
            if (simVarName != null)
                name = simVarName;

            if(instance > 0)
                name = $"{name}:{instance}";

            return name;
        }

        private string GetUnit(FieldInfo fieldInfo, SimVarAttribute attr)
        {
            if (attr != null && attr.UnitId != FsUnit.Undefined)
            {
                return FsUnitFactory.GetUnitName(attr.UnitId);
            }
            
            if (!string.IsNullOrEmpty(attr?.Unit))
            {
                return attr.Unit;
            }
            
            return "";
        }

        private SIMCONNECT_DATATYPE GetDataType(FieldInfo field, SimVarAttribute attr)
        {
            if (attr != null && attr.DataType != SIMCONNECT_DATATYPE.INVALID)
            {
                return attr.DataType;
            }

            if (field.FieldType == typeof(string))
            {
                MarshalAsAttribute marshallAsAttr = field.GetCustomAttribute<MarshalAsAttribute>();
                
                if(marshallAsAttr != null)
                {
                    int stringSize = marshallAsAttr.SizeConst;

                    if(stringSize == 8)
                        return SIMCONNECT_DATATYPE.STRING8;
                    if (stringSize == 32)
                        return SIMCONNECT_DATATYPE.STRING32;
                    if (stringSize == 64)
                        return SIMCONNECT_DATATYPE.STRING64;
                    if (stringSize == 128)
                        return SIMCONNECT_DATATYPE.STRING128;
                    if (stringSize ==256)
                        return SIMCONNECT_DATATYPE.STRING256;
                    if (stringSize == 260)
                        return SIMCONNECT_DATATYPE.STRING260;
                }

                // String of undefined length. Set to STRINGV
                // TODO: Consider throwing exception.
                return SIMCONNECT_DATATYPE.STRINGV;
            }

            if (field.FieldType == typeof(float))
                return SIMCONNECT_DATATYPE.FLOAT32;

            if (field.FieldType == typeof(bool))
                return SIMCONNECT_DATATYPE.INT32;

            // Default data type
            return SIMCONNECT_DATATYPE.FLOAT64;
        }
    }
}