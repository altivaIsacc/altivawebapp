﻿using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IPreciosRepository
    {
        TbPrPrecios GetFirstPrecioCatalogo();
        TbPrPrecios Save(TbPrPrecios domain);
        TbPrPrecios Update(TbPrPrecios domain);
        IList<TbPrPrecios> GetAll();
        TbPrPrecios GetPreciosById(int id);
        IList<TbPrPrecios> GetPreciosSinAnular();
        TbPrPrecios GetPreciosByDesc(int Id);
        IList<TbPrPrecios> GetPreciosWithReqs();
    }
}
