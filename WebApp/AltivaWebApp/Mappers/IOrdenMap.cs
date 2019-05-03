using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IOrdenMap
    {
        TbPrOrden Create(OrdenViewModel viewModel);
        TbPrOrden Update(OrdenViewModel viewModel);
        bool CreateOD(OrdenViewModel viewModel);
        OrdenViewModel DomainToViewModel(TbPrOrden domain);
    }
}
