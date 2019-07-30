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
               .Select(t => new TbFdTarea {
                   Cobrado = t.Cobrado,
                   CostoEstimado = t.CostoEstimado,
                   CostoReal = t.CostoReal,
                   Descripcion = t.Descripcion,
                   DiasEstimados = t.DiasEstimados,
                   DiasReales = t.DiasReales,
                   Eliminada = t.Eliminada,
                   FechaCreacion = t.FechaCreacion,
                   FechaFinal = t.FechaFinal,
                   FechaInicio = t.FechaInicio,
                   FechaLimite = t.FechaLimite,
                   Id = t.Id,
                   IdContacto = t.IdContacto,
                   IdContactoNavigation = new TbCrContacto
                   {
                       Nombre = t.IdContactoNavigation.Nombre,
                       Apellidos = t.IdContactoNavigation.Apellidos,
                       NombreComercial = t.IdContactoNavigation.NombreComercial,
                       Persona = t.IdContactoNavigation.Persona,
                       Empresa = t.IdContactoNavigation.Empresa,
                       Proveedor = t.IdContactoNavigation.Proveedor,
                       Cliente = t.IdContactoNavigation.Cliente,
                       NombreJuridico = t.IdContactoNavigation.NombreJuridico
                   },
                   IdEstado = t.IdEstado,
                   IdTipo = t.IdTipo,
                   IdEstadoNavigation = new TbFdTareaEstado {
                       Color = t.IdEstadoNavigation.Color,
                       Titulo = t.IdEstadoNavigation.Titulo
                   }, 
                   IdTipoNavigation = new TbFdTareaTipo {
                       Color = t.IdTipoNavigation.Color,
                       Titulo = t.IdTipoNavigation.Titulo
                   },
                   IdUsuario = t.IdUsuario,
                   MontoCobrad = t.MontoCobrad,
                   Posicion = t.Posicion,
                   TbFdSubtareas = t.TbFdSubtareas,
                   Titulo = t.Titulo

               })
               .Where(t => t.Eliminada == false)
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
