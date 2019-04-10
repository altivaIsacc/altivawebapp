using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IUnidadMap
    {
        TbPrUnidadMedida Create(UnidadViewModel viewModel);
        TbPrUnidadMedida Update(int id, UnidadViewModel viewModel);
        TbPrUnidadMedida ViewModelToDomainNuevo(UnidadViewModel viewModel);
        TbPrUnidadMedida ViewModelToDomainEditar(int id, UnidadViewModel viewModel);
        UnidadViewModel DomainToViewModel(TbPrUnidadMedida domain);
    }
}
