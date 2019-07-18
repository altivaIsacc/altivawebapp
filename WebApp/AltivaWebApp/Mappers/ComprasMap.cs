using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class ComprasMap: IComprasMap
    {
        private readonly IComprasService service;

        public ComprasMap(IComprasService service)
        {
            this.service = service;
        }
        public TbCpCompras Create(ComprasViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public ComprasViewModel DomainToViewModel(TbCpCompras domain)
        {
            throw new NotImplementedException();
        }

        public TbCpCompras Update(ComprasViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public TbCpCompras ViewModelToDomain(ComprasViewModel viewModel)
        {
            return new TbCpCompras
            {
                IdCompra = viewModel.IdCompra,
                FechaDocumento = viewModel.FechaDocumento,
                TipoDocumento = viewModel.TipoDocumento,
                NumeroDocumento = viewModel.NumeroDocumento,
                IdProveedor = viewModel.IdProveedor,
                FechaCreacion = viewModel.FechaCreacion,
                IdUsuario = viewModel.IdUsuario,
          IdMoneda = viewModel.IdMoneda,
          SubTotalGravadoBase = viewModel.SubTotalGravadoBase,
          SubTotalGravadoDolar = viewModel.SubTotalGravadoDolar,
          SubTotalGravadoEuro = viewModel.SubTotalGravadoEuro,
          SubTotalExcentoBase = viewModel.SubTotalExcentoBase,
          SubTotalExcentoDolar = viewModel.SubTotalExcentoDolar,
         /* SubTotalExcentoEuro 
          SubTotalGravadoNetoBase 
          SubTotalGravadoNetoDolar 
          SubTotalGravadoNetoEuro 
          SubTotalExcentoNetoBase 
          SubTotalExcentoNetoDolar 
          SubTotalExcentoNetoEuro 
          TotalDescuentoBase 
          TotalDescuentoDolar 
          TotalDescuentoEuro 
          TotalIvabase 
          TotalIvadolar 
          TotalIvaeuro 
          TotalBase 
          TotalDolar 
          TotalEuro 
          TotalFabase 
          TotalFadolar 
          TotalFaeuro 
          Anulado 
          Borrador*/

    };
        }
    }
}
