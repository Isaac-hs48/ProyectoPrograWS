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
    public class blActivo
    {
        public List<clsActivo> GetAssets(ref string pError)
        {
            List<clsActivo> assets = new List<clsActivo>();

            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader reader;

                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.spSelectActivos);

                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clsActivo vAsset = ClsShared.FillObjectProperties<clsActivo>(reader);

                    assets.Add(vAsset);
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

            return assets;
        }

        public bool InsertAsset(clsActivo pClsActivo, ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.spInsertActivo);

                cmd.Parameters.Add(new SqlParameter("@descripcion", pClsActivo.descripcion));

                cmd.Parameters.Add(new SqlParameter("@precioColones", pClsActivo.precioColones));

                cmd.Parameters.Add(new SqlParameter("@vidaUtilAnos", pClsActivo.vidaUtilAnos));

                cmd.Parameters.Add(new SqlParameter("@valorDesechoColones", pClsActivo.valorDesechoColones));

                cmd.Parameters.Add(new SqlParameter("@idCreadoPor", pClsActivo.IdCreadoPor));

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

        public bool UpdateAsset(clsActivo pClsActivo, ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.spUpdateActivos);

                cmd.Parameters.Add(new SqlParameter("@idActivo", pClsActivo.idActivo));

                cmd.Parameters.Add(new SqlParameter("@descripcion", pClsActivo.descripcion));

                cmd.Parameters.Add(new SqlParameter("@precioColones", pClsActivo.precioColones));

                cmd.Parameters.Add(new SqlParameter("@vidaUtilAnos", pClsActivo.vidaUtilAnos));

                cmd.Parameters.Add(new SqlParameter("@valorDesechoColones", pClsActivo.valorDesechoColones));

                cmd.Parameters.Add(new SqlParameter("@idModificadoPor", pClsActivo.IdModificadoPor));

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

        public bool DeleteAsset(int pIdActivo, ref string pError)
        {
            SqlConnection conn = new SqlConnection(Connection.Connection.GetConnectionString());

            SqlCommand cmd = new SqlCommand();

            bool success = false;

            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = ClsShared.GetEnumPropertyName(ClsConstants.HHVentasSegurosObjects.spDeleteActivo);

                cmd.Parameters.Add(new SqlParameter("@idActivo", pIdActivo));

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