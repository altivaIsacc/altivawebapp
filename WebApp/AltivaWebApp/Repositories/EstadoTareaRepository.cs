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

        // metodos utilizados cuando edita

        public TbFdTareaEstado GetTitulo(string titulo) // edita 1
        {
            return context.TbFdTareaEstado.FirstOrDefault(i => i.Titulo == titulo);
        }

        public TbFdTareaEstado GetColor(string color) //edita 2
        {
            return context.TbFdTareaEstado.FirstOrDefault(i => i.Color == color);
        }
        public TbFdTareaEstado GetDefecto(bool flag) //edita 3
        {
            return context.TbFdTareaEstado.FirstOrDefault(i => i.EsDefecto == flag);
        }
        public TbFdTareaEstado GetInicial(bool flag) //edita 4
        {
            return context.TbFdTareaEstado.FirstOrDefault(i => i.EsInicial == flag);
        }
        public TbFdTareaEstado GetFinal(bool flag) //edita 5
        {
            return context.TbFdTareaEstado.FirstOrDefault(i => i.EsFinal == flag);
        }



        // metodos utilizados cuando edita
        public bool GetByTitulo(string titulo) //edita
        {
            return context.TbFdTareaEstado.Any(u => u.Titulo == titulo);
        }

        public bool GetByColor(string color) //edita
        {
            return context.TbFdTareaEstado.Any(u => u.Color == color && u.Color != "#858585");
        }

        public bool GetByDefecto(bool? defecto) // edita
        {
            return context.TbFdTareaEstado.Any(u => u.EsDefecto == defecto);
        }

        public bool GetByEsInicial(bool? inicial) //edita
        {
            return context.TbFdTareaEstado.Any(u => u.EsInicial == inicial);
        }
         
        public bool GetByEsFinal(bool? final) //edita
        {
            return context.TbFdTareaEstado.Any(u => u.EsFinal == final);
        }





        public TbFdTareaEstado GetById(int idEstado)
        {
            return this.context.TbFdTareaEstado.Where(te => te.Id == idEstado).FirstOrDefault();
        }

      

   
    }
}
