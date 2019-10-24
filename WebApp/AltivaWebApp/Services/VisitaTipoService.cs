using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class VisitaTipoService : IVisitaTipoService
    {


        IVisitaTipoRepository repository;
        public VisitaTipoService(IVisitaTipoRepository repository)
        {
            this.repository = repository;
        }




        public TbCrVisitaTipo Save(TbCrVisitaTipo domain)
        {
            return repository.Save(domain);
        }

        public TbCrVisitaTipo Update(TbCrVisitaTipo domain)
        {
            return repository.Update(domain);
        }


        public IList<TbCrVisitaTipo> GetAllVisitaTipo()
        {
            return repository.GetAllVisitaTipo();
        }

        public TbCrVisitaTipo GetVisitaTipoById(int id)
        {
            return repository.GetVisitaTipoById(id);
        }

       



    }
}
