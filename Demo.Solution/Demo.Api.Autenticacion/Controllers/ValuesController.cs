using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Api.Autenticacion.Controllers
{
[Authorize]
    public class ValuesController : ApiController
    {
        public string Get()
        {
            return "Autenticado!";
        }
    }
}
