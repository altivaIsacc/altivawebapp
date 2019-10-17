using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IRequisicionMap
    {
        TbPrRequisicion Create(RequisicionViewModel viewModel);
        TbPrRequisicion Update(RequisicionViewModel viewModel);
        RequisicionViewModel DomainToViewModel(TbPrRequisicion domain);
        IList<TbPrRequisicionDetalle> ViewModelToDomaineRD(IList<RequisicionDetalleViewModel> viewModel);
        IList<TbPrRequisicionDetalle> SaveOrUpdateRD(IList<RequisicionDetalleViewModel> viewModel);


        TbPrRequisicion ViewModelToDomainTransaccion(RequisicionViewModel viewModel);

    }
}
