using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
  public  interface IDescuentoPromocionService
    {
        TbFaRebajaConfig SaveConfig(TbFaRebajaConfig domain);
        TbFaRebajaConfig Update(TbFaRebajaConfig domain);
        TbFaRebajaConfig GetRebajaConfig();
    }
}
