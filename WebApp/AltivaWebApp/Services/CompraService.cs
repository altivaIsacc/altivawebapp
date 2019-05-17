using System;
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
        public TbPrCompra GetCompraByDocumento(string nDoc, string tipoDoc)
        {
            return repository.GetCompraByDocumento(nDoc, tipoDoc);
        }

        public bool DeleteCompraDetalle(IList<int> domain, int idCompra)
        {
            return repository.DeleteCompraDetalle(domain, idCompra);
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

        public bool SaveCompraDetalle(IList<TbPrCompraDetalle> domain)
        {
            return repository.SaveCompraDetalle(domain);
        }

        public TbPrCompra Update(TbPrCompra domain)
        {
            return repository.Update(domain);
        }

        public bool UpdateCompraDetalle(IList<TbPrCompraDetalle> domain)
        {
            return repository.UpdateCompraDetalle(domain);
        }
    }
}
