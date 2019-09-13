using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AltivaWebApp.Services
{
    public class PuntoVentaService: IPuntoVentaService
    {
        private readonly IPuntoVentaRepository repository;

        public PuntoVentaService(IPuntoVentaRepository repository)
        {
            this.repository = repository;
        }
        public TbSePuntoVenta Save(TbSePuntoVenta domain)
        {
            return repository.Save(domain);
        }
        public TbSePuntoVenta Update(TbSePuntoVenta domain)
        {
            return repository.Update(domain);
        }
        public IList<TbSePuntoVenta> GetAll()
        {
            return repository.GetAll();
        }
        public TbSePuntoVenta GetPuntoVentaById(int id)
        {
            return repository.GetPuntoVentaById(id);
        }
        public bool ExistePuntoVentaValido()
        {
            return repository.ExistePuntoVentaValido();
        }
    }
}
