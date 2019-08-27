using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Services;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Mappers;
namespace AltivaWebApp.Controllers
{


    [Route("{culture}/CamposPersonalizadosController")]
    public class CamposPersonalizadosController : Controller
    {
        //variable service
        public ICamposPersonalizadosService pCamposPersonalizados;

        public IContactoMap IcontactoMap;
        IListaDesplegableMapper map;
        //contructor
        public CamposPersonalizadosController(IContactoMap IcontactoMap, ICamposPersonalizadosService pCamposPersonalizados, IListaDesplegableMapper map)
        {
            this.pCamposPersonalizados = pCamposPersonalizados;
            this.IcontactoMap = IcontactoMap;
            this.map = map;
        }
        [HttpGet("TraerCamposPersonalizados")]
        public IActionResult TraerCamposPersonalizados()
        {
            IList<TbCrCamposPersonalizados> campos = new List<TbCrCamposPersonalizados>();
            campos = this.pCamposPersonalizados.GetCampos();
            return new JsonResult(campos);

        }
        // GET: CamposPersonalizados
        [HttpGet("Index")]
        public ActionResult Index()
        {
            IList<TbCrCamposPersonalizados> campos = new List<TbCrCamposPersonalizados>();
            campos = this.pCamposPersonalizados.GetAll(0);
            return View(campos);
            // return View(campos);
        }

        // GET: CamposPersonalizados/Details/5
        [HttpGet("Details/{id?}")]
        public IActionResult Details(int id)
        {


            TbCrCamposPersonalizados contactoMap = new TbCrCamposPersonalizados();
            contactoMap = this.pCamposPersonalizados.getById(id);
            return View(contactoMap);

        }
        [HttpPost("CrearCamposPersonalizados")]
    
        public IActionResult CrearCamposPersonalizados(CamposPersonalizadosViewModelSingle domain2)
        {
            ViewBag.id = 0;
            return PartialView("_CrearEditarCampos",domain2);
        }
        // GET: CamposPersonalizados/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("CrearNuevoCamposPersonalizados")]
        public IActionResult CrearNuevoCamposPersonalizados(CamposPersonalizadosViewModel domain)
        {
            List<TbCrCamposPersonalizados> ListaCampos = new List<TbCrCamposPersonalizados>();
          
            try
            {
                TbCrCamposPersonalizados vd = new TbCrCamposPersonalizados();
                vd = this.map.Save(domain);
                return new JsonResult(vd);
         
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return new JsonResult(1);
            }
        }

        // GET: CamposPersonalizados/Ed/it5
        [HttpGet("EditCampos/{id?}")]
        public ActionResult EditCampos(int id)
        {
            ViewBag.id = 1;
            TbCrCamposPersonalizados contactoMap = new TbCrCamposPersonalizados();
            contactoMap = this.pCamposPersonalizados.getById(id);
            CamposPersonalizadosViewModel domain2 = new CamposPersonalizadosViewModel();
            domain2.Id = Convert.ToInt32( contactoMap.Id);
            domain2.Nombre = contactoMap.Nombre;
            domain2.Tipo = contactoMap.Tipo;
            domain2.Estado = contactoMap.Estado;
            return PartialView("_CrearEditarCampos", domain2);
        }
        [HttpPost("Editar")]
        public ActionResult Editar(CamposPersonalizadosViewModel model1)
        {
            try
            {
               
                TbCrCamposPersonalizados contactoMap = new TbCrCamposPersonalizados();
                contactoMap = this.IcontactoMap.UpdateCP(model1);
                return new JsonResult(true);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return View();
            }
        }
        [HttpGet("Delete/{id?}")]
       public ActionResult Delete(int id)
        {
            TbCrCamposPersonalizados cp = new TbCrCamposPersonalizados();
            cp = this.IcontactoMap.EliminarCP(id);

            return new JsonResult(1);

        }

    }
}