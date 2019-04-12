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
        TbCrCamposPersonalizados Save(CamposPersonalizadosViewModelSingle domain);
        TbCrCamposPersonalizados viewModelCampos(CamposPersonalizadosViewModelSingle domain);
  
        void SaveRange(IList<ListaViewModel> domain);
        IList<TbCrListaDesplegables> viewModelCamposLista(IList<ListaViewModel> domain);


    }
}
