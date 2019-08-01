using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Mappers
{
    public interface IListaDesplegableMapper
    {
        TbCrCamposPersonalizados Save(CamposPersonalizadosViewModel domain);
        TbCrCamposPersonalizados viewModelCampos(CamposPersonalizadosViewModel domain);
  
        void SaveRange(IList<ListaViewModel> domain);
        IList<TbCrListaDesplegables> viewModelCamposLista(IList<ListaViewModel> domain);
        void UpdateRange(IList<ListaViewModel> domain);
        IList<TbCrListaDesplegables> ViewToModelUpdateRange(IList<ListaViewModel> domain);

    }
}
