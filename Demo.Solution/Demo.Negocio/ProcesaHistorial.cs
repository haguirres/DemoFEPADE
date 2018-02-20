using Demo.Datos;
using Demo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Negocio
{
    public class ProcesaHistorial
    {
        private AdministradorSQL administradorSQL;

        public ProcesaHistorial()
        {
            if (administradorSQL == null)
            {
                administradorSQL = new AdministradorSQL();
            }
        }

        public List<TransactionHistory> ObtenerHistorialTransacciones()
        {
            return administradorSQL.ObtenerHistorial();
        }
    }
}