using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class RequisicionMap: IRequisicionMap
    {
        private readonly IRequisicionService service;
        public RequisicionMap(IRequisicionService service)
        {
            this.service = service;
        }

        public TbPrRequisicion Create(RequisicionViewModel viewModel)
        {
            return service.Save(ViewModelToDomain(viewModel));
        }

        public TbPrRequisicion Update(RequisicionViewModel viewModel)
        {
            return service.Update(ViewModelToDomainEdit(viewModel));
        }

        public void SaveRD(RequisicionViewModel viewModel)
        {
            service.SaveRD(ViewModelToDomaineRD(viewModel.RequisicionDetalle));
        }

        public void UpdateRD(IList<RequisicionDetalleViewModel> viewModel)
        {
            service.UpdateRD(ViewModelToDomaineRD(viewModel));
        }

        public TbPrRequisicion ViewModelToDomain(RequisicionViewModel viewModel)
        {
            return new TbPrRequisicion
            {
                Id = viewModel.Id,
                Anulado = false,
                Descripcion = viewModel.Descripcion,
                Fecha = DateTime.Now,
                FechaCreacion = DateTime.Now,
                IdDepartamento = viewModel.IdDepartamento,
                IdUsuario = viewModel.IdUsuario,
                Total = viewModel.Total,
                TbPrRequisicionDetalle = ViewModelToDomaineRD(viewModel.RequisicionDetalle)
            };
        }

        public TbPrRequisicion ViewModelToDomainEdit(RequisicionViewModel viewModel)
        {
            var req = service.GetReqById((int)viewModel.Id);

            req.Anulado = viewModel.Anulado;
            req.Descripcion = viewModel.Descripcion;
            req.Fecha = viewModel.Fecha;
            req.Total = viewModel.Total;

            return req;
            
        }



        public IList<TbPrRequisicionDetalle> ViewModelToDomaineRD(IList<RequisicionDetalleViewModel> viewModel)
        {
            var rd = new List<TbPrRequisicionDetalle>();
            foreach (var item in viewModel)
            {
                rd.Add(ViewModelToDomaineRDSingle(item));
            }

            return rd;
        }

        public TbPrRequisicionDetalle ViewModelToDomaineRDSingle(RequisicionDetalleViewModel viewModel)
        {
            return new TbPrRequisicionDetalle
            {
                Cantidad = viewModel.Cantidad,
                Id = viewModel.Id,
                IdInventario = viewModel.IdInventario,
                IdRequisicion = viewModel.IdRequisicion,
                PrecioUnitario = viewModel.PrecioUnitario,
                Total = viewModel.Total
            };
        }

        public RequisicionViewModel DomainToViewModel(TbPrRequisicion domain)
        {
            return new RequisicionViewModel
            {
                Id = domain.Id,
                Anulado = domain.Anulado,
                Descripcion = domain.Descripcion,
                Fecha = domain.Fecha,
                IdDepartamento = domain.IdDepartamento,
                Total = domain.Total,
                IdUsuario = domain.IdUsuario
            };
        }



    }
}
