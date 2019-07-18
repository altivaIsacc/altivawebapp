using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class ComprasDetalleServicioService: IComprasDetalleServicioService
    {
        IComprasDetalleServicioRepository repository;
        public ComprasDetalleServicioService(IComprasDetalleServicioRepository repository)
        {
            this.repository = repository;
        }

    }
}
