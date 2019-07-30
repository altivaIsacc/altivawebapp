using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class DescuentoPromocionMap : IDescuentoPromocionMap
    {
        readonly IDescuentoPromocionService service;


        public DescuentoPromocionMap(IDescuentoPromocionService service)
        {
            this.service = service;
        }

        public TbFaRebajaConfig UpdateConfig(RebajaConfigViewModel viewModel)
        {
            return service.Update(ViewModelToDomainCrearConfig(viewModel));
        }

        public void CreateConfig()
        {
            service.SaveConfig(CrearConfigModel());
        }


        public TbFaRebajaConfig ViewModelToDomainCrearConfig(RebajaConfigViewModel viewModel)
        {
            return new TbFaRebajaConfig
            {
                IdRebajaConfig = viewModel.IdRebajaConfig,
                ActivaMaxGeneral = viewModel.ActivaMaxGeneral,
                PorcMaxGeneral = viewModel.PorcMaxGeneral,
                ActivaMaxUsuario = viewModel.ActivaMaxUsuario,
                ActivaMaxUsuarioRango = viewModel.ActivaMaxUsuarioRango,
                ActivaMaxUsuarioClave = viewModel.ActivaMaxUsuarioClave,
                ActivaPromoProducto = viewModel.ActivaPromoProducto,
                ActivaPromoProductoUsuario = viewModel.ActivaPromoProductoUsuario,
                ActivaDescuentoPromoUsuario = viewModel.ActivaDescuentoPromoUsuario,
                ActivaDescuentoPromoUsuarioClave = viewModel.ActivaDescuentoPromoUsuarioClave

            };
        }

        public TbFaRebajaConfig CrearConfigModel()
        {
            return new TbFaRebajaConfig
            {
                ActivaMaxGeneral = false,
                PorcMaxGeneral = 0,
                ActivaMaxUsuario = false,
                ActivaMaxUsuarioRango = false,
                ActivaMaxUsuarioClave = false,
                ActivaPromoProducto = false,
                ActivaPromoProductoUsuario = false,
                ActivaDescuentoPromoUsuario = false,
                ActivaDescuentoPromoUsuarioClave = false

            };
        }

        public RebajaConfigViewModel DomainToViewModel(TbFaRebajaConfig domain)
        {
            return new RebajaConfigViewModel
            {
                IdRebajaConfig = domain.IdRebajaConfig,
                ActivaMaxGeneral = domain.ActivaMaxGeneral,
                PorcMaxGeneral = domain.PorcMaxGeneral,
                ActivaMaxUsuario = domain.ActivaMaxUsuario,
                ActivaMaxUsuarioRango = domain.ActivaMaxUsuarioRango,
                ActivaMaxUsuarioClave = domain.ActivaMaxUsuarioClave,
                ActivaPromoProducto = domain.ActivaPromoProducto,
                ActivaPromoProductoUsuario = domain.ActivaPromoProductoUsuario,
                ActivaDescuentoPromoUsuario = domain.ActivaDescuentoPromoUsuario,
                ActivaDescuentoPromoUsuarioClave = domain.ActivaDescuentoPromoUsuarioClave

            };
        }
    }
}
