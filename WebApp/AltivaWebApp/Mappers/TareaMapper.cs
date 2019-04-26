using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Mappers
{
    public class TareaMapper : ITareaMapper
    {

        //variable al service de tareas
        public ITareaService ItareaService;
        //variables de estados y tipos para calculos 
        public ITipoTareaService ITipoTareaService;
        public IEstadoTareaService IEstadoTareaService;

        //contructor
        public TareaMapper(ITareaService ItareaService, ITipoTareaService ITipoTareaService, IEstadoTareaService IEstadoTareaService)
        {
            this.ItareaService = ItareaService;
            this.ITipoTareaService = ITipoTareaService;
            this.IEstadoTareaService = IEstadoTareaService;
        }

        public TbFdTarea Save(TareaViewModel domain)
        {
            return this.ItareaService.Save(viewToModelSave(domain));
        }

        public TbFdTarea Update(TareaViewModel domain)
        {
            return this.ItareaService.Update(viewToModelUpdate(domain));
        }

        public TbFdTarea viewToModelSave(TareaViewModel domain)
        {
            TbFdTarea tbTarea = new TbFdTarea();
            tbTarea.Titulo = domain.Titulo;
            tbTarea.IdContacto = domain.IdContacto;
            tbTarea.IdUsuario = domain.IdUsuario;
            tbTarea.FechaCreacion = DateTime.Now;
            tbTarea.FechaLimite = domain.FechaLimite;
            tbTarea.DiasEstimados = domain.DiasEstimados;
            tbTarea.CostoEstimado = domain.CostoEstimado;
            tbTarea.Cobrado = domain.Cobrado;
            tbTarea.MontoCobrad = domain.MontoCobrad;
            tbTarea.IdEstado = domain.IdEstado;
            tbTarea.IdTipo = domain.IdTipo;
            return tbTarea;
        }

        public TbFdTarea viewToModelUpdate(TareaViewModel domain)
        {
            TbFdTarea tbTarea = new TbFdTarea();

            return tbTarea;
        }
    }
}
