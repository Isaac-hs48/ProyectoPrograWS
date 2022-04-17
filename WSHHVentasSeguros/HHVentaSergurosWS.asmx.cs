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

        #region Proveedores
        [WebMethod]
        public List<ClsProveedor> GetSuppliers()
        {
            BlProveedor blProveedor = new BlProveedor();

            string vError = string.Empty;

            return blProveedor.GetSuppliers(ref vError);
        }

        [WebMethod]
        public string InsertSupplier(string nombre, string tipoCedula, string numeroCedula, string numeroTelefono, string correoElectronico, string descripcion, int idCreadoPor)
        {
            BlProveedor blProveedor = new BlProveedor();

            ClsProveedor Supplier = new ClsProveedor
            {
                NombreCompleto = nombre,
                TipoCedula = tipoCedula,
                NumeroCedula = numeroCedula,
                NumeroTelefono = numeroTelefono,
                CorreoElectronico = correoElectronico,
                Descripcion = descripcion,
                IdCreadoPor = idCreadoPor
            };

            string vError = string.Empty;

            bool success = blProveedor.InsertSupplier(Supplier, ref vError);

            if (success)
            {
                return "Proveedor creado correctamente";
            }

            return vError;
        }

        [WebMethod]
        public string UpdateSupplier(int idProveedor, string nombre, string tipoCedula, string numeroCedula, string numeroTelefono, string correoElectronico, string descripcion, int idModificadoPor)
        {
            BlProveedor blProveedor = new BlProveedor();

            ClsProveedor Supplier = new ClsProveedor
            {
                IdProveedor = idProveedor,
                NombreCompleto = nombre,
                TipoCedula = tipoCedula,
                NumeroCedula = numeroCedula,
                NumeroTelefono = numeroTelefono,
                CorreoElectronico = correoElectronico,
                Descripcion =  descripcion,
                IdModificadoPor = idModificadoPor
            };

            string vError = string.Empty;

            bool success = blProveedor.UpdateSupplier(Supplier, ref vError);

            if (success)
            {
                return "Proveedor modificado correctamente";
            }

            return vError;
        }

        [WebMethod]
        public string DeleteSupplier(int pIdSupplier)
        {
            BlProveedor blProveedor = new BlProveedor();

            string vError = string.Empty;

            bool success = blProveedor.DeleteSupplier(pIdSupplier, ref vError);

            if (success)
            {
                return "Proveedor eliminado correctamente";
            }

            return vError;
        }
        #endregion

        #region Ventas
        [WebMethod]
        public List<clsVenta> GetSales()
        {
            blVenta blVenta = new blVenta();

            string vError = string.Empty;

            return blVenta.GetSales(ref vError);
        }

        [WebMethod]
        public string InsertSale(int idServicio, int idCliente, string identificacion, double totalColones, int idCreadoPor)
        {
            blVenta blVenta = new blVenta();

            clsVenta sale = new clsVenta
            {
                idServicio = idServicio,
                idCliente = idCliente,
                identificacion = identificacion,
                totalColones = totalColones,
                IdCreadoPor = idCreadoPor
            };

            string vError = string.Empty;

            bool success = blVenta.InsertSale(sale, ref vError);

            if (success)
            {
                return "Venta registrada correctamente";
            }

            return vError;
        }

        [WebMethod]
        public string UpdateSale(int idVenta, int idServicio, int idCliente, string identificacion, double totalColones, int idModificadoPor)
        {
            blVenta blVenta = new blVenta();

            clsVenta sale = new clsVenta
            {
                idVenta = idVenta,
                idServicio = idServicio,
                idCliente = idCliente,
                identificacion = identificacion,
                totalColones = totalColones,
                IdModificadoPor = idModificadoPor
            };

            string vError = string.Empty;

            bool success = blVenta.UpdateSale(sale, ref vError);

            if (success)
            {
                return "Venta modificada correctamente";
            }

            return vError;
        }

        [WebMethod]
        public string DeleteSale(int pIdVenta)
        {
            blVenta blVenta = new blVenta();

            string vError = string.Empty;

            bool success = blVenta.DeleteSale(pIdVenta, ref vError);

            if (success)
            {
                return "Venta eliminada correctamente";
            }

            return vError;
        }
        #endregion
        #region Servicios
        [WebMethod]
        public List<clsServicio> GetServices()
        {
            blServicio blServicio = new blServicio();

            string vError = string.Empty;

            return blServicio.GetServices(ref vError);
        }

        [WebMethod]
        public string InsertService(string tipoServicio, double precioColones, int idCreadoPor)
        {
            blServicio blServicio = new blServicio();

            clsServicio service = new clsServicio
            {
                tipoServicio = tipoServicio,
                precioColones = precioColones,
                IdCreadoPor = idCreadoPor
            };

            string vError = string.Empty;

            bool success = blServicio.InsertService(service, ref vError);

            if (success)
            {
                return "Servicio de seguro registrado correctamente";
            }

            return vError;
        }

        [WebMethod]
        public string UpdateService(int idServicio, string tipoServicio, double precioColones, int idModificadoPor)
        {
            blServicio blServicio = new blServicio();

            clsServicio service = new clsServicio
            {
                idServicio = idServicio,
                tipoServicio = tipoServicio,
                precioColones = precioColones,
                IdModificadoPor = idModificadoPor
            };

            string vError = string.Empty;

            bool success = blServicio.UpdateService(service, ref vError);

            if (success)
            {
                return "Servicio de seguros modificado correctamente";
            }

            return vError;
        }

        [WebMethod]
        public string DeleteService(int pIdServicio)
        {
            blServicio blServicio = new blServicio();

            string vError = string.Empty;

            bool success = blServicio.DeleteService(pIdServicio, ref vError);

            if (success)
            {
                return "Servicio de seguros eliminado correctamente";
            }

            return vError;
        }
        #endregion
        #region Activos
        [WebMethod]
        public List<clsActivo> GetAssets()
        {
            blActivo blActivo = new blActivo();

            string vError = string.Empty;

            return blActivo.GetAssets(ref vError);
        }

        [WebMethod]
        public string InsertAsset(string descripcion, double precioColones, int vidaUtilAnos, double valorDesechoColones, int idCreadoPor)
        {
            blActivo blActivo = new blActivo();

            clsActivo asset = new clsActivo
            {
                descripcion = descripcion,
                precioColones = precioColones,
                vidaUtilAnos = vidaUtilAnos,
                valorDesechoColones = valorDesechoColones,
                IdCreadoPor = idCreadoPor
            };

            string vError = string.Empty;

            bool success = blActivo.InsertAsset(asset, ref vError);

            if (success)
            {
                return "Activo registrado correctamente";
            }

            return vError;
        }

        [WebMethod]
        public string UpdateAsset(int idActivo, string descripcion, double precioColones, int vidaUtilAnos, double valorDesechoColones, int idModificadoPor)
        {
            blActivo blActivo = new blActivo();

            clsActivo asset = new clsActivo
            {
                idActivo = idActivo,
                descripcion = descripcion,
                precioColones = precioColones,
                vidaUtilAnos = vidaUtilAnos,
                valorDesechoColones = valorDesechoColones,
                IdModificadoPor = idModificadoPor
            };

            string vError = string.Empty;

            bool success = blActivo.UpdateAsset(asset, ref vError);

            if (success)
            {
                return "Activo modificado correctamente";
            }

            return vError;
        }

        [WebMethod]
        public string DeleteAsset(int pIdActivo)
        {
            blActivo blActivo = new blActivo();

            string vError = string.Empty;

            bool success = blActivo.DeleteAsset(pIdActivo, ref vError);

            if (success)
            {
                return "Activo eliminado correctamente";
            }

            return vError;
        }
        #endregion
    }
}
