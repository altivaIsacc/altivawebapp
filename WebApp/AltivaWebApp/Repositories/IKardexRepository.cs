using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IKardexRepository
    {
        TbPrKardex Save(TbPrKardex domain);
        TbPrKardex Update(TbPrKardex domain);
        IList<TbPrKardex> GetAll();
        IList<TbPrKardex> GetAllKardexByDocumento(int id);
        IList<TbPrKardex> GetAllKardexByTipoDocumento(string tipo);
        IList<TbPrKardex> SaveAll(IList<TbPrKardex> domain);
    }
}
