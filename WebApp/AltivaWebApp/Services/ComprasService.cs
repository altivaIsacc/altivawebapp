using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class ComprasService: IComprasService
    {
        IComprasRepository repository;
        public ComprasService(IComprasRepository repository)
        {
            this.repository = repository;
        }
    }
}
