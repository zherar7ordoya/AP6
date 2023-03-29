using System.Collections.Generic;
using System.Web.Mvc;

namespace RazorMVC.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaUsuarios()
        {
            List<string> listaUsuarios = new List<string>();
            listaUsuarios.Add("Fernando");
            listaUsuarios.Add("Alejandra");
            listaUsuarios.Add("Raúl");
            listaUsuarios.Add("Martín");
            listaUsuarios.Add("Rodolfo");

            Session["ListaUsuarios"] = listaUsuarios;
            return View(listaUsuarios);
        }

        [HttpPost]

        public ActionResult ListaUsuarios(string selUsuarios)
        {
            ViewBag.Nombre = selUsuarios;
            List<string> listaUsuarios = (List<string>) Session["ListaUsuarios"];
            return View(listaUsuarios);
        }
    }
}