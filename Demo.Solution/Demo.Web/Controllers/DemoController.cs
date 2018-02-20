using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Demo.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }
    }
}