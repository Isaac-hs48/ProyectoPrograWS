using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using WSHHVentasSeguros.Data;
using WSHHVentasSeguros.Shared;

namespace WSHHVentasSeguros.Logic
{
    public class blDepreciacion
    {
        public List<clsDepreciacion> GenerateDeprecation(int idActivo ,ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            List<clsDepreciacion> deprecations = new List<clsDepreciacion>();

            try
            {
                SqlDataReader reader;

                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.spDepreciacion);

                cmd.Parameters.Add(new SqlParameter("@IdActivo", idActivo));

                conn.Open();

                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    clsDepreciacion depreciacion = Shared.ClsShared.FillObjectProperties<clsDepreciacion>(reader);

                    deprecations.Add(depreciacion);
                }
            }
            catch (Exception ex)
            {
                pError = $"Error en {MethodBase.GetCurrentMethod().Name}. Detalle: {ex.Message}";
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Close();
                conn = null;
            }

            return deprecations;
        }
    }
}