using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IConversionService
    {
        TbPrConversion Save(TbPrConversion domain);
        TbPrConversion Update(TbPrConversion domain);
        bool Delete(TbPrConversion domain);
        IList<TbPrConversion> GetAll();
        TbPrConversion GetConversionById(int id);
    }
}
