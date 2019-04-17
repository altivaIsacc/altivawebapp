using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
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

    }
}
