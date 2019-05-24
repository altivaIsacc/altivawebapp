﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;

namespace AltivaWebApp.Services
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository repository;
        public CompraService(ICompraRepository repository)
        {
            this.repository = repository;
        }

        public bool ExisteDocumento(string numDoc, string tipo, int idProveedor)
        {
            return repository.ExisteDocumento(numDoc, tipo, idProveedor);
        }
        public TbPrCompra GetCompraByDocumento(string nDoc, string tipoDoc, long idProveedor)
        {
            return repository.GetCompraByDocumento(nDoc, tipoDoc, idProveedor);
        }

        public bool DeleteCompraDetalle(TbPrCompraDetalle domain)
        {
            return repository.DeleteCompraDetalle(domain);
        }

        public IList<TbPrCompraDetalle> GetAllCompraDetalleByCompraId(int id)
        {
            return repository.GetAllCompraDetalleByCompraId(id);
        }

        public IList<TbPrCompra> GetAllCompras()
        {
            return repository.GetAllCompras();
        }

        public TbPrCompra GetCompraById(int id)
        {
            return repository.GetCompraById(id);
        }

        public TbPrCompra Save(TbPrCompra domain)
        {
            return repository.Save(domain);
        }

        public TbPrCompraDetalle SaveCompraDetalle(TbPrCompraDetalle domain)
        {
            return repository.SaveCompraDetalle(domain);
        }

        public bool ExisteRelacionInventarioBodega(long idInventario, long idBodega)
        {
            return repository.ExisteRelacionInventarioBodega(idInventario, idBodega);
        }
        public TbPrCompraDetalle GetCompraDetalleById(long id)
        {
            return repository.GetCompraDetalleById(id);
        }

        public TbPrCompra Update(TbPrCompra domain)
        {
            return repository.Update(domain);
        }

        public bool UpdateCompraDetalle(IList<TbPrCompraDetalle> domain)
        {
            return repository.UpdateCompraDetalle(domain);
        }

        public long IdUltimoDocumento()
        {
            return repository.IdUltimoDocumento();
        }
    }
}