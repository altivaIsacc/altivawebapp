using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace AltivaWebApp.Controllers
{
    using AltivaWebApp.Context;
    using AltivaWebApp.DomainsConta;
    using AltivaWebApp.Mappers;
    using AltivaWebApp.Services;
    using System.Collections.Generic;

    public class CatalogoContaController : Controller
    {
        BaseConta bd;
        readonly ICatalogoContableService service;
        readonly ICatalogoContableMap map;
        readonly IBitacoraMapper bitacoraMap;

        public CatalogoContaController(ICatalogoContableService service, ICatalogoContableMap map, IBitacoraMapper bitacoraMap, BaseConta _bd)
        {
            this.service = service;
            this.map = map;
            this.bitacoraMap = bitacoraMap;
            bd = _bd;
        }
        public IActionResult Index()
        {
            ViewBag.Titulo = "listCatalogoConta";
            ViewBag.CatalogoContable = bd.CatalogoContable.ToList();
            return View();
        }
        private void initViewBag()
        {
            ViewBag.Titulo = "setCatalogoConta";
            ViewBag.Error = false;
            ConfiguracionContable c = bd.ConfiguracionContable.FirstOrDefault();
            ViewBag.Formato = c.Ejemplo;
            ViewBag.Min = 1;
            ViewBag.Max = 6;
            ViewBag.Ceros = 1;

        }
        public ActionResult nItem(long idP)
        {
            initViewBag();
            AltivaWebApp.ViewModels.CatalogoContableViewModel dato;
            dato = new AltivaWebApp.ViewModels.CatalogoContableViewModel();
            AltivaWebApp.DomainsConta.CatalogoContable padre;

            padre = service.GetCatalogoContableById(idP);
            if (padre != null)
            {

                dato.Nivel = Nivel(padre);
                dato.CuentaContable = padre.CuentaContable;
                dato.CuentaContablePadre = padre.CuentaContablePadre;
                dato.DescCuentaPadre = padre.DescCuentaPadre;
                dato.IdCuentaContablePadre = padre.IdCuentaContable;
                ViewBag.Min = 1;
                ViewBag.Max = MaxHija(padre);
                ViewBag.Espacios = EspaciosNivel(dato.Nivel);
            }
            else
            {
                dato.Nivel = 1;
                ViewBag.Min = 1;
                ViewBag.Max = 6;
                ViewBag.Espacios = 1;

            }
            return View("../CatalogoConta/u", dato);
        }
        public ActionResult eItem(long id)
        {
            initViewBag();
            AltivaWebApp.ViewModels.CatalogoContableViewModel dato;
            dato = map.DomainToViewModel(service.GetCatalogoContableById(id));

            return View("../CatalogoConta/u", dato);
        }
        private short Nivel(CatalogoContable _p)
        {

            short siguiente = (short)(_p.Nivel + 1);
            return siguiente;
        }
        private int EspaciosNivel(int n)
        {
            ConfiguracionContable c = bd.ConfiguracionContable.FirstOrDefault();
            if (n == 1)
            {

                return 1;
            }
            if (p.Nivel == 2)
            {

                return c.Nivel2;
            }
            if (p.Nivel == 3)
            {

                return c.Nivel3;
            }
            if (p.Nivel == 4)
            {

                return c.Nivel4;
            }
            if (p.Nivel == 5)
            {

                return c.Nivel5;
            }
            if (p.Nivel == 5)
            {

                return c.Nivel5;
            }
            if (p.Nivel == 6)
            {

                return c.Nivel6;
            }
            if (p.Nivel == 7)
            {

                return c.Nivel7;
            }
            if (p.Nivel == 8)
            {
                return c.Nivel8;
            }
            return 1;
        }
        private int MaxHija(CatalogoContable _p)
        {                     
            if (p.Nivel == 1)
            {

                return 6;
            }
            else {
                return digitosDisponibles(EspaciosNivel(p.Nivel));
            }
        }
        private int digitosDisponibles(int cant)
        {
            string nueves = "";

            for (int i = 0; i < cant; i++)
            {
                nueves = nueves + "9";

            }
            return int.Parse(nueves);
        }
        [BindProperty]
        public CatalogoContable p { get; set; }
        public ActionResult guardar()
        {
            initViewBag();
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            //Validaciones
            List<CatalogoContable> concidencias = bd.CatalogoContable.Where(x => x.CuentaContable == p.CuentaContable && x.IdCuentaContable != p.IdCuentaContable).ToList();
            if (concidencias.Count > 0)
            {
                ViewBag.Error = true;
                ViewBag.Dato = "Cuenta";

            }
            concidencias = bd.CatalogoContable.Where(x => x.Descripcion == p.Descripcion && x.IdCuentaContable != p.IdCuentaContable).ToList();
            if (concidencias.Count > 0)
            {
                ViewBag.Error = true;
                ViewBag.Dato = "Descripcion";

            }

            if (p.Movimiento == true && p.CuentaContablePadre == "")
            {
                ViewBag.Error = true;
                ViewBag.Dato = "MovimientoInvalido";

            }
            concidencias = bd.CatalogoContable.Where(x => x.IdCuentaContablePadre == p.IdCuentaContable).ToList();
            if (concidencias.Count > 0 && p.Movimiento)
            {
                ViewBag.Error = true;
                ViewBag.Dato = "MovimientoInvalido";

            }

            if (ViewBag.Error)
            {
                var dato = map.DomainToViewModel(p);
                return View("../CatalogoConta/u", dato);
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
            else
            {
                _Cambios.CuentaContablePadre = "";

            }
            if (p.DescCuentaPadre != null)
            {
                _Cambios.DescCuentaPadre = p.DescCuentaPadre;
            }
            else
            {
                _Cambios.DescCuentaPadre = "";
            }
            _Cambios.Movimiento = p.Movimiento;
            _Cambios.Evaluacion = p.Evaluacion;
            _Cambios.Inactivo = p.Inactivo;
            if (p.Notas != null)
            {
                _Cambios.Notas = p.Notas;

            }
            else
            {
                _Cambios.Notas = "";

            }

            _Cambios.IdMonedaEvaluacion = p.IdMonedaEvaluacion;
            _Cambios.IdTipoConversion = p.IdTipoConversion;

            bd.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}