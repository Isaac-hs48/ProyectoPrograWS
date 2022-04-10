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
    public class BlCliente
    {
        public List<ClsCliente> GetCustomers(ref string pError)
        {
            List<ClsCliente> customers = new List<ClsCliente>();

            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader reader;

                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.SP_SELECT_CLIENTES);

                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ClsCliente vCustomer = ClsShared.FillObjectProperties<ClsCliente>(reader);

                    customers.Add(vCustomer);
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

            return customers;
        }

        public bool InserCustomer(ClsCliente pClsCliente, ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.SP_INSERT_CLIENTE);

                cmd.Parameters.Add(new SqlParameter("@nombreCompleto", pClsCliente.NombreCompleto));

                cmd.Parameters.Add(new SqlParameter("@tipoCedula", pClsCliente.TipoCedula));

                cmd.Parameters.Add(new SqlParameter("@numeroCedula", pClsCliente.NumeroCedula));

                cmd.Parameters.Add(new SqlParameter("@numeroTelefono", pClsCliente.NumeroTelefono));

                cmd.Parameters.Add(new SqlParameter("@correoElectronico", pClsCliente.CorreoElectronico));

                cmd.Parameters.Add(new SqlParameter("@idCreadoPor", pClsCliente.IdCreadoPor));

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

        public bool UpdateCustomer(ClsCliente pClsCliente, ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.SP_UPDATE_CLIENTE);

                cmd.Parameters.Add(new SqlParameter("@idCliente", pClsCliente.IdCliente));

                cmd.Parameters.Add(new SqlParameter("@nombreCompleto", pClsCliente.NombreCompleto));

                cmd.Parameters.Add(new SqlParameter("@tipoCedula", pClsCliente.TipoCedula));

                cmd.Parameters.Add(new SqlParameter("@numeroCedula", pClsCliente.NumeroCedula));

                cmd.Parameters.Add(new SqlParameter("@numeroTelefono", pClsCliente.NumeroTelefono));

                cmd.Parameters.Add(new SqlParameter("@correoElectronico", pClsCliente.CorreoElectronico));

                cmd.Parameters.Add(new SqlParameter("@idModificadoPor", pClsCliente.IdModificadoPor));

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

        public bool DeleteCustomer(int pIdCliente, ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.SP_DELETE_CLIENTE);

                cmd.Parameters.Add(new SqlParameter("@idCliente", pIdCliente));

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