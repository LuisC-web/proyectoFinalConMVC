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
            ViewBag.Mensaje = repuesta;
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
        [HttpPost]
        public ActionResult Registrar(string correo, string password)

        {
            string repuesta = ConexionDeBaseDeDatos.Login(correo, password);
            ViewBag.Mensaje = repuesta;
            if (repuesta.Equals("Login"))
            {
                ViewBag.Mensaje = "Usuario ya existe";
            }
            if(repuesta.Equals("usuario no existe"))
            {
                password = EncriptarDesencriptarClave.encriptar(password);
                ConexionDeBaseDeDatos.Registrar(correo, password);
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }
    }
}