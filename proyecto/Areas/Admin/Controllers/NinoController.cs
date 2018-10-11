using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.Areas.Admin.Controllers
{
    public class NinoController : Controller
    {
        private Nino nino = new Nino();
        private Titular titular = new Titular();
        private Vacuna vacuna = new Vacuna();
        
        // GET: Admin/Nino
        public ActionResult Index()
        {
            return View(nino.Listar());
        }

        public ActionResult Ver(int id)
        {
            return View(nino.Obtener(id));
        }
        public PartialViewResult Titulares(int Nino_id)
        {
            ViewBag.Titular = titular.Listar();
            titular.Idt = Nino_id;
            return PartialView(titular);
        }
        public ActionResult Crud(int id = 0)
        {
            return View(
                id == 0 ? new Nino()
                        :nino.Obtener(id)
                );
        }
        public ActionResult Guardar(Nino model, int[] vacunas = null)
        {
            if(vacunas != null)
            {
                foreach (var c in vacunas)
                    model.Vacuna.Add(new Vacuna { Id = c });
            }

            model.Guardar();

            return Redirect("~/Admin/Nino/index/");
        }

        public ActionResult Eliminar(int id)
        {
            nino.Id = id;
            nino.Eliminar();
            return Redirect("~/Admin/Nino/");
        }
        public ActionResult Main()
        {
            return View(nino.Listar());
        }

    }
}
  