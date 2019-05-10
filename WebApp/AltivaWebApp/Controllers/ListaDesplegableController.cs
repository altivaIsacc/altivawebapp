using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
namespace AltivaWebApp.Controllers
{
    [Route("{culture}/ListaDesplegableController")]
    public class ListaDesplegableController : Controller
    {
         IListaDesplegableMapper map;
        IListaDesplegableService service;
        ICamposPersonalizadosService pCamposPersonalizados;


        public ListaDesplegableController(IListaDesplegableMapper map, IListaDesplegableService service, ICamposPersonalizadosService pCamposPersonalizados)
        {
            this.service = service;
            this.map = map;
            this.pCamposPersonalizados = pCamposPersonalizados;
        }
       [HttpGet("CrearLista")]
        public IActionResult CrearLista()

       {

            ViewBag.id = 0;
            CamposPersonalizadosViewModelSingle domain2 = new CamposPersonalizadosViewModelSingle();

            return PartialView("_CrearEditar",domain2 );
        }

        [HttpGet("GetLista/{id?}")]
        public IActionResult GetLista(int id)
        {
            IList<ListaDesplegableGETViewModel> vs = new List<ListaDesplegableGETViewModel>();
            vs = this.service.GetCampos(id);

            return PartialView("ListasDesplegables", vs);
        }
        [HttpPost("CrearCampos")]
        public IActionResult CrearCampos(CamposPersonalizadosViewModelSingle model1)
        {
            TbCrCamposPersonalizados vd = new TbCrCamposPersonalizados();
           vd = this.map.Save(model1);
            return new JsonResult(vd);
        }
        [HttpGet("EditCampos/{id?}")]
        public IActionResult EditCampos(int id)
        { 
            try
            {
                ViewBag.id = 1;
                TbCrCamposPersonalizados contactoMap = new TbCrCamposPersonalizados();
                contactoMap = this.pCamposPersonalizados.getById(id);
                CamposPersonalizadosViewModelSingle domain2 = new CamposPersonalizadosViewModelSingle();
                domain2.Id = Convert.ToInt32(contactoMap.Id);
                domain2.Nombre = contactoMap.Nombre;
                domain2.Tipo = contactoMap.Tipo;
                domain2.Estado = contactoMap.Estado;
                return PartialView("_CrearEditar", domain2);
            }
            catch
            {

            }

            return new JsonResult(true);
        }
        [HttpPost("CrearCamposRelacionLista")]
        public IActionResult CrearCamposRelacionLista(IList<ListaViewModel> lista)
        {
            this.map.SaveRange(lista);
            return new JsonResult(2);
        }
        [HttpPost("EditarListaCampos")]
        public IActionResult EditarListaCampos(IList<ListaViewModel> domain)
        {
            this.map.UpdateRange(domain);
            return new JsonResult(true);
        }
        [HttpGet("GetCampos/{id?}")]
        public IActionResult GetCampos(int id)
        {
            IList<ListaDesplegableGETViewModel> vs = new List<ListaDesplegableGETViewModel>();
            vs = this.service.GetCampos(id);
            return new JsonResult(vs);
        }
        [HttpGet("Delete/{id?}")]
        public IActionResult Delete(int id)
        {
            bool resutl;
            resutl = this.service.Delete(id);

            return new JsonResult(resutl);
        }
    }
}