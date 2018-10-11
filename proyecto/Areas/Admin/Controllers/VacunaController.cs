using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.Areas.Admin.Controllers
{
    
    public class VacunaController : Controller
    {
        // GET: Admin/Vacuna
        private Vacuna vacuna = new Vacuna();
        public ActionResult Index()
        {
            return View(vacuna.Listar());
        }
        public ActionResult Ver(int id)
        {
            return View(vacuna.Obtener(id));
        }
        public ActionResult Crud(int id = 0)
        {
            return View(
                id == 0 ? new Vacuna()
                        : vacuna.Obtener(id)
                );
        }
        public ActionResult Guardar(Vacuna model)
        {
            model.Guardar();
            return Redirect("~/Admin/Vacuna/");
        }
    }

}