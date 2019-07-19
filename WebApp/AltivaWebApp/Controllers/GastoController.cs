using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/Gasto")]
    public class GastoController : Controller
    {
        private readonly ICompraService service;
        private readonly IContactoService contactoService;
        private readonly IInventarioService inventarioService;
        private readonly IMonedaService monedaService;
        private readonly ICompraMap map;
        private readonly IUserService userService;
        private readonly IBodegaService bodegaService;
        private readonly IKardexMap kardexMap;
        private readonly IHaciendaMap haciendaMap;
        private readonly IHaciendaService haciendaService;
        private readonly ITomaService tomaService;
        public GastoController(ITomaService tomaService, IHaciendaService haciendaService, IHaciendaMap haciendaMap, IKardexMap kardexMap, IBodegaService bodegaService, IUserService userService, ICompraMap map, IInventarioService inventarioService, IMonedaService monedaService, ICompraService service, IContactoService contactoService)
        {
            this.service = service;
            this.contactoService = contactoService;
            this.inventarioService = inventarioService;
            this.monedaService = monedaService;
            this.map = map;
            this.userService = userService;
            this.bodegaService = bodegaService;
            this.kardexMap = kardexMap;
            this.haciendaMap = haciendaMap;
            this.haciendaService = haciendaService;
            this.tomaService = tomaService;
        }
       [HttpGet]
       public ActionResult ListarGastos()
        {
            return View();
        }
        [HttpGet("Get-Gastos")]
        public ActionResult GetGastos()
        {
            try
            {
                var gastos = service.GetAllGastos();
                /*if (compras != null)
                {
                    foreach (var item in compras)
                    {
                        item.IdContactoNavigation.TbPrCompra = null;

                        foreach (var i in item.TbPrCompraDetalle)
                        {
                            i.IdInventarioNavigation.TbPrOrdenDetalle = null;
                            i.IdInventarioNavigation.TbPrCompraDetalle = null;
                            i.IdCompraNavigation = null;
                        }
                    }

                    return Ok(compras);
                }

                else
                    return Ok();*/
                return Ok(gastos);
            }
            catch
            {
                throw;
                //return BadRequest();
            }
        }
    }
}
