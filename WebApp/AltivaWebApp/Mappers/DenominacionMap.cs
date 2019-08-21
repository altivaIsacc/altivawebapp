using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AltivaWebApp.Mappers
{
    public class DenominacionMap:IDenominacionMap
    {
        private readonly IDenominacionesService  _Service;

        public DenominacionMap(IDenominacionesService service)
        {
            _Service = service;

        }
        public DenominacionesViewModel DomainToViewModel(DenominacionesViewModel domain)
        {
            var viewModel = new DenominacionesViewModel
            {
                IdDenominaciones = domain.IdDenominaciones,
                FechaCreacion = domain.FechaCreacion,
                IdUsuario = domain.IdUsuario,
                Estado = domain.Estado,
                IdMoneda = domain.IdMoneda,
                Valor = domain.Valor,
                Tipo = domain.Tipo,

            };

            return viewModel;
        }

        public DenominacionesViewModel DomainToViewModel(TbFaDenominacion domain)
        {
            var viewModel = new DenominacionesViewModel
            {
                IdDenominaciones = domain.IdDenominaciones,
                FechaCreacion = domain.FechaCreacion,
                IdUsuario = domain.IdUsuario,
                Estado = domain.Estado,
                IdMoneda = domain.IdMoneda,
                Valor = domain.Valor,
                Tipo=domain.Tipo,

            };


            return viewModel;
        }

        public TbFaDenominacion Create(DenominacionesViewModel viewModel)
        {
            try
            {
                var Denominacion = _Service.Save(ViewModelToDomain(viewModel));           
                return Denominacion;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }

        public TbFaDenominacion Update(DenominacionesViewModel viewModel)
        {
            return _Service.Update(ViewModelToDomainEdit(viewModel));
        }

        public TbFaDenominacion ViewModelToDomain(DenominacionesViewModel viewModel)
        {
            var domain = new TbFaDenominacion { };
            try
            {
                domain = new TbFaDenominacion
                {
                 
                 
                    IdUsuario = viewModel.IdUsuario,
                    Estado = viewModel.Estado,
                    IdMoneda = viewModel.IdMoneda,
                    Valor = viewModel.Valor,
                    Tipo = viewModel.Tipo,

                };

                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                var msj = ex.Message;
                return domain;
            }


        }

        public TbFaDenominacion ViewModelToDomainEdit(DenominacionesViewModel viewModel)
        {

            var domain = _Service.GetDenominacionesById((int)viewModel.IdDenominaciones);

            domain.IdDenominaciones = viewModel.IdDenominaciones;
            domain.IdUsuario = viewModel.IdUsuario;
            domain.Estado = viewModel.Estado;
            domain.IdMoneda = viewModel.IdMoneda;
            domain.Valor = viewModel.Valor;
            domain.Tipo = viewModel.Tipo;

            return domain;

        }
    }
}
