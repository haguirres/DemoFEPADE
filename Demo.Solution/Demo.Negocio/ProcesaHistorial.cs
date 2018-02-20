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
        private AdministradorAzure administradorAzure;
        public ProcesaHistorial()
        {
            if (administradorSQL == null)
            {
                administradorSQL = new AdministradorSQL();
            }
            if (administradorAzure == null)
            {
                administradorAzure = new AdministradorAzure();
            }
        }

        public List<TransactionHistory> ObtenerHistorialTransacciones()
        {
            string mensajeLog = string.Format("{0}: Obteniendo historial de transacciones",DateTime.Now.ToLongTimeString());
            administradorAzure.AgregarRegistroLog(mensajeLog);
            return administradorSQL.ObtenerHistorial();
        }
    }
}