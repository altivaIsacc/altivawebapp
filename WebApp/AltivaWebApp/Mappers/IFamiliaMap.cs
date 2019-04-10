using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IFamiliaMap
    {
        TbPrFamilia Create(FamiliaViewModel viewmodel);
        TbPrFamilia Update(int id, FamiliaViewModel viewmodel);
        TbPrFamilia ViewModelToDomainNuevo(FamiliaViewModel viewmodel);
        TbPrFamilia ViewModelToDomainEditar(int id, FamiliaViewModel viewmodel);
        FamiliaViewModel DomainToViewmodel(TbPrFamilia domain);
    }
}
