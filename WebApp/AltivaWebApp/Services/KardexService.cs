using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class KardexService: IKardexService
    {
        private readonly IKardexRepository repository;
        public KardexService(IKardexRepository repository)
        {
            this.repository = repository;
        }

        public IList<TbPrKardex> GetAll()
        {
            return repository.GetAll();
        }

        public IList<TbPrKardex> GetAllKardexByDocumento(int id)
        {
            return repository.GetAllKardexByDocumento(id);
        }

        public IList<TbPrKardex> GetAllKardexByTipoDocumento(string tipo)
        {
            return repository.GetAllKardexByTipoDocumento(tipo);
        }

        public TbPrKardex Save(TbPrKardex domain)
        {
            return repository.Save(domain);
        }

        public TbPrKardex Update(TbPrKardex domain)
        {
            return repository.Update(domain);
        }
        public IList<TbPrKardex> SaveAll(IList<TbPrKardex> domain)
        {
            return repository.SaveAll(domain);
        }
    }
}
