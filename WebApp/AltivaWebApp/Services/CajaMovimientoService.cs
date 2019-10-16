using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class CajaMovimientoService: ICajaMovimientoService
    {
        private readonly ICajaMovimientoRepository repository;
        public CajaMovimientoService(ICajaMovimientoRepository repository)
        {
            this.repository = repository;
        }

        public IList<TbFaCajaMovimiento> SaveRange(IList<TbFaCajaMovimiento> domain)
        {
            return repository.SaveRange(domain);
        }
    }
}
