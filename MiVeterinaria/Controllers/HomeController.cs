using MiVeterinaria.Domain.Services;
using MiVeterinaria.Models;
using MiVeterinaria.Services;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiVeterinaria.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ConsultaUsuarios()
        {
            return View();
        }

        // GET: Usuarios
        [HttpGet]
        public ActionResult VerUsuarios()
        {
            UsuarioService usuarioService = new UsuarioService();

            List<UsuarioDb> usuarios = new List<UsuarioDb>();
            usuarios = usuarioService.ConsultarUsuarios();
            return Json(usuarios, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult InsertarUsuario(UsuarioDb usuarioDb)
        {
            UsuarioService usuarioService = new UsuarioService();
            var response = usuarioService.CrearUsuario(usuarioDb);

            return Json(response);
        }

        [HttpPut]
        public ActionResult ActualizarUsuario(UsuarioDb model, string idUser)
        {
            UsuarioService usuarioService = new UsuarioService();
            ResponseDb response = usuarioService.ActualizarUsuario(model, idUser);

            return Json(response);
        }

        [HttpDelete]
        public ActionResult EliminarUsuario(string idUser)
        {
            UsuarioService usuarioService = new UsuarioService();
            ResponseDb response = usuarioService.EliminarUsuario(idUser);

            return Json(response);
        }
    }
}