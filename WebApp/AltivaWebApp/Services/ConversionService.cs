using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class ConversionService : IConversionService
    {
        readonly IConversionRepository repository;

        public ConversionService(IConversionRepository repository)
        {
            this.repository = repository;
        }

        public TbPrConversion Save(TbPrConversion domain)
        {
            return repository.Save(domain);
        }

        public TbPrConversion Update(TbPrConversion domain)
        {
            return repository.Update(domain);
        }

        public bool Delete(TbPrConversion domain)
        {
            return repository.Delete(domain);
        }

        public IList<TbPrConversion> GetAll()
        {
            return repository.GetAll();
        }

        public TbPrConversion GetConversionById(int id)
        {
            return repository.GetConversionById(id);
        }
    }
}
