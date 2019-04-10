using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IConversionMap
    {
        TbPrConversion Create(ConversionViewModel viewModel);
        TbPrConversion ViewModelToDomainNuevo(ConversionViewModel viewModel);
    }
}
