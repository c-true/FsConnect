using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.FlightSimulator.SimConnect;

namespace CTrue.FsConnect
{
    public class SimPropertyReflector
    {
        public List<SimProperty> GetSimProperties<T>() where T : struct
        {
            List<SimProperty> simProperties = new List<SimProperty>();

            Type type = typeof(T);

            var fields = type.GetFields();

            foreach (var field in fields)
            {
                SimProperty simProperty = new SimProperty();

                SimPropertyAttribute attr = field.GetCustomAttribute<SimPropertyAttribute>();

                //
                // Name
                //

                simProperty.Name = GetName(field, attr);

                //
                // Unit
                //

                simProperty.Unit = GetUnit(field, attr);

                //
                // Data type
                // 

                simProperty.DataType = GetDataType(field, attr);

                simProperties.Add(simProperty);
            }

            return simProperties;
        }

        private string GetName(FieldInfo fieldInfo, SimPropertyAttribute attr)
        {
            if (attr != null && attr.NameId != FsSimVar.None)
            {
                return FsSimVarFactory.GetSimVarCode(attr.NameId);
            }

            if (!string.IsNullOrEmpty(attr?.Name))
            {
                return attr.Name;
            }
            
            // Try to lookup variations of the SimVar name using PascalCase and Under_Score
            string simVarName = FsSimVarFactory.GetSimVarCode(fieldInfo.Name);
            if (simVarName != null)
                return simVarName;

            return fieldInfo.Name;
        }

        private string GetUnit(FieldInfo fieldInfo, SimPropertyAttribute attr)
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

        private SIMCONNECT_DATATYPE GetDataType(FieldInfo field, SimPropertyAttribute attr)
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
            
            // Default data type
            return SIMCONNECT_DATATYPE.FLOAT64;
        }
    }
}