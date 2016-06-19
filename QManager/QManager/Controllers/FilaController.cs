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
    public class FilaController : Controller
    {
        // GET: Fila
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Remover(int id)
        {
            List<Usuario> listaUsuario = new List<Usuario>();

            using (StreamReader sr = new StreamReader(Server.MapPath("~/Mock/Usuario.json"), true))
            {
                listaUsuario = JsonConvert.DeserializeObject<List<Usuario>>(sr.ReadToEnd());

                sr.Close();
            }

            var usuario = listaUsuario.Where(m => m.ID == id).FirstOrDefault();
            listaUsuario.Remove(usuario);

            for (int i = 0; i < listaUsuario.Count; i++)
            {
                listaUsuario[i].ID = i + 1;
            }

            string json = JsonConvert.SerializeObject(listaUsuario.ToArray());

            using (StreamWriter sw = new StreamWriter(Server.MapPath("~/Mock/Usuario.json")))
            {
                sw.Write(json);

                sw.Close();
            }

            ViewBag.Mensagem = "Usuário removido com sucesso!";

            return View("Index");
        }
    }
}