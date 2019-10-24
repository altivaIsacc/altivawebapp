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
            return service.Update(ViewModelToDomain(viewModel));
        }

        public IList<TbPrRequisicionDetalle> SaveOrUpdateRD(IList<RequisicionDetalleViewModel> viewModel)
        {
            return service.SaveOrUpdateRD(ViewModelToDomaineRD(viewModel));

        }

        public TbPrRequisicion ViewModelToDomain(RequisicionViewModel viewModel)
        {
            return new TbPrRequisicion
            {
                Id = viewModel.Id,
                Anulado = viewModel.Anulado,
                Descripcion = viewModel.Descripcion,
                Fecha = viewModel.Fecha,
                FechaCreacion = DateTime.Now,
                IdDepartamento = viewModel.IdDepartamento,
                IdBodega = viewModel.IdBodega,
                IdUsuario = viewModel.IdUsuario,
                Total = viewModel.Total,
                TbPrRequisicionDetalle = viewModel.RequisicionDetalle != null ? ViewModelToDomaineRD(viewModel.RequisicionDetalle) : null
            };
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
                IdUsuario = domain.IdUsuario,
                IdBodega = (int)domain.IdBodega
            };
        }

        public TbPrRequisicion ViewModelToDomainTransaccion(RequisicionViewModel viewModel)
        {

            var domain = new TbPrRequisicion
            {
                Id = viewModel.Id,
                Fecha = viewModel.Fecha,
                FechaCreacion = DateTime.Now,
                IdDepartamento = viewModel.IdDepartamento,
                Anulado = viewModel.Anulado,
                IdUsuario = viewModel.IdUsuario,
                Descripcion = viewModel.Descripcion,
                Total = viewModel.Total,
                IdBodega = viewModel.IdBodega
              
            };
            return domain;

        }




    }
}
