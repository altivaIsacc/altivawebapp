using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Mappers
{
   public interface IContactoMap
    {

        TbCrContacto NuevoContacto(ContactoViewModel domain);
        TbCrContacto viewToModelContacto(ContactoViewModel domain);
        TbCrContacto EditarContacto(ContactoViewModel domain);
        TbCrContacto viewToModelContactoEditar(ContactoViewModel domain);
        TbCrContacto ingresarImagen(int id , string ruta);
        TbCrContactoRelacion InsertarRelacion(ContactoRelacionViewModel domain);
        TbCrContactoRelacion viewToModelContactoRelacion(ContactoRelacionViewModel domain);
        TbCrCamposPersonalizados Delete(int id);
        TbCrCamposPersonalizados Edit(CamposPersonalizadosViewModelSingle domain);
        TbCrCamposPersonalizados viewModelCamposEdit(CamposPersonalizadosViewModelSingle domain);
    }
}
