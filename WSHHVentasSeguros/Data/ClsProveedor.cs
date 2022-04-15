using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSHHVentasSeguros.Data
{
    public class ClsProveedor : ClsAuditoria
    {
        public int IdProveedor { get; set; }
        public string NombreCompleto { get; set; }
        public string TipoCedula { get; set; }
        public string NumeroCedula { get; set; }
        public string NumeroTelefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}