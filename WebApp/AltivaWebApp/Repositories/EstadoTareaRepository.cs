using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
    public class EstadoTareaRepository : BaseRepository<TbFdTareaEstado>, IEstadoTareaRepository
    {
        public EstadoTareaRepository(EmpresasContext context) : base(context)
        {
        }

        public bool GetByColor(string color)
        {
            return context.TbFdTareaEstado.Any(u => u.Color == color && u.Color != "#858585");
        }

        public bool GetByDefecto(bool? defecto)
        {
            return context.TbFdTareaEstado.Any(u => u.EsDefecto == defecto);
        }

        public bool GetByEsInicial(bool? inicial)
        {
            return context.TbFdTareaEstado.Any(u => u.EsInicial == inicial);
        }

        public bool GetByEsFinal(bool? final)
        {
            return context.TbFdTareaEstado.Any(u => u.EsFinal == final);
        }

        public TbFdTareaEstado GetById(int idEstado)
        {
            return this.context.TbFdTareaEstado.Where(te => te.Id == idEstado).FirstOrDefault();
        }

        public bool GetByTitulo(string titulo)
        {
            return context.TbFdTareaEstado.Any(u => u.Titulo == titulo);
        }
        public TbFdTareaEstado GetColor(string color)
        {
            return context.TbFdTareaEstado.FirstOrDefault(i => i.Color == color );
        }
        public TbFdTareaEstado GetDefecto(bool flag)
        {
            return context.TbFdTareaEstado.FirstOrDefault(i => i.EsDefecto == flag);
        }
        public TbFdTareaEstado GetInicial(bool flag)
        {
            return context.TbFdTareaEstado.FirstOrDefault(i => i.EsInicial == flag);
        }
        public TbFdTareaEstado GetFinal(bool flag)
        {
            return context.TbFdTareaEstado.FirstOrDefault(i => i.EsFinal == flag);
        }
        public TbFdTareaEstado GetTitulo(string titulo)
        {
            return context.TbFdTareaEstado.FirstOrDefault(i => i.Titulo == titulo);
        }
    }
}
