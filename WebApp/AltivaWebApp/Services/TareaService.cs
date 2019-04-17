using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
namespace AltivaWebApp.Services
{
    public class TareaService : ITareaService
    {

        //variable repository
        public ITareaRepository TareaRepository;
        public TareaService(ITareaRepository pTareaRepository)
        {
            this.TareaRepository = pTareaRepository;
        }

        public IList<TbFdTarea> GetAll()
        {
            return this.TareaRepository.GetAll();
        }
    }
}
