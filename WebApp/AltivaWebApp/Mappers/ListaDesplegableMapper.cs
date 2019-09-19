using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Services;
namespace AltivaWebApp.Mappers
{
    public class ListaDesplegableMapper : IListaDesplegableMapper
    {
        public ICamposPersonalizadosService camposService;
        public IListaDesplegableService IListaService;
        public ListaDesplegableMapper(ICamposPersonalizadosService camposService, IListaDesplegableService IListaService)
        {
            this.camposService = camposService;
            this.IListaService = IListaService;
        }
        public TbCrCamposPersonalizados Save(CamposPersonalizadosViewModel domain)
        {
            return this.camposService.Save(viewModelCampos(domain));
        }

        public void SaveOrUpdate(IList<ListaViewModel> viewModel)
        {
            IList<ListaViewModel> create = new List<ListaViewModel>();
            IList<ListaViewModel> update = new List<ListaViewModel>();

            foreach (var item in viewModel)
            {
                if (item.Id != 0)
                    update.Add(item);
                else
                    create.Add(item);
            }

            SaveRange(create);
            UpdateRange(update);
        }

        public void SaveRange(IList<ListaViewModel> domain)
        {
            this.IListaService.SaveRange(viewModelCamposLista(domain));
        }

        public void UpdateRange(IList<ListaViewModel> domain)
        {
            this.IListaService.UpdateRange(ViewToModelUpdateRange(domain));
        }

        public TbCrCamposPersonalizados viewModelCampos(CamposPersonalizadosViewModel domain)
        {
            TbCrCamposPersonalizados tp = new TbCrCamposPersonalizados();
            tp.Nombre = domain.Nombre;
            tp.Tipo = domain.Tipo;
            tp.Estado = domain.Estado;

            return tp;
        }

        public IList<TbCrListaDesplegables> viewModelCamposLista(IList<ListaViewModel> domain)
        {
            IList<TbCrListaDesplegables> a = new List<TbCrListaDesplegables>();
    
            foreach (var item in domain)
            {
                TbCrListaDesplegables lista = new TbCrListaDesplegables();
                lista.IdCamposPersonalizados = item.IdCamposPersonalizados;
                lista.Valor = item.Valor;
                a.Add(lista);
            }
            return a;
        }

        public IList<TbCrListaDesplegables> ViewToModelUpdateRange(IList<ListaViewModel> domain)
        {


            IList<TbCrListaDesplegables> ListaDesplegable = new List<TbCrListaDesplegables>();

            foreach (var item in domain)
            {
                ListaDesplegable.Add(new TbCrListaDesplegables {
                    Id = item.Id,
                    IdCamposPersonalizados = item.IdCamposPersonalizados,
                    Valor = item.Valor
                });
                
            }



            return ListaDesplegable;
        }
    }
}
