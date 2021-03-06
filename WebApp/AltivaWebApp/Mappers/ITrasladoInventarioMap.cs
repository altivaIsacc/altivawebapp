﻿using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface ITrasladoInventarioMap
    {

        TbPrTrasladoInventario Create(TrasladoInventarioViewModel viewModel);
     
        TbPrTrasladoInventario ViewModelToDomain(TrasladoInventarioViewModel viewModel);
     
        TrasladoInventarioViewModel DomainToVIewModel(TbPrTrasladoInventario domain);

    }
}
