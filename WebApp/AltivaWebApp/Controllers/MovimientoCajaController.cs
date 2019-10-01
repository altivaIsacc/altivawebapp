using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("{culture}/MovimientoCaja")]
    public class MovimientoCajaController : Controller
    {
        private readonly IDenominacionesService denService;
        private readonly IFlujoCategoriaService flujoService;
        public MovimientoCajaController(IFlujoCategoriaService flujoService, IDenominacionesService denService)
        {
            this.denService = denService;
            this.flujoService = flujoService;
        }

        [HttpPost("_FormaPago")]
        public IActionResult _FormaPago(FormaPagoViewModel viewModel)
        {
            IList<TbBaFlujoCategoria> flujoCategoria = new List<TbBaFlujoCategoria>(); 
            flujoCategoria = flujoService.GetAllFlujoCategoria();
            ViewData["denominaciones"] = denService.GetAllDenominaciones().OrderBy(m => m.Valor).ToList();
            ViewData["operadoresTarjeta"] = flujoCategoria.Where(o => o.IdTipoFlujo == 3).ToList();
            ViewData["bancos"] = flujoCategoria.Where(o => o.IdTipoFlujo == 1).ToList();
            ViewBag.flujoEfectivo = flujoCategoria.FirstOrDefault(e => e.IdTipoFlujo == 2).IdCategoriaFlujo;

            return PartialView(viewModel);
        }
    }
}