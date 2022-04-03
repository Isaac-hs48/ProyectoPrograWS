using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WSHHVentasSeguros.Shared
{
    public class ClsShared
    {
        /// <summary>
        /// Mapea el valor de los campos del objeto SqlDataReader al objeto del tipo de a clase enviada, siempre que los nombres de
        /// las propiedades de la clase empiecen con el nombre del campo que devuelve viene en el objeto SqlDataReader.
        /// </summary>
        /// <typeparam name="T">Tipo de dato del objeto modelo</typeparam>
        /// <param name="_reader">Objeto SqlDataReader que contiene los campos consultados de la tabla</param>
        /// <param name="_object">Objeto de la clase que hace referecia a la tabla consltada</param>
        public static T FillObjectProperties<T>(SqlDataReader _reader) where T : new()
        {
            T _object = new T();

            for (int i = 0; i < _reader.FieldCount; i++)
            {
                string fieldName = _reader.GetName(i);

                if (String.IsNullOrEmpty(_reader[fieldName].ToString())) continue;

                object fieldValue = GetFieldValue(_reader, i);

                PropertyInfo[] objectProps = _object.GetType().GetProperties().OrderBy(prop => prop.Name.Length).ToArray();

                int fieldNameLength = fieldName.Length;

                foreach (PropertyInfo prop in objectProps)
                {
                    if (prop.Name.Length < fieldNameLength) continue;

                    if (fieldValue.GetType().Name != prop.PropertyType.Name) continue;

                    string propName = prop.Name.Substring(0, fieldNameLength);

                    if (propName.ToUpper().Contains(fieldName.ToUpper()))
                    {
                        prop.SetValue(_object, fieldValue);

                        break;
                    }
                }
            }

            return _object;
        }

        private static object GetFieldValue(SqlDataReader _reader, int _fieldIndex)
        {
            object value = null;

            switch (_reader.GetDataTypeName(_fieldIndex))
            {
                case "varchar":
                case "nvarchar":
                    value = Convert.ToString(_reader.GetValue(_fieldIndex));
                    break;
                case "int":
                    value = Convert.ToInt32(_reader.GetValue(_fieldIndex));
                    break;
                case "datetime":
                case "date":
                    value = Convert.ToDateTime(_reader.GetValue(_fieldIndex));
                    break;
                case "float":
                case "decimal":
                case "double":
                    value = Convert.ToDouble(_reader.GetValue(_fieldIndex));
                    break;
                case "bit":
                    value = Convert.ToBoolean(_reader.GetValue(_fieldIndex));
                    break;
                default:
                    break;
            }

            return value;
        }
        public static string GetEnumPropertyName<T>(T _dbObject)
        {
            return Enum.GetName(typeof(T), _dbObject);
        }
    }
}