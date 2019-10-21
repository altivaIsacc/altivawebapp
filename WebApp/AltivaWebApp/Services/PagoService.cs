using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class PagoService : IPagoService
    {
        private readonly IPagoRepository repository;
        public PagoService(IPagoRepository repository)
        {
            this.repository = repository;
        }

        public IList<TbFaPago> GetAll()
        {
            return repository.GetAll();
        }

        public TbFaPago GetPagoById(long id)
        {
            return repository.GetPagoById(id);
        }

        public TbFaPago Save(TbFaPago domain)
        {
            return repository.Save(domain);
        }

        public TbFaPago Update(TbFaPago domain)
        {
            return repository.Update(domain);
        }
    }
}
