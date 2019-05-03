using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Controllers
{
    [Route("TipoProveedor")]
    public class TipoProveedorController : Controller
    {

        public TipoProveedorController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("CrearTipoProveedor")]
        public IActionResult CrearTipoProveedor()
        {
            return View();
        }
    }
}