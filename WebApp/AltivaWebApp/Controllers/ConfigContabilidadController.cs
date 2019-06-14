using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace AltivaWebApp.Controllers
{
    using AltivaWebApp.DomainsConta;
    using AltivaWebApp.Context;
    using System;
    using System.Security.Claims;

    public class ConfigContabilidadController : Controller
    {
        BaseConta bd;

        public ConfigContabilidadController(BaseConta _bd)
        {
            bd = _bd;
        }
        public IActionResult Index()
        {
            ViewBag.Titulo = "setConfigContable";
            var u = bd.ConfiguracionContable.First();
            if (u == null)
            {
                u = new DomainsConta.ConfiguracionContable();

            }
            return View(u);
        }
        [BindProperty]
        public ConfiguracionContable p { get; set; }
        public IActionResult guardar()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var _Cambios = bd.ConfiguracionContable.Where(x => x.IdConfiguracion == p.IdConfiguracion).SingleOrDefault();
            if (_Cambios == null)
            {
                _Cambios = new ConfiguracionContable();
                             bd.ConfiguracionContable.Add(_Cambios);
            }           
                _Cambios.TamanoCuenta = p.TamanoCuenta;
                _Cambios.Nivel1 = p.Nivel1;
                _Cambios.Nivel2 = p.Nivel2;
                _Cambios.Nivel3 = p.Nivel3;
                _Cambios.Nivel4 = p.Nivel4;
                _Cambios.Nivel5 = p.Nivel5;
                _Cambios.Nivel6 = p.Nivel6;
                _Cambios.Nivel7 = p.Nivel7;
                _Cambios.Nivel8 = p.Nivel8;
                _Cambios.Ejemplo = p.Ejemplo;
                _Cambios.FechaCreacion = DateTime.Now;
                _Cambios.IdUsuario = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);


            bd.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}