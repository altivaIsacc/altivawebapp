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
    public class ListaDesplegableController : Controller
    {
         IListaDesplegableMapper map;
        IListaDesplegableService service;
        
        public ListaDesplegableController(IListaDesplegableMapper map, IListaDesplegableService service)
        {
            this.service = service;
            this.map = map;
        }
       [HttpGet]
        public IActionResult CrearLista()
        {

            
            return PartialView("_CrearEditar", new TbCrListaDesplegables());
        }
        public JsonResult CrearCampos(CamposPersonalizadosViewModelSingle model1)
        {
            TbCrCamposPersonalizados vd = new TbCrCamposPersonalizados();
           vd = this.map.Save(model1);
            return new JsonResult(vd);
        }
        public JsonResult CrearCamposRelacionLista(IList<ListaViewModel> lista)
        {
            this.map.SaveRange(lista);
            return new JsonResult(2);
        }

        public JsonResult GetCampos(int id)
        {
            IList<ListaDesplegableGETViewModel> vs = new List<ListaDesplegableGETViewModel>();
            vs = this.service.GetCampos(id);
            return new JsonResult(vs);
        }


    }
}