using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class FamiliaMap: IFamiliaMap
    {
        readonly IFamiliaService service;
        public FamiliaMap(IFamiliaService service)
        {
            this.service = service;
        }
        public TbPrFamilia Create(FamiliaViewModel viewmodel)
        {
            return service.Save(ViewModelToDomainNuevo(viewmodel));
        }
        public TbPrFamilia Update(int id, FamiliaViewModel viewmodel)
        {
            return service.Update(ViewModelToDomainEditar(id, viewmodel));
        }
        public TbPrFamilia ViewModelToDomainNuevo(FamiliaViewModel viewmodel)
        {
            return new TbPrFamilia 
            {
               Descripcion = viewmodel.Descripcion,
               FechaCreacion = DateTime.Now,
               IdFamilia = viewmodel.IdFamilia,
               IdUsuario = viewmodel.IdUsuario
               
            };
        }
        public TbPrFamilia ViewModelToDomainEditar(int id, FamiliaViewModel viewmodel)
        {
            var familia = service.GetFamiliaById(id);

            familia.Descripcion = viewmodel.Descripcion;
            //familia.IdFamilia = viewmodel.IdFamilia;

            if (familia.IdFamilia == null && viewmodel.IdFamilia != null)
            {
                if(familia.InverseIdFamiliaNavigation.Count != 0)
                {
                    foreach (var item in familia.InverseIdFamiliaNavigation)
                    {
                        item.IdFamilia = (int?) viewmodel.IdFamilia;
                    }

                    service.UpdateSubFamilia(familia.InverseIdFamiliaNavigation.ToList());
                }
            }

            familia.IdFamilia = viewmodel.IdFamilia;


            return familia;

        }
        public FamiliaViewModel DomainToViewmodel(TbPrFamilia domain)
        {
            return new FamiliaViewModel
            {
                Descripcion = domain.Descripcion,
                IdFamilia = (int?) domain.IdFamilia,
                FechaCreacion = domain.FechaCreacion,
                IdUsuario =(int) domain.IdUsuario,
                Id =(int) domain.Id
            };
        }
    }
}
