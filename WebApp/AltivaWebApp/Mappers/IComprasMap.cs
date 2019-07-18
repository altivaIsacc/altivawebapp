using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    interface IComprasMap
    {
        TbCpCompras Create(ComprasViewModel viewModel);
        TbCpCompras Update(ComprasViewModel viewModel);
        TbCpCompras ViewModelToDomain(ComprasViewModel viewModel);
        ComprasViewModel DomainToViewModel(TbCpCompras domain);
    }
}
