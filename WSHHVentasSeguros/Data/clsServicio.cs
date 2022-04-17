using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSHHVentasSeguros.Data
{
    public class clsServicio : ClsAuditoria
    {
        public int idServicio { get; set; }

        public string tipoServicio { get; set; }

        public double precioColones { get; set; }

        public string estado { get; set; }

    }
}