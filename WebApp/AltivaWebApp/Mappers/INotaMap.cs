using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface INotaMap
    {
        TbFaNota Create(NotaViewModel viewModel);
        TbFaNota Update(NotaViewModel viewModel);
        TbFaNota ViewModelToDomain(NotaViewModel viewModel);
        TbFaNota ViewModelToDomainEditar(NotaViewModel viewModel);
        NotaViewModel DomainToVIewModel(TbFaNota domain);
    }
}
