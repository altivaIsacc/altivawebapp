using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
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
        public ICentroCostosService ICentroDeCostos;
        //contructor
        public TareaMapper(ICentroCostosService ICentroDeCostos,ITareaService ItareaService, ITipoTareaService ITipoTareaService, IEstadoTareaService IEstadoTareaService)
        {
            this.ItareaService = ItareaService;
            this.ITipoTareaService = ITipoTareaService;
            this.IEstadoTareaService = IEstadoTareaService;
           this.ICentroDeCostos = ICentroDeCostos;
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
            
            TbFdTareaEstado tTbFdTareaEstado = new TbFdTareaEstado();
            TbFdTareaTipo tbTipo = new TbFdTareaTipo();
            TbFdTarea tbTarea = new TbFdTarea();
            TbFdUsuarioCosto usuarioCosto = new TbFdUsuarioCosto();
            tbTarea.Titulo = domain.Titulo;
            tbTarea.IdContacto = domain.IdContacto;
            tbTarea.IdUsuario = domain.IdUsuario;

            if (domain.FechaLimite == null)
            {
                tbTipo = this.ITipoTareaService.GetById(Convert.ToInt32( domain.IdTipo));
                if (tbTipo.ControlaFechaLimite == true)
                {
                    if (tbTipo.DiasFechaLimite == 0) {
                        tbTarea.FechaLimite = DateTime.Now.AddDays(3);
                    } else {
                        tbTarea.FechaLimite = DateTime.Now.AddDays(tbTipo.DiasFechaLimite.Value);
                    }
                }
             
            }
            else
            {
                tbTarea.FechaLimite = domain.FechaLimite;
            }
            var usuariCostos = this.ICentroDeCostos.GetById(Convert.ToInt32(domain.IdUsuario));
            tbTarea.DiasEstimados = domain.DiasEstimados;

          
         
            tbTarea.Cobrado = domain.Cobrado;
            tbTarea.MontoCobrad = domain.MontoCobrad;
            tbTarea.IdEstado = domain.IdEstado;
            tbTarea.IdTipo = domain.IdTipo;
            tbTarea.Posicion = domain.Posicion;
            if (domain.Descripcion == null) {
                tbTarea.Descripcion = "";
            }
            else
            {
                tbTarea.Descripcion = domain.Descripcion;
            }
            tTbFdTareaEstado = this.IEstadoTareaService.GetById(Convert.ToInt32(domain.IdEstado));
            if (tTbFdTareaEstado.EsInicial == true)
            {
                tbTarea.FechaInicio = DateTime.Now;
            }
            else
            {
                tbTarea.FechaInicio = null;
            }
            if (tTbFdTareaEstado.EsFinal == true)
            {
                tbTarea.FechaFinal = DateTime.Now;
                TimeSpan difFechas = (tbTarea.FechaInicio.Value.Date - tbTarea.FechaFinal.Value.Date);
                int dias = difFechas.Days;
                tbTarea.DiasReales = dias;
            }
            else
            {

                tbTarea.FechaFinal = null;
            }
            if (domain.IdUsuario != null)
            {
                if (domain.CostoEstimado == 0)
                {

                    tbTarea.CostoEstimado = usuariCostos.Costo;
                }
                else
                {
                    tbTarea.CostoEstimado = (usuariCostos.Costo * domain.DiasEstimados);
                    tbTarea.CostoReal = (usuariCostos.Costo * tbTarea.DiasReales);
                }
            }
            return tbTarea;
        }

        public TbFdTarea viewToModelUpdate(TareaViewModel domain)
        {
            TbFdTareaEstado tTbFdTareaEstado = new TbFdTareaEstado();
            TbFdTareaTipo tbTipo = new TbFdTareaTipo();
            TbFdTarea tbTarea = new TbFdTarea();
            tbTarea = this.ItareaService.GetById(Convert.ToInt32(domain.Id));
            TbFdUsuarioCosto usuarioCosto = new TbFdUsuarioCosto();
            tbTarea.Titulo = domain.Titulo;
            tbTarea.IdContacto = domain.IdContacto;
            tbTarea.IdUsuario = domain.IdUsuario;
           
            if (domain.FechaLimite == null)
            {
                tbTipo = this.ITipoTareaService.GetById(Convert.ToInt32(domain.IdTipo));
                if (tbTipo.ControlaFechaLimite == true)
                {
                    if (tbTipo.DiasFechaLimite == 0)
                    {
                        tbTarea.FechaLimite = DateTime.Now.AddDays(3);
                    }
                    else
                    {
                        tbTarea.FechaLimite = DateTime.Now.AddDays(tbTipo.DiasFechaLimite.Value);
                    }
                }

            }
            else
            {
                tbTarea.FechaLimite = domain.FechaLimite;
            }
            var usuariCostos = this.ICentroDeCostos.GetById(Convert.ToInt32(domain.IdUsuario));
            tbTarea.DiasEstimados = domain.DiasEstimados;
            if (domain.IdUsuario != null) {
                if (domain.CostoEstimado == 0)
                {

                    tbTarea.CostoEstimado = usuariCostos.Costo;
                }
                else
                {
                    tbTarea.CostoEstimado = (usuariCostos.Costo * domain.DiasEstimados);
                }
            }
            else
            {
                tbTarea.CostoEstimado = 0;
            }
         
            tbTarea.Cobrado = domain.Cobrado;
            tbTarea.MontoCobrad = domain.MontoCobrad;
            tbTarea.IdEstado = domain.IdEstado;
            tbTarea.IdTipo = domain.IdTipo;
       
            if (domain.Descripcion == null)
            {
                tbTarea.Descripcion = "";
            }
            else
            {
                tbTarea.Descripcion = domain.Descripcion;
            }
            tTbFdTareaEstado = this.IEstadoTareaService.GetById(Convert.ToInt32(domain.IdEstado));
            if (tTbFdTareaEstado.EsInicial == true)
            {
                tbTarea.FechaInicio = DateTime.Now;
            }
       else
            if (tTbFdTareaEstado.EsFinal == true)
            {
                tbTarea.FechaFinal = DateTime.Now;
                if (tbTarea.FechaInicio.ToString() != "") {
                    var a = tbTarea.FechaFinal - tbTarea.FechaInicio;
                    TimeSpan difFechas = ( tbTarea.FechaFinal.Value.Date - tbTarea.FechaInicio.Value.Date );
                    int dias = difFechas.Days;
                    tbTarea.DiasReales = dias;
                }
                else
                {
                    tbTarea.DiasReales = 0;
                }
                if (domain.IdUsuario != null) {
                    tbTarea.CostoReal = (usuariCostos.Costo * tbTarea.DiasReales);
                   
                }
            }
            else
            {

                tbTarea.FechaFinal = null;
            }
            return tbTarea;
        }
    }
}
