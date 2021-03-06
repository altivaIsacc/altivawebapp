﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
    public class ConfiguracionFiltrosRepository : BaseRepository<TbFdConfiguracionFiltros>, IConfiguracionFiltrosRepository
    {
        public ConfiguracionFiltrosRepository(EmpresasContext context) : base(context)
        {
        }

        public void DeleteRange(IList<TbFdConfiguracionFiltros> domain)
        {
            context.TbFdConfiguracionFiltros.RemoveRange(domain);
            context.SaveChanges();
        }

        public TbFdConfiguracionFiltros GetFiltro()
        {
            return context.TbFdConfiguracionFiltros.FirstOrDefault();
        }
    }
}
