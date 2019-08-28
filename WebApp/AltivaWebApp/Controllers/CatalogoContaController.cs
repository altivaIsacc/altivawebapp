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
            ViewBag.CatalogoContable = bd.CatalogoContable.OrderBy(p => p.CuentaContable).ToList();
            return View();
        }
        private void initViewBag()
        {
            ViewBag.Titulo = "setCatalogoConta";
            ViewBag.Error = false;
            ConfiguracionContable c = bd.ConfiguracionContable.FirstOrDefault();
            ViewBag.Formato = c.Ejemplo;
            ViewBag.InicioPadre = "0";
            ViewBag.Espacios = "0";
            ViewBag.Min = 1;
            ViewBag.Max = 6;
            ViewBag.Ceros = 1;
            ViewBag.RellenoPosterior = "";

        }
        private void iniViewBagPadre(CatalogoContable padre, ViewModels.CatalogoContableViewModel dato)
        {

            if (padre != null)
            {

                dato.Nivel = Nivel(padre);
                if (dato.CuentaContable == null) {
                    dato.CuentaContable = padre.CuentaContable;
                }              
                dato.CuentaContablePadre = padre.CuentaContable;
                dato.DescCuentaPadre = padre.Descripcion;
                dato.IdCuentaContablePadre = padre.IdCuentaContable;
                dato.IdTipoCuentaContable = padre.IdTipoCuentaContable;
                ViewBag.Min = 1;
                ViewBag.Max = MaxHija(padre);
                ViewBag.InicioPadre = IniPadre(padre);
                ViewBag.Espacios = digitosDisponibles(EspaciosNivel(dato.Nivel), "0");
                if (dato.Nivel > 1)
                {
                    ViewBag.FinPadre = FinPadre(ViewBag.InicioPadre.Length + ViewBag.Espacios.Length, padre.CuentaContablePadre);


                }
                else {
                    ViewBag.FinPadre = FinPadre(1, padre.CuentaContablePadre);

                }
                ViewBag.Numero = dato.CuentaContable.Substring(ViewBag.InicioPadre.Length, ViewBag.Espacios.Length);
            }
            else
            {
                dato.Nivel = 1;
                ViewBag.Min = 1;
                ViewBag.Max = 9;
                ViewBag.InicioPadre = "";
                ViewBag.Espacios = digitosDisponibles(EspaciosNivel(dato.Nivel), "0");
                ViewBag.FinPadre = FinPadre(1, "");
                if (dato.CuentaContable != null)
                {
                    ViewBag.Numero = dato.CuentaContable.ElementAt(0);

                }
                else
                {
                    ViewBag.Numero = 1;
                }



            }
        }
        public ActionResult nItem(long idP)
        {
            initViewBag();
            AltivaWebApp.ViewModels.CatalogoContableViewModel dato;
            dato = new AltivaWebApp.ViewModels.CatalogoContableViewModel();
            AltivaWebApp.DomainsConta.CatalogoContable padre;
            padre = service.GetCatalogoContableById(idP);
            iniViewBagPadre(padre, dato);
            return View("../CatalogoConta/u", dato);
        }
        public ActionResult eItem(long id)
        {
            initViewBag();
            AltivaWebApp.ViewModels.CatalogoContableViewModel dato;
            dato = map.DomainToViewModel(service.GetCatalogoContableById(id));
            AltivaWebApp.DomainsConta.CatalogoContable padre;
            padre = service.GetCatalogoContableById(dato.IdCuentaContablePadre);
            iniViewBagPadre(padre, dato);

            return View("../CatalogoConta/u", dato);
        }

        private string IniPadre(CatalogoContable _padre)
        {
            string Ini = "";
          
            for (int i = 1; i <= _padre.Nivel; i++)
            {
                if (i == 1)
                {
                    Ini = digitosDisponibles(EspaciosNivel(i), "0");
                }
                else {
                    Ini = Ini + "-" + digitosDisponibles(EspaciosNivel(i), "0");
                }
               

            }
            AltivaWebApp.DomainsConta.ConfiguracionContable conf = bd.ConfiguracionContable.FirstOrDefault();
            if (conf.TamanoCuenta == (_padre.Nivel)) {
                Ini = _padre.CuentaContable.Substring(0, Ini.Length);
            }
            else
            {Ini = _padre.CuentaContable.Substring(0, Ini.Length) + '-';}

           

            return Ini;

        }
        private string FinPadre(int _desde, string CuentaPadre)
        {
           
            int cantidadFinal = CuentaPadre.Length - _desde;
            if (cantidadFinal < 0 || (CuentaPadre.Length ==0))
            {
                AltivaWebApp.DomainsConta.ConfiguracionContable conf = bd.ConfiguracionContable.FirstOrDefault();
                CuentaPadre = conf.Ejemplo;
                cantidadFinal = conf.Ejemplo.Length - _desde;
            }
            string Fin = CuentaPadre.Substring(_desde,cantidadFinal);
           


            return Fin;

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
            if (n == 2)
            {

                return c.Nivel2;
            }
            if (n == 3)
            {

                return c.Nivel3;
            }
            if (n == 4)
            {

                return c.Nivel4;
            }
            if (n == 5)
            {

                return c.Nivel5;
            }
            if (n == 5)
            {

                return c.Nivel5;
            }
            if (n == 6)
            {

                return c.Nivel6;
            }
            if (n == 7)
            {

                return c.Nivel7;
            }
            if (n == 8)
            {
                return c.Nivel8;
            }
            return 1;
        }
        private string MaxHija(CatalogoContable _p)
        {
            if (_p.Nivel == 1)
            {

                return "6";
            }
            else
            {
                return digitosDisponibles(EspaciosNivel(_p.Nivel), "9");
            }
        }
        private string digitosDisponibles(int cant, string caracter)
        {
            string nueves = "";

            for (int i = 1; i <= cant; i++)
            {
                nueves = nueves + caracter;

            }
            return nueves;
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
            concidencias = bd.CatalogoContable.Where(x => x.IdCuentaContablePadre == p.IdCuentaContable && x.Nivel>1).ToList();
            if (concidencias.Count > 0 && p.Movimiento)
            {
                ViewBag.Error = true;
                ViewBag.Dato = "MovimientoInvalido";

            }

            if (ViewBag.Error)
            {
                var dato = map.DomainToViewModel(p);
                AltivaWebApp.DomainsConta.CatalogoContable padre;
                padre = service.GetCatalogoContableById(dato.IdCuentaContablePadre);
                iniViewBagPadre(padre, dato);
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