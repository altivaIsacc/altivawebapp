using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
   public interface ITareaRepository
    {
         IList<TbFdTarea> GetAll();
        IList<TbFdTarea> GetTareas();
        TbFdTarea Save(TbFdTarea tarea);
        TbFdTarea Update(TbFdTarea tarea);
        bool Delete(TbFdTarea tarea);
        TbFdTarea GetById(int idTarea);
        void UpdateRange(IList<TbFdTarea> domain);
        TbFdTarea GetByPosicion(int posicion);
    }
}
