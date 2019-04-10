using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class FamiliaService: IFamiliaService
    {
        readonly IFamiliaRepository repository;
        public FamiliaService(IFamiliaRepository repository)
        {
            this.repository = repository;
        }

        public TbPrFamilia Save(TbPrFamilia domain)
        {
            return repository.Save(domain);
        }
        public TbPrFamilia Update(TbPrFamilia domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(TbPrFamilia domain)
        {
            return repository.Delete(domain);
        }
        public IList<TbPrFamilia> GetAll()
        {
            return repository.GetAll();
        }
        public TbPrFamilia GetFamiliaById(int id)
        {
            return repository.GetFamiliaById(id);
        }
        public IList<TbPrFamilia> GetAllFamilias()
        {
            return repository.GetAllFamilias();
        }
        public IList<TbPrFamilia> GetAllSubFamilias()
        {
            return repository.GetAllSubFamilias();
        }
        public void UpdateSubFamilia(IList<TbPrFamilia> subFamilias)
        {
            repository.UpdateSubFamilia(subFamilias);
        }
    }
}
