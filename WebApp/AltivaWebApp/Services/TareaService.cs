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

        public TbFdTarea Delete(TbFdTarea domain)
        {
            throw new NotImplementedException();
        }

        public IList<TbFdTarea> GetAll()
        {
            return this.TareaRepository.GetAll();
        }

        public TbFdTarea GetById(int idTarea)
        {
            return this.TareaRepository.GetById(idTarea);
        }

        public TbFdTarea GetByPosicion(int posicion)
        {
            return TareaRepository.GetByPosicion(posicion);
        }

        public IList<TbFdTarea> GetTareas()
        {
            return this.TareaRepository.GetTareas();
        }

        public TbFdTarea Save(TbFdTarea domain)
        {
            return this.TareaRepository.Save(domain);
        }

        public TbFdTarea Update(TbFdTarea domain)
        {

            return this.TareaRepository.Update(domain);
        }

        public void UpdateRange(IList<TbFdTarea> domain)
        {
             this.TareaRepository.UpdateRange(domain);
        }
    }
}
