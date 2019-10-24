using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace AltivaWebApp.Controllers
{
    using AltivaWebApp.DomainsConta;
    using AltivaWebApp.Context;
    using Microsoft.AspNetCore.Routing;

    public class PeriodoTrabajoController : Controller
    {
        BaseConta bd;

        public PeriodoTrabajoController(BaseConta _bd)
        {
            bd = _bd;
        }
        public IActionResult Index(long id)
        {
            ViewBag.Titulo = "listPeriodoTrabajo";

            var _Cambios = bd.PeriodoTrabajo.Where(x => x.IdPeriodoFiscal == id).ToList();
            if (_Cambios == null) {

                 _Cambios = bd.PeriodoTrabajo.ToList();
            }
            ViewBag.PeriodosTrabajo = _Cambios;
            return View();
        }
        public IActionResult u(long id)
        {
            ViewBag.Titulo = "setPeriodoTrabajo";
            var u = bd.PeriodoTrabajo.Find(id);
            if (u == null)
            {
                u = new DomainsConta.PeriodoTrabajo();

            }

            return View(u);
        }
        [BindProperty]
        public PeriodoTrabajo p { get; set; }
        public IActionResult guardar()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("/PeriodoTrabajo/");
            }
            var _Cambios = bd.PeriodoTrabajo.Where(x => x.IdPeriodoTrabajo == p.IdPeriodoTrabajo).SingleOrDefault();
            if (_Cambios == null)
            {
                bd.PeriodoTrabajo.Add(_Cambios);
            }
            else
            {
                _Cambios.Estado = p.Estado;
            }
            bd.SaveChanges();
            return RedirectToAction("u", new RouteValueDictionary(
                            new { controller = "PeriodoFiscal", action = "u", id = p.IdPeriodoFiscal }));
        }


    }
}