using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.Areas.Admin.Controllers
{
    public class TitularController : Controller
    {
        private Titular titular = new Titular();
        // GET: Admin/Titular
        public ActionResult Index()
        {
            return View(titular.Listar());
        }

        public ActionResult Ver(int id)
        {
            return View(titular.Obtener(id));
        }
        public ActionResult Crud(int id = 0)
        {
            return View(
                id == 0 ? new Titular()
                        : titular.Obtener(id)
                );
        }
        public ActionResult Guardar(Titular model)
        {
            model.Guardar();
            return Redirect("~/Admin/Nino/Ver/"+ model.NinoId);
        }

        public ActionResult Eliminar(Titular model)
        {
            model.Eliminar();
            return Redirect("~/Admin/Titular");
        }
    }
}