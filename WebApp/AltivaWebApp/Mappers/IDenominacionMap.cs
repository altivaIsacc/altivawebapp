using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Mappers
{
   public interface IDenominacionMap
    {
        TbFaDenominacion Create(DenominacionesViewModel viewModel);
        TbFaDenominacion Update(DenominacionesViewModel viewModel);
        DenominacionesViewModel DomainToViewModel(TbFaDenominacion domain);

    }
}
