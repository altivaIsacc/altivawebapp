using System;
using System.Collections.Generic;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;

namespace AltivaWebApp.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository repository;
        public FacturaService(IFacturaRepository repository)
        {
            this.repository = repository;
        }

        public bool DeleteFacturaDetalle(IList<long> domain)
        {
            return repository.DeleteFacturaDetalle(domain);
        }

        public IList<TbFdFactura> GetAllFacturas()
        {
            return repository.GetAllFacturas();
        }

        public TbFdFactura GetFacturaById(long id)
        {
            return repository.GetFacturaById(id);
        }

        public IList<TbFdFacturaDetalle> GetFacturaDetalleById(long id)
        {
            return repository.GetFacturaDetalleById(id);
        }
        

        public TbFdFactura Save(TbFdFactura Factura)
        {
            return repository.Save(Factura);
        }

        public IList<TbFdFacturaDetalle> SaveFacturaDetalle(IList<TbFdFacturaDetalle> domain)
        {
            return repository.SaveFacturaDetalle(domain);
        }

        public TbFdFactura Update(TbFdFactura Factura)
        {
            return repository.Update(Factura);
        }

        public IList<TbFdFacturaDetalle> UpdateFacturaDetalle(IList<TbFdFacturaDetalle> domain)
        {
            return repository.UpdateFacturaDetalle(domain);
        }

        public long GetIdTipoPrecioCliente(long idCliente)
        {
            return repository.GetIdTipoPrecioCliente(idCliente);
        }
    }
}
