using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IPreciosMap
    {
        TbPrPrecios Create(PreciosViewModel viewModel);
        TbPrPrecios Update(PreciosViewModel viewModel);
        TbPrPrecios ViewModelToDomain(PreciosViewModel viewModel);
        TbPrPrecios ViewModelToDomainEditar(PreciosViewModel viewModel);
        PreciosViewModel DomainToVIewModel(TbPrPrecios domain);
    }
}
