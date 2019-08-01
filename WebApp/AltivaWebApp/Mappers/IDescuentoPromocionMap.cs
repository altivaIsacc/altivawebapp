using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IDescuentoPromocionMap
    {

        TbFaRebajaConfig ViewModelToDomainCrearConfig(RebajaConfigViewModel viewModel);
        RebajaConfigViewModel DomainToViewModel(TbFaRebajaConfig domain);
        void CreateConfig();
        TbFaRebajaConfig CrearConfigModel();
        TbFaRebajaConfig UpdateConfig(RebajaConfigViewModel viewModel);
    }
}
