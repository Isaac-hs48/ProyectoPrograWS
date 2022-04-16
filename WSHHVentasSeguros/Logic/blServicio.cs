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
    public class blServicio
    {
        public List<clsServicio> GetServices(ref string pError)
        {
            List<clsServicio> services = new List<clsServicio>();

            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader reader;

                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.spSelectServicios);

                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clsServicio vService = ClsShared.FillObjectProperties<clsServicio>(reader);

                    services.Add(vService);
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

            return services;
        }

        public bool InsertService(clsServicio pClsServicio, ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.spInsertServicio);

                cmd.Parameters.Add(new SqlParameter("@tipoServicio", pClsServicio.tipoServicio));

                cmd.Parameters.Add(new SqlParameter("@precioColones", pClsServicio.precioColones));

                cmd.Parameters.Add(new SqlParameter("@idCreadoPor", pClsServicio.IdCreadoPor));

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

        public bool UpdateService(clsServicio pClsServicio, ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.spUpdateServicio);

                cmd.Parameters.Add(new SqlParameter("@idServicio", pClsServicio.idServicio));

                cmd.Parameters.Add(new SqlParameter("@tipoServicio", pClsServicio.tipoServicio));

                cmd.Parameters.Add(new SqlParameter("@precioColones", pClsServicio.precioColones));

                cmd.Parameters.Add(new SqlParameter("@idModificadoPor", pClsServicio.IdModificadoPor));

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

        public bool DeleteService(int pIdServicio, ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.spDeleteServicios);

                cmd.Parameters.Add(new SqlParameter("@idServicio", pIdServicio));

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