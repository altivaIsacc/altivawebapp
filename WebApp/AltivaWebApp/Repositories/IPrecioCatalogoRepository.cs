﻿using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AltivaWebApp.Repositories
{
    public interface IPrecioCatalogoRepository
    {
        TbPrPrecioCatalogo Save(TbPrPrecioCatalogo domain);
        TbPrPrecioCatalogo Update(TbPrPrecioCatalogo domain);
        IList<TbPrPrecioCatalogo> GetAll();
        TbPrPrecioCatalogo GetPrecioCatalogoById(int id);
       
        IList<TbPrPrecioCatalogo> GetPreciosWithReqs();
        IList<TbPrPrecioCatalogo> GetAllPrecioCatalogo();
    }
}