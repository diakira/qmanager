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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            var dateTime = DateTime.Now;

            Usuario usuario = new Usuario()
            {
                DataHoraChegada = string.Format("{0}/{1}/{2} {3}:{4}", dateTime.Day,
                                                                       dateTime.Month,
                                                                       dateTime.Year,
                                                                       dateTime.Hour,
                                                                       dateTime.Minute)
            };

            if (TempData["Mensagem"] != null)
            {
                ViewBag.Mensagem = TempData["Mensagem"];
            }

            return View(usuario);
        }

        public ActionResult Adicionar(Usuario usuario)
        {
            try
            {
                List<Usuario> listaUsuario = new List<Usuario>();

                using (StreamReader sr = new StreamReader(Server.MapPath("~/Mock/Usuario.json"), true))
                {
                    listaUsuario = JsonConvert.DeserializeObject<List<Usuario>>(sr.ReadToEnd());
                }

                if (listaUsuario.Count == 10)
                {
                    ViewBag.Mensagem = "Limite máximo de usuários na fila excedido (10 usuários)";


                    var dataHora = DateTime.Now;
                    usuario.DataHoraChegada = string.Format("{0}/{1}/{2} {3}:{4}", dataHora.Day,
                                                                           dataHora.Month,
                                                                           dataHora.Year,
                                                                           dataHora.Hour,
                                                                           dataHora.Minute);

                    return View("Index", usuario);
                }
                else
                {
                    listaUsuario.Add(new Usuario()
                    {
                        Nome = usuario.Nome,
                        QuantidadePessoas = usuario.QuantidadePessoas,
                        DataHoraChegada = usuario.DataHoraChegada,
                        ID = listaUsuario.Count + 1
                    });

                    string json = JsonConvert.SerializeObject(listaUsuario.ToArray());

                    using (StreamWriter sw = new StreamWriter(Server.MapPath("~/Mock/Usuario.json")))
                    {
                        sw.Write(json);
                    }
                }

                TempData["Mensagem"] = "Usuário adicionado com sucesso!";

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Mensagem = "Ocorreu um erro. Favor tente novamente!";

                var dateTime = DateTime.Now;
                usuario = new Usuario()
                {
                    DataHoraChegada = string.Format("{0}/{1}/{2} {3}:{4}", dateTime.Day,
                                                                       dateTime.Month,
                                                                       dateTime.Year,
                                                                       dateTime.Hour,
                                                                       dateTime.Minute)
                };

                return View("Index", usuario);
            }
        }
    }
}

