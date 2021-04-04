using System;
using System.Collections.Generic;
using System.Reflection;
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

                if (!string.IsNullOrEmpty(attr?.Name))
                {
                    simProperty.Name = attr.Name;
                }
                else
                    simProperty.Name = field.Name;

                if (attr != null && attr.DataType != SIMCONNECT_DATATYPE.INVALID)
                {
                    simProperty.DataType = attr.DataType;
                }
                else
                {
                    if (field.FieldType == typeof(string))
                        simProperty.DataType = SIMCONNECT_DATATYPE.STRING256;
                    else
                        simProperty.DataType = SIMCONNECT_DATATYPE.FLOAT64;
                }

                if (!string.IsNullOrEmpty(attr?.Unit))
                {
                    simProperty.Unit = attr.Unit;
                }
                else
                    simProperty.Unit = "";

                simProperties.Add(simProperty);
            }

            return simProperties;
        }
    }
}