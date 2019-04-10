using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Mappers
{
  public  interface IcontactoCamposMap
    {
       void Agregar(IList<CamposViewModel> domain, long? id);
        void Update(IList<CamposViewModel> domain,long? id);
       TbCrContactosCamposPersonalizados viewToModelContacto(CamposViewModel domain,long? id);
        TbCrContactosCamposPersonalizados viewToModelContactoEdit(CamposViewModel domain, long? id);

    }
}
