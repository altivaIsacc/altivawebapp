using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Mappers;
namespace AltivaWebApp.Controllers
{

 
    public class CentroDeCostosController : Controller
    {
        //variable que instancia al service del centro de costos
        public ICentroCostosService ICentroCostosService;
        //instancia costos usuarios mmaper
        public ICostoUsuarioMapper ICostoUsuarioMapper;
        //contructos centro costos por usuario
        public CentroDeCostosController(ICentroCostosService ICentroCostosService, ICostoUsuarioMapper ICostoUsuarioMapper)
        {
            this.ICentroCostosService = ICentroCostosService;
            this.ICostoUsuarioMapper = ICostoUsuarioMapper;
        }

        // GET: CentroDeCostos
        public ActionResult ListaCentroDeCostos()
        {
           
            return View();
        }



        // GET: CentroDeCostos/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CrearEditarCostos(int IdUsuario)
        {

            TbFdUsuarioCosto domain = new TbFdUsuarioCosto();
            ViewBag.id = IdUsuario;
            domain = this.ICentroCostosService.GetById(IdUsuario);
            
            return PartialView("_CrearEditarCostos",domain);
        }
       [HttpPost]
       public JsonResult CrearCosto(CentroCostosViewModel domain)
        {
            TbFdUsuarioCosto uc = new TbFdUsuarioCosto();
            uc = this.ICostoUsuarioMapper.Save(domain);

            return new JsonResult(true);
        }
        [HttpPost]
        public JsonResult EditarCosto(CentroCostosViewModel domain)
        {
            TbFdUsuarioCosto uc = new TbFdUsuarioCosto();
            uc = this.ICostoUsuarioMapper.Update(domain);


            return new JsonResult(true);
        }

        [HttpGet]
        public IActionResult ListaCostos()
        {
            IList<TbSeUsuario> usuarioCosto = new List<TbSeUsuario>();
            usuarioCosto = this.ICentroCostosService.GetAll();
            return PartialView("_ListarCostosUsuarios",usuarioCosto);
        }
    }
}