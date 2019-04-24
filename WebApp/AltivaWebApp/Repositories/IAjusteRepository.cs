﻿using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IAjusteRepository
    {
        TbPrAjuste Save(TbPrAjuste domain);
        TbPrAjuste Update(TbPrAjuste domain);
        bool Delete(TbPrAjuste domain);
        IList<TbPrAjuste> GetAll();
        TbPrAjuste GetAjusteById(int id);
        TbPrAjusteInventario SaveAjusteInventario(TbPrAjusteInventario domain);
        void DeleteAjusteInventario(int id);
    }
}
