using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class FamiliaOnlineMap : IFamiliaOnlineMap
    {
        readonly IFamiliaOnlineService service;
        public FamiliaOnlineMap(IFamiliaOnlineService service)
        {
            this.service = service;
        }
        public TbPrFamiliaVentaOnline Create(FamiliaViewModel viewmodel)
        {
            return service.Save(ViewModelToDomainNuevo(viewmodel));
        }
        public TbPrFamiliaVentaOnline Update(int id, FamiliaViewModel viewmodel)
        {
            return service.Update(ViewModelToDomainEditar(id, viewmodel));
        }
        public TbPrFamiliaVentaOnline ViewModelToDomainNuevo(FamiliaViewModel viewmodel)
        {
            return new TbPrFamiliaVentaOnline
            {
                Descripcion = viewmodel.Descripcion,
                FechaCreacion = DateTime.Now,
                IdFamilia = viewmodel.IdFamilia,
                IdUsuario = viewmodel.IdUsuario

            };
        }
        public TbPrFamiliaVentaOnline ViewModelToDomainEditar(int id, FamiliaViewModel viewmodel)
        {
            var familia = service.GetFamiliaById(id);

            familia.Descripcion = viewmodel.Descripcion;
            //familia.IdFamilia = viewmodel.IdFamilia;

            if (familia.IdFamilia == null && viewmodel.IdFamilia != null)
            {
                if (familia.InverseIdFamiliaNavigation.Count != 0)
                {
                    foreach (var item in familia.InverseIdFamiliaNavigation)
                    {
                        item.IdFamilia = (int?)viewmodel.IdFamilia;
                    }

                    service.UpdateSubFamilia(familia.InverseIdFamiliaNavigation.ToList());
                }
            }

            familia.IdFamilia = viewmodel.IdFamilia;


            return familia;

        }
        public FamiliaViewModel DomainToViewmodel(TbPrFamiliaVentaOnline domain)
        {
            return new FamiliaViewModel
            {
                Descripcion = domain.Descripcion,
                IdFamilia = (int?)domain.IdFamilia,
                FechaCreacion = domain.FechaCreacion,
                IdUsuario = (int)domain.IdUsuario,
                Id = (int)domain.Id
            };
        }
    }
}
