using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface ICajaMovimientoService
    {
        IList<TbFaCajaMovimiento> SaveRange(IList<TbFaCajaMovimiento> domain);
    }
}
