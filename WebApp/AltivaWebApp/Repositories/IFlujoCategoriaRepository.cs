
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//agregado por lenin
namespace AltivaWebApp.Repositories
{
    public interface IFlujoCategoriaRepository
    {
        TbBaFlujoCategoria Save(TbBaFlujoCategoria domain);
        TbBaFlujoCategoria Update(TbBaFlujoCategoria domain);
        IList<TbBaFlujoCategoria> GetAllFlujoCategoria();
        TbBaFlujoCategoria GetFlujoCategoriaById(int id);
        TbBaFlujoCategoria GetFlujoCategoriaByDesc(string cod, int idTipo);
        TbBaFlujoCategoria GetFlujoCategoriaByTipo(int tipo);
        bool ExisteCatFlujoCadaTipo();
    }
}
