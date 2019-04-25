using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Mappers
{
    public class EstadoTareaMapper : IEstadoTareaMapper
    {
        public IEstadoTareaService EstadoTareaService;
        public EstadoTareaMapper(IEstadoTareaService EstadoTareaService)
        {
            this.EstadoTareaService = EstadoTareaService;
        }

        public TbFdTareaEstado Save(EstadoTareaViewModel domain)
        {
            return this.EstadoTareaService.Save(viewToModelSave(domain));
        }

        public TbFdTareaEstado Update(EstadoTareaViewModel domain)
        {
            return this.EstadoTareaService.Update(viewToModelUpdate(domain));
        }

        public TbFdTareaEstado viewToModelSave(EstadoTareaViewModel domain)
        {
            TbFdTareaEstado te = new TbFdTareaEstado();
            te.Titulo = domain.Titulo;
            te.Color = domain.Color;
            te.Activo = domain.Activo;
            te.EsDefecto = domain.EsDefecto;
            te.EsFinal = domain.EsFinal;
            te.EsInicial = domain.EsInicial;
            te.FechaCreacion = DateTime.Now;
            

            return te;
        }

        public TbFdTareaEstado viewToModelUpdate(EstadoTareaViewModel domain)
        {
            TbFdTareaEstado te = new TbFdTareaEstado();
            te = this.EstadoTareaService.GetById(Convert.ToInt32( domain.Id));
            te.Titulo = domain.Titulo;
            te.Color = domain.Color;
            te.Activo = domain.Activo;
            te.EsDefecto = domain.EsDefecto;
            te.EsFinal = domain.EsFinal;
            te.EsInicial = domain.EsInicial;
      


            return te;
        }
    }
}
