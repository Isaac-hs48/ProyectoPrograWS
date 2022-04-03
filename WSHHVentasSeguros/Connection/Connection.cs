using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WSHHVentasSeguros.Connection
{
    public class Connection
    {
        public static string GetConnectionString()
        {
            try
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["BDContext"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en {MethodBase.GetCurrentMethod().Name}. Detalle: {ex.Message}");
            }
        }
    }
}