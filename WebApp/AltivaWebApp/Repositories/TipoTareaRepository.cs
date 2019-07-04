using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
    public class TipoTareaRepository : BaseRepository<TbFdTareaTipo>, ITipoTareaRepository
    {

        //contructor context
        public TipoTareaRepository(EmpresasContext context) : base(context)
        {
        }

        public bool TieneTareasAsignadas(int idTipo)
        {
            return context.TbFdTarea.Any(t => t.IdTipo == idTipo);
        }

        public bool GetByColor(string color)
        {
            return context.TbFdTareaTipo.Any(u => u.Color == color && u.Color != "#858585");
        }

        public bool GetByDefecto(bool? defecto)
        {
            return context.TbFdTareaTipo.Any(u => u.EsTipoDefecto == defecto && u.Activo == true);
        }

        public TbFdTareaTipo GetById(int idTipo)
        {
            return context.TbFdTareaTipo.FirstOrDefault(i => i.Id == idTipo);
        }

        public bool GetByTitulo(string titulo)
        {
            return context.TbFdTareaTipo.Any(u => u.Titulo == titulo);
        }

        public TbFdTareaTipo GetColor(string color)
        {
            return context.TbFdTareaTipo.FirstOrDefault(i => i.Color == color );
        }
        public TbFdTareaTipo GetDefecto(bool flag)
        {
            return context.TbFdTareaTipo.FirstOrDefault(i => i.EsTipoDefecto == flag );
        }
        public TbFdTareaTipo GetTitulo(string titulo)
        {
            return context.TbFdTareaTipo.FirstOrDefault(i => i.Titulo == titulo );
        }
    }
}
