﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace AltivaWebApp.Controllers
{
    using AltivaWebApp.Context;
    using AltivaWebApp.DomainsConta;
    using AltivaWebApp.Mappers;
    using AltivaWebApp.Services;
    using AltivaWebApp.ViewModels;
    using System.Security.Claims;

    public class CatalogoContaController : Controller
    {
        BaseConta bd;
        readonly ICatalogoContableService service;
        readonly ICatalogoContableMap map;
        readonly IBitacoraMapper bitacoraMap;
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
            return View("u", d);
        }
        [BindProperty]
        public CatalogoContable p { get; set; }
        [HttpPost("CrearEditarBodega")]
        public ActionResult CrearEditarBodega(CatalogoContableViewModel model)
        {
            try
            {

                var existeBodega = service.GetCatalogoContableByNombre(model.Descripcion);
                if (model.IdCuentaContable != 0)
                {
                    if (existeBodega != null)
                        if ((int)existeBodega.IdCuentaContable != model.IdCuentaContable)
                            return Json(new { success = false });

                    var catalogoCuenta = map.Update(model, model.IdCuentaContable);
                    var idUsuario = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                    string comentarioES = "Editó la cuenta contable " + catalogoCuenta.Descripcion;

                    bitacoraMap.CrearBitacora(int.Parse(idUsuario), comentarioES, (int)catalogoCuenta.IdCuentaContable, "CatalogoCuentaContable");

                    return Json(new { success = true });
                }
                else
                {
                    if (existeBodega != null)
                        return Json(new { success = false });

                    var catalogoCuenta = map.Create(model);
                    var idUsuario = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                    string comentarioES = "Creo una cuenta contable " + catalogoCuenta.Descripcion;
                    //string comentarioIN = "Creo una nueva bitacora";
                    bitacoraMap.CrearBitacora(int.Parse(idUsuario), comentarioES, (int)catalogoCuenta.IdCuentaContable, "CatalogoCuentaContable");
                    return Json(new { success = true });

                }


            }
            catch
            {
                //throw;
                return BadRequest();
            }
        }
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