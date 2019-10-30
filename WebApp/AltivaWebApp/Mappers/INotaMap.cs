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
        TbFaNota Create(DocumentoViewModel viewModel);
        TbFaNota Update(DocumentoViewModel viewModel);
        TbFaNota ViewModelToDomain(DocumentoViewModel viewModel);
        TbFaNota ViewModelToDomainEditar(DocumentoViewModel viewModel);
        DocumentoViewModel DomainToVIewModel(TbFaNota domain);
    }
}
