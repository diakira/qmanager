using Newtonsoft.Json;
using QManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Usuario> listaUsuario = new List<Usuario>();

            using (StreamReader sr = new StreamReader(Server.MapPath("~/Mock/Usuario.json"), true))
            {
                listaUsuario = JsonConvert.DeserializeObject<List<Usuario>>(sr.ReadToEnd());

                sr.Close();
            }

            ViewBag.TotalFila = string.Format("{0} pessoa(s)", listaUsuario.Count());

            return View();
        }
    }
}