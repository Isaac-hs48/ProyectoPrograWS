using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSHHVentasSeguros.Data
{
    public class clsActivo : ClsAuditoria
    {
        public int idActivo { get; set; }

        public string descripcion { get; set; }

        public double precioColones { get; set; }

        public int vidaUtilAnos { get; set; }

        public double valorDesechoColones { get; set; }

        public string estado { get; set; }
    }
}