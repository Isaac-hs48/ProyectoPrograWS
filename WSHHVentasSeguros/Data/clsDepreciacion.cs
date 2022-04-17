using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSHHVentasSeguros.Data
{
    public class clsDepreciacion
    {
        public int idDepreciacion { get; set; }

        public string Descripcion { get; set; }

        public int Ano { get; set; }

        public double Depreciacion { get; set; }

        public int idActivo { get; set; }

    }
}