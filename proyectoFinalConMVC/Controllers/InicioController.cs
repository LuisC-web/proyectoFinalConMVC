using proyectoFinalConMVC.Data;
using proyectoFinalConMVC.Models;
using proyectoFinalConMVC.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoFinalConMVC.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string correo, string password)

        {
            string repuesta = ConexionDeBaseDeDatos.Login(correo, password);
            if (repuesta.Equals("Login"))
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.Mensaje = repuesta;
            }
            return View();
        }
        public ActionResult Registrar()
        {
            return View();
        }
        public ActionResult Registro(Usuario usuario)

        {
            string repuesta = ConexionDeBaseDeDatos.Login(usuario.correo, usuario.password);
            if (repuesta.Equals("Login"))
            {
                ViewBag.Mensaje = "Usuario ya existe";
            }
            if(repuesta.Equals("No existe usuario"))
            {
                usuario.password = EncriptarDesencriptarClave.encriptar(usuario.password);
                ConexionDeBaseDeDatos.Registrar(usuario.correo, usuario.password);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}