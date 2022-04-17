using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSHHVentasSeguros.Data
{
    public class clsVenta : ClsAuditoria
    {
        public int idVenta { get; set; }

        public int idServicio { get; set; }

        public int idCliente { get; set; }

        public string identificacion { get; set; }

        public double totalColones { get; set; }

        public string estado { get; set; }

    }
}