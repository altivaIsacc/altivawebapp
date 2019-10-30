using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IPagoMap
    {
        TbFaPago Create(DocumentoViewModel viewModel);
        TbFaPago Update(DocumentoViewModel viewModel);
        TbFaPago ViewModelToDomain(DocumentoViewModel viewModel);
        DocumentoViewModel DomainToViewModel(TbFaPago domain);
    }
}
