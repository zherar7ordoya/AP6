using System.Linq;
using System.Web.Mvc;
using MVCEntityFramework.Models;

namespace MVCEntityFramework.Controllers
{
    public class EmpleadosController : Controller
    {
        public DeveloferEntities db = new DeveloferEntities();
        // GET: Empleados
        public ActionResult Index()
        {
            var empleados = db.Empleados.ToList();
            Session["ListaEmpleados"] = empleados;
            return View(empleados);
        }

        [HttpPost]
        public ActionResult Index(int IdArea)
        {
            Empleados empleado = db.Empleados.Where(e => e.IdArea == IdArea).FirstOrDefault();

            if (empleado != null)
            {
                ViewBag.Area = "Empleado: " + empleado.Nombre + " - " + " Area: " + empleado.Areas.Area;
            }
            return View(Session["ListaEmpleados"]);
        }
    }
}