using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Vita.Servicios;

namespace Vita.Controllers
{
    public class LoginController: Controller
    {
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        private VitaEntities myDbContext = new VitaEntities();
        public ActionResult Login()
        {
            if (Request.Cookies.AllKeys.Contains("usuarioSesion") && Request.Cookies["usuarioSesion"].Values.Count > 0)
            {
                var cookie = Request.Cookies["usuarioSesion"].Value;
                if (cookie != null && !string.IsNullOrWhiteSpace(cookie))
                {
                    byte[] decryted = Convert.FromBase64String(string.IsNullOrWhiteSpace(cookie) ? string.Empty : cookie);
                    var result = Int32.Parse(System.Text.Encoding.Unicode.GetString(decryted));

                    var usuario = usuarioServicio.GetById(result);
                    if (usuario != null)
                    {
                        Session["Usuario"] = usuario;
                        if (usuario.RolId == 1)
                        {
                            return RedirectToAction("PerfilUsuario", "Usuario");

                        }
                        else
                        {
                            return RedirectToAction("PerfilEntidad", "Usuario");

                        }
                    }
                    else
                    {
                        return View();
                    }
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario u)
        {
            var user = usuarioServicio.VerificarLogin(u);
            if (user != null)
            {
                Session["Usuario"] = user;

                if (Session["RedireccionLogin"] != null)
                {
                    String accionSesion = (String)Session["RedireccionLogin"];
                    String pattern = "/";
                    String[] accion = Regex.Split(accionSesion, pattern);
                    Session.Remove("RedireccionLogin");
                    return RedirectToAction(accion[1], accion[0]);
                }
                if (user.RolId == 1)
                {
                    return RedirectToAction("PerfilUsuario", "Usuario");
                }
                else
                {
                    return RedirectToAction("PerfilEntidad", "Usuario");
                }


            }
            else
            {
                ViewBag.ErrorLogin = " Usuario y/o Contraseña Invalidos";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}