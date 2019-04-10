using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IConversionRepository
    {
        TbPrConversion Save(TbPrConversion domain);
        TbPrConversion Update(TbPrConversion domain);
        bool Delete(TbPrConversion domain);
        IList<TbPrConversion> GetAll();
        TbPrConversion GetConversionById(int id);
    }
}
