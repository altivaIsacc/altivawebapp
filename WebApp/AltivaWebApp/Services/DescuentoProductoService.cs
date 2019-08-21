using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class DescuentoProductoService: IDescuentoProductoService
    {
        readonly IDescuentoProductoRepository repository;
       
        public DescuentoProductoService( IDescuentoProductoRepository repository)
        {
            this.repository = repository;
         
        }
        
       

        public bool Save(IList<TbFaDescuentoProducto> domain)
        {
            return repository.SaveDescProd(domain);
        }

        public IList<TbFaDescuentoProducto> GetAll()

        {

            return repository.GetAll();

        }

        public TbFaDescuentoProducto GetDescuentoProductoById(int id)
        {
            return repository.GetDescuentoProductoById(id);
        }

        public bool Delete(TbFaDescuentoProducto domain)
        {
            return repository.Delete(domain);
        }
    }
}
