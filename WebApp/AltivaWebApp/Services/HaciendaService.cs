using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class HaciendaService: IHaciendaService
    {
        private readonly IColaAprobacionRepository colaRepository;

        public HaciendaService(IColaAprobacionRepository colaRepository)
        {
            this.colaRepository = colaRepository;
        }


        public TbCeColaAprobacion SaveCA(TbCeColaAprobacion domain)
        {
            return colaRepository.Save(domain);
        }

        public TbCeColaAprobacion UpdateCA(TbCeColaAprobacion domain)
        {
            return colaRepository.Save(domain);
        }

        public IList<TbCeColaAprobacion> GetAllCA()
        {
            return colaRepository.GetAll();
        }

        public IList<TbCeColaAprobacion> GetAllCASinAnular()
        {
            return colaRepository.GetAllSinAnular();
        }

        public TbCeColaAprobacion GetCAById(long id)
        {
            return colaRepository.GetByIdDoc(id);
        }


    }
}
