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
       
        TbCrContacto CreateContacto(ContactoViewModel domain);
        TbCrContacto ViewModelToDomainC(ContactoViewModel domain);
        TbCrContacto UpdateContacto(ContactoViewModel domain);
        TbCrContacto UpdateImagen(int id , string ruta);
        TbCrContactoRelacion CreateRelacion(ContactoRelacionViewModel domain);
        TbCrContactoRelacion UpdateRelacion(ContactoRelacionViewModel domain);
        TbCrContactoRelacion ViewModelToDomainCR(ContactoRelacionViewModel domain);
        TbCrCamposPersonalizados EliminarCP(int id);
        TbCrCamposPersonalizados UpdateCP(CamposPersonalizadosViewModel domain);
        TbCrCamposPersonalizados ViewModelToDomainCP(CamposPersonalizadosViewModel domain);
        ContactoViewModel DomainToViewModelC(TbCrContacto domain);
        ContactoRelacionViewModel DomainToViewModelCR(TbCrContactoRelacion domain);
        CuentaBancariaViewModel DomainToViewModelCB(TbFdCuentasBancarias domain);
        TbFdCuentasBancarias CreateCuentaBancaria(CuentaBancariaViewModel viewModel);
        TbFdCuentasBancarias UpdateCuentaBancaria(CuentaBancariaViewModel viewModel);
    }
}
