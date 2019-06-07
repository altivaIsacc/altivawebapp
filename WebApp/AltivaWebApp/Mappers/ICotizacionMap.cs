using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Mappers
{
  public  interface ICotizacionMap
    {
        TbFaCotizacion Create(CotizacionViewModel viewModel);
        TbFaCotizacion Update(CotizacionViewModel viewModel);
        TbFaCotizacionDetalle CreateCD(CotizacionViewModel viewModel);
        CotizacionViewModel DomainToViewModel(TbFaCotizacion domain);
        bool UpdateCD(CotizacionViewModel viewModel);

    }
}
