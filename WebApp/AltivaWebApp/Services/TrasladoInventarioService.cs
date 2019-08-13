using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class TrasladoInventarioService : ITrasladoInventarioService
    {
        private readonly ITrasladoInventarioRepository repository;

        public TrasladoInventarioService(ITrasladoInventarioRepository _repository)
        {
            this.repository = _repository;
        }

        //NO
        public IList<TbPrTrasladoInventario> GetAllTrasladoInventario()
        {
            return repository.GetAllTrasladoInventario();
        }

        public TbPrTrasladoInventario GetTrasladoInventarioById(long idTraslado)
        {
            return repository.GetTrasladoInventarioById(idTraslado);
        }

        public TbPrTrasladoInventario Save(TbPrTrasladoInventario domain)
        {
            return repository.Save(domain);
        }

        public TbPrTrasladoInventario Update(TbPrTrasladoInventario domain)
        {
            return repository.Update(domain);
        }


    }
}
