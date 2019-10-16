using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace AltivaWebApp.Controllers
{
    using AltivaWebApp.DomainsConta;
    using AltivaWebApp.Context;
    public class PeriodoFiscalController : Controller
    {
        BaseConta bd;
        
        public PeriodoFiscalController(BaseConta _bd)
        {
            bd = _bd;
        }
        public IActionResult Index()
        {
            ViewBag.Titulo = "listPeriodoFiscal";
            ViewBag.PeriodosFiscales = bd.PeriodoFiscal.ToList();            
            return View();
        }
        public IActionResult u(long id)
        {
            ViewBag.Titulo = "setPeriodoFiscal";
            var u = bd.PeriodoFiscal.Find(id);
            var _Cambios = bd.PeriodoTrabajo.Where(x => x.IdPeriodoFiscal == id).ToList();
            if (_Cambios == null)
            {

                _Cambios = bd.PeriodoTrabajo.ToList();
            }
            ViewBag.PeriodosTrabajo = _Cambios;
            if (u == null) {
                u = new DomainsConta.PeriodoFiscal();

            }
            
            return View(u);
        }
        [BindProperty]
        public PeriodoFiscal p { get; set; }
        public IActionResult guardar()            
        {
            if (!ModelState.IsValid) {
                return RedirectToAction("Index");
            }
            var _Cambios = bd.PeriodoFiscal.Where(x => x.IdPeriodoFiscal == p.IdPeriodoFiscal).SingleOrDefault();
            if (_Cambios == null) {
                bd.PeriodoFiscal.Add(_Cambios);
            }
            else {
                _Cambios.Estado = p.Estado;
            }
            bd.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}