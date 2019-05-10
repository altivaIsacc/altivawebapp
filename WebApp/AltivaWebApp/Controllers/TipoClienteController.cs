using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Controllers
{
    [Route("{culture}/TipoCliente")]
    public class TipoClienteController : Controller
    {

        //variable que instacia a al servicio del tipo cliente:
        public ITipoClienteService ITipoClientes;
        //variable para mappear datos de la vista por seguridad de la aplicacion.
        public ITipoClienteMapper ITipoMapper;
        //controlador
        public TipoClienteController(ITipoClienteService ITipoClientes, ITipoClienteMapper ITipoMapper)
        {
            this.ITipoClientes = ITipoClientes;
            this.ITipoMapper = ITipoMapper;
        }
        [HttpGet("EliminarSubFamiliaCliente/{idCliente?}")]
        public IActionResult EliminarSubFamiliaCliente(int idCliente)
        {
            TbFdTipoCliente tipoC = new TbFdTipoCliente();
            tipoC = this.ITipoClientes.GetById(idCliente);
            bool bandera = this.ITipoClientes.Delete(tipoC);
            return Ok(true);
           
        }
     [HttpGet("EliminarFamiliaCliente/{idCliente?}")]
     public IActionResult EliminarFamiliaCliente(int idCliente)
        {

            IList<TbFdTipoCliente> tipoCliente = new List<TbFdTipoCliente>();
            tipoCliente = this.ITipoClientes.GetSubFamilia(idCliente);
            if (tipoCliente.Count() > 0)
            {
                return Ok(false);
            }
            else
            {
                TbFdTipoCliente tipoC = new TbFdTipoCliente();
                tipoC = this.ITipoClientes.GetById(idCliente);
                bool bandera = this.ITipoClientes.Delete(tipoC);
                return Ok(true);
            }
         
        }
        [HttpGet("EliminarTipoCliente/{idCliente?}")]
        public IActionResult EliminarTipoCliente(int idCliente)
        {
            IList<TbFdTipoCliente> tipoCliente = new List<TbFdTipoCliente>();
            tipoCliente = this.ITipoClientes.GetFamiliaTipoCliente(idCliente);
            if (tipoCliente.Count() > 0)
            {
                return Ok(false);
            }
            else
            {
                TbFdTipoCliente tipoC = new TbFdTipoCliente();
                tipoC = this.ITipoClientes.GetById(idCliente);
                bool bandera = this.ITipoClientes.Delete(tipoC);
                return Ok(true);
            }
            
        }

     [HttpGet("CrearTipoClientes")]
        public ActionResult CrearTipoClientes()
        {

            return View();
        }
        [HttpGet("PartialCrearTipoCliente/{idCliente?}")]
        public IActionResult PartialCrearTipoCliente(int idCliente)
        {
            TbFdTipoCliente tc = new TbFdTipoCliente();
            if (idCliente != 0) {
                tc = this.ITipoClientes.GetById(idCliente);
            }
            return PartialView("_CrearEditarTipoCliente",tc);
        }


        [HttpGet("PartialEditarTipoCliente/{idCliente?}")]
        public IActionResult PartialEditarTipoCliente(int idCliente)
        {
            TbFdTipoCliente tc = new TbFdTipoCliente();
            if (idCliente != 0)
            {
                tc = this.ITipoClientes.GetById(idCliente);
            }
            else
            {

                tc = this.ITipoClientes.GetById(idCliente);
            }
            return PartialView("_EditarTipoCliente",tc);
        }
        //metodo para guardar los tipos de clientes
        [HttpPost("CrearTipoCliente")]
        public IActionResult CrearTipoCliente(TipoClienteViewModel domain)
        {
            try
            {
                TbFdTipoCliente tc = new TbFdTipoCliente();
                tc = this.ITipoMapper.Save(domain);
                if (tc != null)
                {
                    return Ok(true);
                }
            }
            catch
            {
                throw;
            }
            return Ok();
        }
        [HttpPost("EditarTipoCliente")]
        public IActionResult EditarTipoCliente(TipoClienteViewModel domain)
        {
            try
            {
                TbFdTipoCliente tc = new TbFdTipoCliente();
                tc = this.ITipoMapper.Update(domain);
                if (tc != null)
                {
                    return Ok(tc.IdPadre);
                }
            }
            catch
            {
                throw;
            }
            return Ok();
        }
        [HttpGet("GetTiposDeClientes")]
        public IActionResult GetTiposClientes()
        {
            IList<TbFdTipoCliente> TipoClientes = new List<TbFdTipoCliente>();
            TipoClientes = this.ITipoClientes.GetTipoCliente();
            if (TipoClientes.Count() > 0) {
                return new JsonResult(TipoClientes);
            }
            else
            {
                return new JsonResult(false);
            }
        }
        [HttpGet("GetFamiliasTipoCliente/{idCliente?}")]
        public IActionResult GetFamiliasTipoCliente(int idCliente)
        {
            IList<TbFdTipoCliente> TipoClientes = new List<TbFdTipoCliente>();
            TipoClientes = this.ITipoClientes.GetFamiliaTipoCliente(idCliente);

            if (TipoClientes.Count() > 0)
            {
                return new JsonResult(TipoClientes);
            }
            else
            {
                return new JsonResult(false);
            }
        }
        [HttpGet("GetSubFamilias/{idCliente?}")]
        public IActionResult GetSubFamilias(int idCliente)
        {
            IList<TbFdTipoCliente> TipoClientes = new List<TbFdTipoCliente>();
            TipoClientes = this.ITipoClientes.GetSubFamilia(idCliente);
           
            if (TipoClientes.Count() > 0)
            {
                return new JsonResult(TipoClientes);
            }
            else
            {
                return new JsonResult(false);
            }
        }

    }
}