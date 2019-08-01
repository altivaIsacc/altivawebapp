using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IBodegaRepository
    {
        TbPrBodega Save(TbPrBodega domain);
        TbPrBodega Update(TbPrBodega domain);
        bool Delete(TbPrBodega domain);
        IList<TbPrBodega> GetAllActivas();
        IList<TbPrBodega> GetAll();
        TbPrBodega GetBodegaById(int id);
        TbPrBodega GetBodegaByNombre(string nombre);
        IList<TbPrBodega> GetAllInactivas();
        IList<TbPrBodega> GetAllBodegasConInventario();
        void UpdateInventarioBodega(IList<TbPrInventarioBodega> inventarioBodega);
    }
}
