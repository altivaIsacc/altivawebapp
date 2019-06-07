using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IFamiliaOnlineMap
    {
        TbPrFamiliaVentaOnline Create(FamiliaViewModel viewmodel);
        TbPrFamiliaVentaOnline Update(int id, FamiliaViewModel viewmodel);
        TbPrFamiliaVentaOnline ViewModelToDomainNuevo(FamiliaViewModel viewmodel);
        TbPrFamiliaVentaOnline ViewModelToDomainEditar(int id, FamiliaViewModel viewmodel);
        FamiliaViewModel DomainToViewmodel(TbPrFamiliaVentaOnline domain);
    }
}
