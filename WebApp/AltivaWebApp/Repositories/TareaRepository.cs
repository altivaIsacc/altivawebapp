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
        public void UpdateRange(IList<TbFdTarea> domain)
        {
            context.TbFdTarea.UpdateRange(domain);
            context.SaveChanges();
        }
        public TbFdTarea GetById(int idTarea)
        {
            return this.context.TbFdTarea.Where(tarea => tarea.Id == idTarea).FirstOrDefault();
        }
        public TbFdTarea GetByPosicion(int posicion)
        {
            return this.context.TbFdTarea.Where(tarea => tarea.Posicion == posicion).FirstOrDefault();
        }
        public IList<TbFdTarea> GetTareas()
        {
            return context.TbFdTarea.OrderBy(afg => afg.Posicion)
               .Include(c => c.IdContactoNavigation)

               .Include(e => e.IdEstadoNavigation)
                   .Include(t => t.IdTipoNavigation)
                   .ToList();
        }

        public void SaveRange(IList<TbFdSubtareas> domain)
        {
            context.TbFdSubtareas.AddRange(domain);
            context.SaveChanges();
        }

        public IList<TbFdSubtareas> GetSubTareas(int idTarea)
        {
            return context.TbFdSubtareas.Where(su => su.IdTarea == idTarea).Include( su => su.IdTareaNavigation).ToList();
        }

        public void UpdateRangeSubTareas(IList<TbFdSubtareas> domain)
        {
            context.TbFdSubtareas.UpdateRange(domain);
            context.SaveChanges();
        }
        //borrar subtareas...
        public TbFdSubtareas RemoveSubtareas(int SubTarea)
        {
            var query = (from p in context.TbFdSubtareas
                         where p.Id == SubTarea
                         select p).Single();

            context.Remove(query);
            context.SaveChanges();
            return query;
        }

        public bool ExisteTipo()
        {
            return context.TbFdTareaTipo.Any();
        }

        public bool ExisteEstado()
        {
            return context.TbFdTareaEstado.Any();
        }

    }
}
