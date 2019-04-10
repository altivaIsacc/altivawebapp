using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IGEMap
    {
        TbGeEmpresa Create(EmpresaViewModel model);
        TbGeEmpresa Update(EmpresaViewModel model);
        TbGeEmpresa ViewModelToDomainCrear(EmpresaViewModel model);
        EmpresaViewModel DomainToViewModel(TbGeEmpresa domain);
    }
}
