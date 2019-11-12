using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class ContactoVisitaService : IContactoVisitaService
    {

        IContactoVisitaRepository repository;
        public ContactoVisitaService(IContactoVisitaRepository repository)
        {
            this.repository = repository;
        }




        public TbCrContactoVisita Save(TbCrContactoVisita domain)
        {
            return repository.Save(domain);
        }

        public TbCrContactoVisita Update(TbCrContactoVisita domain)
        {
            return repository.Update(domain);
        }

        public IList<TbCrContactoVisita> GetAllContactoVisita()
        {
            return repository.GetAllContactoVisita();
        }

        public TbCrContactoVisita GetContactoVisitaById(long id)
        {
            return repository.GetContactoVisitaById(id);
        }

      



    }
}
