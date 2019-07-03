using AltivaWebApp.Domains;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Mappers
{
   public interface ICajaMap
    {
        TbFaCaja Create(CajaViewModel viewModel);
        TbFaCaja Update(CajaViewModel viewModel);
        TbFaCajaAperturaDenominacion CreateCD(CajaViewModel viewModel);
        CajaViewModel DomainToViewModel(TbFaCaja domain);
        bool UpdateCD(CajaViewModel viewModel);
        bool UpdateAr(CajaViewModel viewModel);

    }
}
