using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IPrecioCatalogoService
    {
        TbPrPrecioCatalogo Save(TbPrPrecioCatalogo domain);
        TbPrPrecioCatalogo Update(TbPrPrecioCatalogo domain);
        IList<TbPrPrecioCatalogo> GetAll();
        TbPrPrecioCatalogo GetPrecioCatalogoById(int id);
        IList<TbPrPrecioCatalogo> GetAllPrecioCatalogo();



        IList<TbPrPrecioCatalogo> GetPreciosWithReqs();
    }
}
