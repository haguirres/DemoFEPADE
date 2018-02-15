using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Datos;
namespace Demo.Negocio
{
    public class ProcesaCola
    {
        private AdministradorAzure administradorAzure;

        public ProcesaCola()
        {
            if (administradorAzure == null)
            {
                administradorAzure = new AdministradorAzure();
            }
        }
        public void AgregarMensajeCola(object  mensaje)
        {          
            administradorAzure.AgregaMensajeCola(Newtonsoft.Json.JsonConvert.SerializeObject(mensaje));
        }

        public string DesencolarMensaje()
        {
            return administradorAzure.RecuperarMensajeCola();
        }
    }
}
