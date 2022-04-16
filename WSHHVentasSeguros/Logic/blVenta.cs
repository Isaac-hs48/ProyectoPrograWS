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
    public class blVenta
    {
        public List<clsVenta> GetSales(ref string pError)
        {
            List<clsVenta> sales = new List<clsVenta>();

            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader reader;

                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.spSelectVentas);

                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clsVenta vSale = ClsShared.FillObjectProperties<clsVenta>(reader);

                    sales.Add(vSale);
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

            return sales;
        }

        public bool InsertSale(clsVenta pClsVenta, ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.spInsertVenta);

                cmd.Parameters.Add(new SqlParameter("@idServicio", pClsVenta.idServicio));

                cmd.Parameters.Add(new SqlParameter("@idCliente", pClsVenta.idCliente));

                cmd.Parameters.Add(new SqlParameter("@identificacion", pClsVenta.identificacion));

                cmd.Parameters.Add(new SqlParameter("@totalColones", pClsVenta.totalColones));

                cmd.Parameters.Add(new SqlParameter("@idCreadoPor", pClsVenta.IdCreadoPor));

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

        public bool UpdateSale(clsVenta pClsVenta, ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.spUpdateVentas);

                cmd.Parameters.Add(new SqlParameter("@idVenta", pClsVenta.idVenta));

                cmd.Parameters.Add(new SqlParameter("@idServicio", pClsVenta.idServicio));

                cmd.Parameters.Add(new SqlParameter("@idCliente", pClsVenta.idCliente));

                cmd.Parameters.Add(new SqlParameter("@identificacion", pClsVenta.identificacion));

                cmd.Parameters.Add(new SqlParameter("@totalColones", pClsVenta.totalColones));

                cmd.Parameters.Add(new SqlParameter("@idModificadoPor", pClsVenta.IdModificadoPor));

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

        public bool DeleteSale(int pIdVenta, ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.spDeleteVenta);

                cmd.Parameters.Add(new SqlParameter("@idVenta", pIdVenta));

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