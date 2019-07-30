using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class FamiliaOnlineService : IFamiliaOnlineService
    {
        readonly IFamiliaOnlineRepository repository;

        public FamiliaOnlineService(IFamiliaOnlineRepository repository)
        {
            this.repository = repository;
        }

        public TbPrFamiliaVentaOnline Save(TbPrFamiliaVentaOnline domain)
        {
            return repository.Save(domain);
        }

        public TbPrFamiliaVentaOnline Update(TbPrFamiliaVentaOnline domain)
        {
            return repository.Update(domain);
        }

        public bool Delete(TbPrFamiliaVentaOnline domain)
        {
            return repository.Delete(domain);
        }
        public IList<TbPrFamiliaVentaOnline> GetAll()
        {
            return repository.GetAll();
        }
        public TbPrFamiliaVentaOnline GetFamiliaById(int id)
        {
            return repository.GetFamiliaById(id);
        }
        public IList<TbPrFamiliaVentaOnline> GetAllFamilias()
        {
            return repository.GetAllFamilias();
        }
        public IList<TbPrFamiliaVentaOnline> GetAllSubFamilias()
        {
            return repository.GetAllSubFamilias();
        }
        public void UpdateSubFamilia(IList<TbPrFamiliaVentaOnline> subFamilias)
        {
            repository.UpdateSubFamilia(subFamilias);
        }

        public TbPrFamiliaVentaOnline GetFamiliaByDescripcion(string descripcion)
        {
            return repository.GetFamiliaByDescripcion(descripcion);
        }
    }
}
