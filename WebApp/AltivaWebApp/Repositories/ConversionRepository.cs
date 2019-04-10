using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class ConversionRepository: BaseRepository<TbPrConversion>, IConversionRepository
    {
        public ConversionRepository(EmpresasContext context) : base(context)
        {

        }

        public TbPrConversion GetConversionById(int id)
        {
            return context.TbPrConversion.FirstOrDefault(c => c.IdConversion == id);
        }

        

    }
}
