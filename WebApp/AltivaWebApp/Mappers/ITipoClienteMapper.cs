﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Mappers
{
    public interface ITipoClienteMapper
    {
        TbFdTipoCliente Save(TipoClienteViewModel domain);
        TbFdTipoCliente ViewModelToDomain(TipoClienteViewModel domain);
        TbFdTipoCliente Update(TipoClienteViewModel domain);
        TipoClienteViewModel DomainToViewModel(TbFdTipoCliente domain);
    }
}
