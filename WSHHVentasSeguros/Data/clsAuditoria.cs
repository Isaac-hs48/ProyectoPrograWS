using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSHHVentasSeguros.Data
{
    public class ClsAuditoria
    {
        public int IdCreadoPor { get; set; }
        public int IdModificadoPor { get; set; }
        public DateTime FechaCreadoPor { get; set; }
        public DateTime FechaModificadoPor { get; set; }
    }
}