using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IModuloMap
    {
        TbSeModulo Update(ModuloViewModel model);
        TbSeModulo ViewModelToDomain(ModuloViewModel officeViewModel);
        ModuloViewModel DomainToViewModelSingle(TbSeModulo domain);
    }
}
