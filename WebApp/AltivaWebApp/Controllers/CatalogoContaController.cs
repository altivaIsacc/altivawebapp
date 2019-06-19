using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace AltivaWebApp.Controllers
{
    using AltivaWebApp.DomainsConta;
    using AltivaWebApp.Context;
    using System;
    using System.Security.Claims;

    public class CatalogoContaController : Controller
    {
        BaseConta bd;

        public CatalogoContaController(BaseConta _bd)
        {
            bd = _bd;
        }
        public IActionResult Index()
        {
            ViewBag.Titulo = "listCatalogoConta";
            ViewBag.CatalogoContable = bd.CatalogoContable.ToList();
            return View();
        }
        public IActionResult u(long id)
        {
            ViewBag.Titulo = "setCatalogoConta";
            var u = bd.CatalogoContable.Find(id);
            if (u == null)
            {
                u = new DomainsConta.CatalogoContable();

            }

            return View(u);
        }
        [BindProperty]
        public CatalogoContable p { get; set; }
        public IActionResult guardar()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var _Cambios = bd.CatalogoContable.Where(x => x.id == p.id).SingleOrDefault();
            if (_Cambios == null)
            {
                _Cambios = new CatalogoContable();
                bd.CatalogoContable.Add(_Cambios);
            }
            _Cambios.CuentaContable = p.CuentaContable;
            _Cambios.Descripcion = p.Descripcion;
            _Cambios.Nivel = p.Nivel;
            _Cambios.Tipo = p.Tipo;
            _Cambios.PARENTID = p.PARENTID;
            _Cambios.CuentaMadre = p.CuentaMadre;
            _Cambios.DescCuentaMadre = p.DescCuentaMadre;
            _Cambios.Movimiento = p.Movimiento;
            _Cambios.Evaluacion = p.Evaluacion;
            _Cambios.Inactivo = p.Inactivo;
            _Cambios.Notas = p.Notas;       

            bd.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}