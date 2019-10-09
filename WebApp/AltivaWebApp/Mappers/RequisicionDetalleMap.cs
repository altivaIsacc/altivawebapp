using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Mappers
{
    public class RequisicionDetalleMap : IRequisicionDetalleMap
    {


        public TbPrRequisicionDetalle ViewModelToDomain(RequisicionDetalleViewModel viewModel)
        {
            return new TbPrRequisicionDetalle
            {
                IdRequisicion = viewModel.IdRequisicion,
                IdInventario = viewModel.IdInventario,
                Cantidad = viewModel.Cantidad,
                PrecioUnitario = viewModel.PrecioUnitario,
                Total = viewModel.Total,

            };

        }




    }
}
