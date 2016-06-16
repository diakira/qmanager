using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QManager.Controllers
{
    public class FilaController : Controller
    {
        // GET: Fila
        public ActionResult Index()
        {           
            return View();
        }
    }
}