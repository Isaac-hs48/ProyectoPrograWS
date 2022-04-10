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
        #region Usuarios
        [WebMethod]
        public List<ClsUsuario> GetUsers()
        {
            BlUsuario blUsuario = new BlUsuario();

            string vError = string.Empty;

            return blUsuario.GetUsers(ref vError);
        }

        [WebMethod]
        public string InsertUser(string nombre, string usuario, string contrasena, string idCreadoPor)
        {
            BlUsuario blUsuario = new BlUsuario();

            ClsUsuario user = new ClsUsuario
            {
                NombreCompleto = nombre,
                NombreUsuario = usuario,
                Contrasena = contrasena,
                IdCreadoPor = String.IsNullOrEmpty(idCreadoPor) ? -1 : Convert.ToInt32(idCreadoPor),
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
        public string UpdateUser(int idUsuario, string nombre, string usuario, string contrasena, int idModificadoPor)
        {
            BlUsuario blUsuario = new BlUsuario();

            ClsUsuario user = new ClsUsuario
            {
                IdUsuario = idUsuario,
                NombreCompleto = nombre,
                NombreUsuario = usuario,
                Contrasena = contrasena,
                IdModificadoPor = idModificadoPor
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
            BlUsuario blUsuario = new BlUsuario();

            string vError = string.Empty;

            bool success = blUsuario.DeleteUser(pIdUsuario, ref vError);

            if (success)
            {
                return "Usuario eliminado correctamente";
            }

            return vError;
        }
#endregion
        #region Clientes
        [WebMethod]
        public List<ClsCliente> GetCustomers()
        {
            BlCliente blCliente = new BlCliente();

            string vError = string.Empty;

            return blCliente.GetCustomers(ref vError);
        }

        [WebMethod]
        public string InsertCustomer(string nombre, string tipoCedula, string numeroCedula, string numeroTelefono, string correoElectronico, int idCreadoPor)
        {
            BlCliente blCliente = new BlCliente();

            ClsCliente customer = new ClsCliente
            {
                NombreCompleto = nombre,
                TipoCedula = tipoCedula,
                NumeroCedula = numeroCedula,
                NumeroTelefono = numeroTelefono,
                CorreoElectronico = correoElectronico,
                IdCreadoPor = idCreadoPor
            };

            string vError = string.Empty;

            bool success = blCliente.InserCustomer(customer, ref vError);

            if (success)
            {
                return "Cliente creado correctamente";
            }

            return vError;
        }

        [WebMethod]
        public string UpdateCustomer(int idCliente, string nombre, string tipoCedula, string numeroCedula, string numeroTelefono, string correoElectronico, int idModificadoPor)
        {
            BlCliente blCliente = new BlCliente();

            ClsCliente customer = new ClsCliente
            {
                IdCliente = idCliente,
                NombreCompleto = nombre,
                TipoCedula = tipoCedula,
                NumeroCedula = numeroCedula,
                NumeroTelefono = numeroTelefono,
                CorreoElectronico = correoElectronico,
                IdModificadoPor = idModificadoPor
            };

            string vError = string.Empty;

            bool success = blCliente.UpdateCustomer(customer, ref vError);

            if (success)
            {
                return "Cliente modificado correctamente";
            }

            return vError;
        }

        [WebMethod]
        public string DeleteCustomer(int pIdCustomer)
        {
            BlCliente blCliente = new BlCliente();

            string vError = string.Empty;

            bool success = blCliente.DeleteCustomer(pIdCustomer, ref vError);

            if (success)
            {
                return "Cliente eliminado correctamente";
            }

            return vError;
        }
        #endregion
    }
}
