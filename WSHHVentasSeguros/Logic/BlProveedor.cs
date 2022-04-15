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
    public class BlProveedor
    {
        public List<ClsProveedor> GetSuppliers(ref string pError)
        {
            List<ClsProveedor> Suppliers = new List<ClsProveedor>();

            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader reader;

                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.SP_SELECT_PROVEEDOR);

                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ClsProveedor vSupplier = ClsShared.FillObjectProperties<ClsProveedor>(reader);

                    Suppliers.Add(vSupplier);
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

            return Suppliers;
        }

        public bool InsertSupplier(ClsProveedor pClsProveedor, ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.SP_INSERT_PROVEEDOR);

                cmd.Parameters.Add(new SqlParameter("@nombreCompleto", pClsProveedor.NombreCompleto));

                cmd.Parameters.Add(new SqlParameter("@tipoCedula", pClsProveedor.TipoCedula));

                cmd.Parameters.Add(new SqlParameter("@numeroCedula", pClsProveedor.NumeroCedula));

                cmd.Parameters.Add(new SqlParameter("@numeroTelefono", pClsProveedor.NumeroTelefono));

                cmd.Parameters.Add(new SqlParameter("@correoElectronico", pClsProveedor.CorreoElectronico));

                cmd.Parameters.Add(new SqlParameter("@descripcion", pClsProveedor.Descripcion));

                cmd.Parameters.Add(new SqlParameter("@idCreadoPor", pClsProveedor.IdCreadoPor));

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

        public bool UpdateSupplier(ClsProveedor pClsProveedor, ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.SP_UPDATE_PROVEEDOR);

                cmd.Parameters.Add(new SqlParameter("@idProveedor", pClsProveedor.IdProveedor));

                cmd.Parameters.Add(new SqlParameter("@nombreCompleto", pClsProveedor.NombreCompleto));

                cmd.Parameters.Add(new SqlParameter("@tipoCedula", pClsProveedor.TipoCedula));

                cmd.Parameters.Add(new SqlParameter("@numeroCedula", pClsProveedor.NumeroCedula));

                cmd.Parameters.Add(new SqlParameter("@numeroTelefono", pClsProveedor.NumeroTelefono));

                cmd.Parameters.Add(new SqlParameter("@correoElectronico", pClsProveedor.CorreoElectronico));

                cmd.Parameters.Add(new SqlParameter("@descripcion", pClsProveedor.Descripcion));

                cmd.Parameters.Add(new SqlParameter("@idModificadoPor", pClsProveedor.IdModificadoPor));

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

        public bool DeleteSupplier(int pIdProveedor, ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.SP_DELETE_PROVEEDOR);

                cmd.Parameters.Add(new SqlParameter("@idProveedor", pIdProveedor));

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