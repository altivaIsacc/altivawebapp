﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AltivaWebApp.Mappers;
using AltivaWebApp.Services;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Controllers
{
    [Route("TipoProveedor")]
    public class TipoProveedorController : Controller
    {
        //variable service
        public ITipoProveedorService ITipoProveedorService;

        //variable mapper
        public ITipoProveedorMapper ITipoProveedorMapper;
        
        public TipoProveedorController(ITipoProveedorService ITipoProveedor, ITipoProveedorMapper ITipoProveedorMapper)
        {
            this.ITipoProveedorService = ITipoProveedor;
            this.ITipoProveedorMapper = ITipoProveedorMapper;
                
                
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
        [HttpGet("PartialCrearTipoProveedor/{idProveedor?}")]
        public IActionResult PartialCrearTipoProveedor(int idProveedor)
        {
            TbFdTipoProveedor tc = new TbFdTipoProveedor();
            if (idProveedor != 0)
            {
               tc = this.ITipoProveedorService.GetById(idProveedor);
            }
            return PartialView("_CrearTipoProveedor", tc);
        }


        [HttpGet("PartialEditarTipoProveedor/{idProveedor?}")]
        public IActionResult PartialEditarTipoProveedor(int idProveedor)
        {
            TbFdTipoProveedor tc = new TbFdTipoProveedor();
            if (idProveedor != 0)
            {
                tc = this.ITipoProveedorService.GetById(idProveedor);
            }
            else
            {

              tc = this.ITipoProveedorService.GetById(idProveedor);
            }
            return PartialView("_EditarTipoProveedor", tc);
        }
        //metodo para guardar los tipos de clientes
        [HttpPost("CrearTipoProveedor")]
        public IActionResult CrearTipoProveedor(TipoClienteViewModel domain)
        {
            try
            {
                TbFdTipoProveedor tc = new TbFdTipoProveedor();
               tc = this.ITipoProveedorMapper.Save(domain);
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
        [HttpPost("EditarTipoProveedor")]
        public IActionResult EditarTipoProveedor(TipoClienteViewModel domain)
        {
            try
            {
                TbFdTipoProveedor tc = new TbFdTipoProveedor();
                tc = this.ITipoProveedorMapper.Update(domain);
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
        [HttpGet("GetTiposDeProveedores")]
        public IActionResult GetTiposDeProveedores()
        {
            IList<TbFdTipoProveedor> TipoClientes = new List<TbFdTipoProveedor>();
            TipoClientes = this.ITipoProveedorService.GetTipoProveedor();
            return new JsonResult(TipoClientes);
        }
        [HttpGet("GetFamiliasTipoProveedor/{idProveedor?}")]
        public IActionResult GetFamiliasTipoProveedor(int idProveedor)
        {
            IList<TbFdTipoProveedor> TipoClientes = new List<TbFdTipoProveedor>();
           TipoClientes = this.ITipoProveedorService.GetFamiliaTipoProveedor(idProveedor);
            return new JsonResult(TipoClientes);
        }
        [HttpGet("GetSubFamiliasProveedor/{idProveedor?}")]
        public IActionResult GetSubFamiliasProveedor(int idProveedor)
        {
            IList<TbFdTipoProveedor> TipoClientes = new List<TbFdTipoProveedor>();
           TipoClientes = this.ITipoProveedorService.GetSubFamiliaProveedor(idProveedor);
            return new JsonResult(TipoClientes);
        }
    }
}