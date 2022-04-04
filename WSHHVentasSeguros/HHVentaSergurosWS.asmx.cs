using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSHHVentasSeguros.Data;
using WSHHVentasSeguros.Logic;

namespace WSHHVentasSeguros
{
    /// <summary>
    /// Descripción breve de HHVentaSergurosWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class HHVentaSergurosWS : System.Web.Services.WebService
    {

        [WebMethod]
        public List<ClsUsuario> GetUsers()
        {
            blUsuario blUsuario = new blUsuario();

            string vError = string.Empty;

            return blUsuario.GetUsers(ref vError);
        }

        [WebMethod]
        public string InsertUser(string nombre, string usuario, string contrasena)
        {
            blUsuario blUsuario = new blUsuario();

            ClsUsuario user = new ClsUsuario
            {
                NombreCompleto = nombre,
                NombreUsuario = usuario,
                Contrasena = contrasena
            };

            string vError = string.Empty;

            bool success = blUsuario.InsertUser(user, ref vError);

            if (success)
            {
                return "Usuario creado correctamente";
            }

            return vError;
        }

        [WebMethod]
        public string UpdateUser(int idUsuario, string nombre, string usuario, string contrasena)
        {
            blUsuario blUsuario = new blUsuario();

            ClsUsuario user = new ClsUsuario
            {
                IdUsuario = idUsuario,
                NombreCompleto = nombre,
                NombreUsuario = usuario,
                Contrasena = contrasena
            };

            string vError = string.Empty;

            bool success = blUsuario.UpdateUser(user, ref vError);

            if (success)
            {
                return "Usuario modificado correctamente";
            }

            return vError;
        }

        [WebMethod]
        public string DeleteUser(int pIdUsuario)
        {
            blUsuario blUsuario = new blUsuario();

            string vError = string.Empty;

            bool success = blUsuario.DeleteUser(pIdUsuario, ref vError);

            if (success)
            {
                return "Usuario eliminado correctamente";
            }

            return vError;
        }
    }
}
