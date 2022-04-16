using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSHHVentasSeguros.Shared
{
    public class ClsConstants
    {
        public enum HHVentasSegurosObjects
        {
            SP_DELETE_CLIENTE,
            SP_DELETE_PROVEEDOR,
            SP_DELETE_USUARIO,
            SP_INSERT_CLIENTE,
            SP_INSERT_PROVEEDOR,
            SP_INSERT_USUARIO,
            SP_SELECT_CLIENTES,
            SP_SELECT_PROVEEDOR,
            SP_SELECT_USUARIOS,
            SP_UPDATE_CLIENTE,
            SP_UPDATE_PROVEEDOR,
            SP_UPDATE_USUARIO,
            spDeleteActivo,
            spDeleteServicios,
            spDeleteVenta,
            spInsertActivo,
            spInsertServicio,
            spInsertVenta,
            spSelectActivos,
            spSelectServicios,
            spSelectVentas,
            spUpdateActivos,
            spUpdateServicio,
            spUpdateVentas,
            spDepreciacion
        }
    }
}