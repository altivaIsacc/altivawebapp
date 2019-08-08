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
           ConfiguracionContable c = bd.ConfiguracionContable.FirstOrDefault();
            ViewBag.Formato = c.Ejemplo;
           var u = bd.CatalogoContable.Find(id);
            if (u == null)
            {
                u = new DomainsConta.CatalogoContable();
               
            }
            return View(u);
        }
        public IActionResult uDet(long id)
        {
            ViewBag.Titulo = "setCatalogoConta";
            ConfiguracionContable c = bd.ConfiguracionContable.FirstOrDefault();
            ViewBag.Formato = c.Ejemplo;

            var padre = bd.CatalogoContable.Find(id);
            var d = new DomainsConta.CatalogoContable();            
            d.IdCuentaContablePadre = padre.IdCuentaContable;
            d.CuentaContablePadre = padre.CuentaContable;
            d.CuentaContable = padre.CuentaContable;
            d.DescCuentaPadre = padre.Descripcion;
            return View("u",d);
        }
        [BindProperty]
        public CatalogoContable p { get; set; }
        public IActionResult guardar()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var _Cambios = bd.CatalogoContable.Where(x => x.IdCuentaContable == p.IdCuentaContable).SingleOrDefault();
            if (_Cambios == null)
            {
                _Cambios = new CatalogoContable();
                bd.CatalogoContable.Add(_Cambios);
            }
            _Cambios.CuentaContable = p.CuentaContable;
            _Cambios.Descripcion = p.Descripcion;
            _Cambios.Nivel = p.Nivel;
            _Cambios.IdTipoCuentaContable = p.IdTipoCuentaContable;
            _Cambios.IdCuentaContablePadre = p.IdCuentaContablePadre;
            if (p.CuentaContablePadre != null)
            {
                _Cambios.CuentaContablePadre = p.CuentaContablePadre;
            }
            else {
                _Cambios.CuentaContablePadre = "";

            }
            if (p.DescCuentaPadre != null)
            {
                _Cambios.DescCuentaPadre = p.DescCuentaPadre;
            }
            else {
                _Cambios.DescCuentaPadre = "";
            }
            _Cambios.Movimiento = p.Movimiento;
            _Cambios.Evaluacion = p.Evaluacion;
            _Cambios.Inactivo = p.Inactivo;
            if (p.Notas != null)
            {
                _Cambios.Notas = p.Notas;

            }
            else {
                _Cambios.Notas = "";

            }

            _Cambios.IdMonedaEvaluacion = p.IdMonedaEvaluacion;
            _Cambios.IdTipoConversion = p.IdTipoConversion;

            bd.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}