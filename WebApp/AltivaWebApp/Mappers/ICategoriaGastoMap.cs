using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface ICategoriaGastoMap
    {
        TbCpCategoriaGasto Create(CategoriaGastoVIewModel viewModel);
        TbCpCategoriaGasto Update(CategoriaGastoVIewModel viewModel);
        TbCpCategoriaGasto ViewModelToDomain(CategoriaGastoVIewModel viewModel);
        CategoriaGastoVIewModel DomainToViewModel(TbCpCategoriaGasto domain);
    }
}
