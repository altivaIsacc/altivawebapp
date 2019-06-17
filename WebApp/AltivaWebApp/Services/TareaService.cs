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

        public TbFdTarea EliminarTarea(int idContacto)
        {
            TbFdTarea eliminarTarea = new TbFdTarea();
            eliminarTarea = this.GetById(idContacto);
            eliminarTarea.Eliminada = true;
            return this.TareaRepository.Update(eliminarTarea);
        }

        public bool ExisteEstado()
        {
            return TareaRepository.ExisteEstado();
        }

        public bool ExisteTipo()
        {
            return TareaRepository.ExisteTipo();
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

        public IList<TbFdSubtareas> GetSubTareas(int idTarea)
        {
            return this.TareaRepository.GetSubTareas(idTarea);
        }

        public IList<TbFdTarea> GetTareas()
        {
            return this.TareaRepository.GetTareas();
        }

        public TbFdSubtareas RemoveSubtareas(int SubTarea)
        {
            return this.TareaRepository.RemoveSubtareas(SubTarea);
        }

        public TbFdTarea Save(TbFdTarea domain)
        {
            return this.TareaRepository.Save(domain);
        }

        public void SaveRange(IList<TbFdSubtareas> domain)
        {
             this.TareaRepository.SaveRange(domain);
        }

        public TbFdTarea Update(TbFdTarea domain)
        {

            return this.TareaRepository.Update(domain);
        }

        public void UpdateRange(IList<TbFdTarea> domain)
        {
             this.TareaRepository.UpdateRange(domain);
        }

        public void UpdateRange(IList<TbFdSubtareas> domain)
        {
            this.TareaRepository.UpdateRangeSubTareas(domain);
        }
    }
}
