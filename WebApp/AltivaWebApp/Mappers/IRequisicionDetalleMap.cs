using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IRequisicionDetalleMap
    {     
        TbPrRequisicionDetalle ViewModelToDomain(RequisicionDetalleViewModel viewModel);

    }




}
