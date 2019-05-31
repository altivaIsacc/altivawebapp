using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    [Route("/{culture}/Descuentos- Promociones")]
    public class DescuentoPromocionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}