using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Demo.Modelo;
using Demo.Negocio;
using Newtonsoft;

namespace Demo.Api.Controllers
{
    public class DemoController : ApiController
    {
        [HttpGet]
        public List<TransactionHistory> GetHistorialTransacciones()
        {
            ProcesaHistorial procesaHistorial = new ProcesaHistorial();
            return procesaHistorial.ObtenerHistorialTransacciones();
        }
    }
}