using CriasApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CriasApp.Controllers
{
    public class AccountController : Controller
    {

        CriasContext db = new CriasContext();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl });
        }


        [HttpPost]
        public ActionResult LoginValidate(string Usuario, string Contraseña)
        {
            if (ModelState.IsValid)
            {
                var result =  db.Usuarios.FirstOrDefault(x => x.Usuario == Usuario && x.Contraseña == Contraseña);
                if(result != null)
                {
                    if (result.Puesto == "Personal de Control")
                    {
                        return Json(new { success = true, redirectUrl = Url.Action("Index", "RegistroCrias") });
                    }
                    else if (result.Puesto == "Ayudante de Veterinario")
                    {
                        return Json(new { success = true, redirectUrl = Url.Action("Index", "RegistoSensores") });
                    }
                    else if (result.Puesto == "Veterinario")
                    {
                        return Json(new { success = true, redirectUrl = Url.Action("Index", "Veterinario") });
                    }
                }
            }

            return Json(new { success = false, message = "Usuario invalido." });
        }


        [HttpPost]
        public ActionResult GuardarUser(string Usuario, string Contraseña, string Puesto)
        {
            using (var contexto = new CriasContext())
            {
                var nuevoUsuario = new Usuarios
                {
                    Usuario = Usuario,
                    Contraseña = Contraseña,
                    Puesto = Puesto
                };

                contexto.Usuarios.Add(nuevoUsuario);
                contexto.SaveChanges();
            }

            return Json(new { success = true, message = "Registro exitoso" });

            //return RedirectToAction("Index", "Home");
        }

    }
}
