using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Services;
namespace AltivaWebApp.Mappers
{
    public class TipoTareaMapper : ITipoTareaMapper
    {
        //
        public ITipoTareaService ITipoTareaService;
        //constructor
        public TipoTareaMapper(ITipoTareaService ITipoTareaService)
        {
            this.ITipoTareaService = ITipoTareaService;
        }

        public TbFdTareaTipo Save(TipoTareaViewModel domain)
        {
            return this.ITipoTareaService.Save(viewToModelSave(domain));
        }

        public TbFdTareaTipo Update(TipoTareaViewModel domain)
        {
            return this.ITipoTareaService.Update(viewToModelUpdate(domain));
        }

        public TbFdTareaTipo viewToModelSave(TipoTareaViewModel domain)
        {
            TbFdTareaTipo tp = new TbFdTareaTipo();
            tp.Activo = domain.Activo;
            tp.Color = domain.Color;
            tp.ControlaFechaLimite = domain.ControlaFechaLimite;
            tp.DiasFechaLimite = domain.DiasFechaLimite;
            tp.EsTipoDefecto = domain.EsTipoDefecto;
            tp.Titulo = domain.Titulo;
            tp.FechaCreacion = DateTime.Now;

            return tp;
        }

        public TbFdTareaTipo viewToModelUpdate(TipoTareaViewModel domain)
        {


            TbFdTareaTipo tp = new TbFdTareaTipo();
            tp = this.ITipoTareaService.GetById(Convert.ToInt32(domain.Id));
            tp.Activo = domain.Activo;
            tp.Color = domain.Color;
            tp.ControlaFechaLimite = domain.ControlaFechaLimite;
            tp.DiasFechaLimite = domain.DiasFechaLimite;
            tp.EsTipoDefecto = domain.EsTipoDefecto;
            tp.Titulo = domain.Titulo;
            

            return tp;
        }
    }
}
