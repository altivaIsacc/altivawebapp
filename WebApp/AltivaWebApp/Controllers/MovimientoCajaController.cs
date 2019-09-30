using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            ViewData["denominaciones"] = denService.GetAllDenominaciones().OrderBy(m => m.Valor).ToList();
            ViewData["operadores"] = flujoService.GetAllFlujoCategoria().Where(o => o.IdTipoFlujo == 3).ToList();

            return PartialView(viewModel);
        }
    }
}