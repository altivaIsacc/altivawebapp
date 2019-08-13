using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IDescuentoPromocionRepository
    {

        TbFaRebajaConfig Save(TbFaRebajaConfig domain);
        TbFaRebajaConfig Update(TbFaRebajaConfig domain);
        TbFaRebajaConfig GetRebajaConfig();
    }
}
