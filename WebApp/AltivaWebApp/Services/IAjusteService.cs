﻿using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IAjusteService
    {
        TbPrAjuste Save(TbPrAjuste domain);
        TbPrAjuste Update(TbPrAjuste domain);
        bool Delete(TbPrAjuste domain);
        IList<TbPrAjuste> GetAllAjustes();
        TbPrAjuste GetAjusteById(int id);
        bool SaveAjusteInventario(IList<TbPrAjusteInventario> domain);
        bool UpdateAjusteInventario(IList<TbPrAjusteInventario> domain);
        void DeleteAjusteInventario(IList<long> id);
        IList<TbCoCuentaContable> GetAllCC();
        IList<TbCoCentrosDeGastos> GetAllCG();
    }
}
