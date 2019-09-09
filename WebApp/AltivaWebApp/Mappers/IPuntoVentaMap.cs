using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IPuntoVentaMap
    {
         TbSePuntoVenta Create(PuntoVentaViewModel viewModel);
       

        TbSePuntoVenta Update(PuntoVentaViewModel viewModel);
       

        TbSePuntoVenta ViewModelToDomain(PuntoVentaViewModel viewModel);
       
        TbSePuntoVenta ViewModelToDomainEditar(PuntoVentaViewModel viewModel);
     
        PuntoVentaViewModel DomainToVIewModel(TbSePuntoVenta domain);
       
    }
}
