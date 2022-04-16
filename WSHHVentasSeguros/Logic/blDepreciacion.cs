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
        public bool InsertDepretiation(ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.spDepreciacion);

                conn.Open();

                int vAffectedRows = cmd.ExecuteNonQuery();

                if (vAffectedRows > 0) success = true;
            }
            catch (Exception ex)
            {
                success = false;
                pError = $"Error en {MethodBase.GetCurrentMethod().Name}. Detalle: {ex.Message}";
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Close();
                conn = null;
            }

            return success;
        }
    }
}