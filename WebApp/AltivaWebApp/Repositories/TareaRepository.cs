using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;

namespace AltivaWebApp.Repositories
{
    public class TareaRepository : BaseRepository<TbFdTarea>, ITareaRepository
    {
        public TareaRepository(EmpresasContext context) : base(context)
        {
        }

        public TbFdTarea GetById(int idTarea)
        {
            return this.context.TbFdTarea.Where(tarea => tarea.Id == idTarea).FirstOrDefault();
        }

        public IList<TbFdTarea> GetTareas()
        {
            return context.TbFdTarea
               .Include(c => c.IdContactoNavigation)
               
               .Include(e => e.IdEstadoNavigation)
                   .Include(t => t.IdTipoNavigation)
                   .ToList();
        }
    }
}
