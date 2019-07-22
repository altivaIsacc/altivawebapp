using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IFacturaMap
    {
        TbFdFactura Create(FacturaViewModel viewModel);
        TbFdFactura Update(FacturaViewModel viewModel);
        IList<TbFdFacturaDetalle> CreateFD(FacturaViewModel viewModel);
        IList<TbFdFacturaDetalle> UpdateFD(FacturaViewModel viewModel);
        IList<TbFdFacturaDetalle> CreateOrUpdateFD(FacturaViewModel viewModel);
        TbFdFactura ViewModelToDomain(FacturaViewModel viewModel);
    }
}
