using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IDepartamentoMap
    {
        TbPrDepartamento Create(DepartamentoViewModel viewModel);
        TbPrDepartamento Update(DepartamentoViewModel viewModel);
        TbPrDepartamento ViewModelToDomain(DepartamentoViewModel viewModel);
        TbPrDepartamento ViewModelToDomainEditar(DepartamentoViewModel viewModel);
        DepartamentoViewModel DomainToVIewModel(TbPrDepartamento domain);
    }
}
