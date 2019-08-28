using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using Microsoft.AspNetCore.Mvc;

namespace AltivaWebApp.Controllers
{
    public class ContaAsientoController : Controller
    {
        BaseConta bd;
        public ContaAsientoController(BaseConta _bd)
        {
            bd = _bd;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}