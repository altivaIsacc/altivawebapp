using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Services
{
    public class OrdenService: IOrdenService
    {
        private readonly IOrdenRepository repository;
        public IList<TbCrContacto> GetAllProveedores()
        {
            return repository.GetAllProveedores();
        }
        public OrdenService(IOrdenRepository repository)
        {
            this.repository = repository;
        }

        public TbPrOrden Save(TbPrOrden domain)
        {
            return repository.Save(domain);
        }
        public TbPrOrden Update(TbPrOrden domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(TbPrOrden domain)
        {
            return repository.Delete(domain);
        }
        public IList<TbPrOrden> GetAllOrdenes()
        {
            return repository.GetAllOrdenes();
        }
        public TbPrOrden GetOrdenById(int id)
        {
            return repository.GetOrdenById(id);
        }
        //public TbPrOrden GetAllOrdenDetalleByOrdenId(int id)
        //{
        //    return repository.GetAllOrdenDetalleByOrdenId(id);
        //}
        public IList<CompraAutomaticoViewModel> compraProveedor(int id)
        {
            return repository.compraProveedor(id);
        }

        public IList<TbPrOrdenDetalle> GetAllOrdenDetalleByOrdenId(int id)
        {
            return repository.GetAllOrdenDetalleByOrdenId(id);
        }
        public bool SaveOrdenDetalle(IList<TbPrOrdenDetalle> domain)
        {
            return repository.SaveOrdenDetalle(domain);
        }
        public bool UpdateOrdenDetalle(IList<TbPrOrdenDetalle> domain)
        {
            return repository.UpdateOrdenDetalle(domain);
        }
        public bool DeleteOrdenDetalle(IList<int> domain, int idOrden)
        {
            return repository.DeleteOrdenDetalle(domain, idOrden);
        }


    }
}
