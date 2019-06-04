using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class DescuentoPromocionService : IDescuentoPromocionService
    {
        readonly IDescuentoPromocionRepository repository;
        public DescuentoPromocionService(IDescuentoPromocionRepository repository)
        {
            this.repository = repository;
        }

        public TbFaRebajaConfig SaveConfig(TbFaRebajaConfig domain)
        {
           return repository.Save(domain);
        }

        public TbFaRebajaConfig GetRebajaConfig()
        {
            return repository.GetRebajaConfig();
        }

        public TbFaRebajaConfig Update(TbFaRebajaConfig domain)
        {
            return repository.Update(domain);
        }
    }
}
