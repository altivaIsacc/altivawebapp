
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//creada por lenin
namespace AltivaWebApp.Services
{
    public interface IFlujoCategoriaService
    {
        TbBaFlujoCategoria Save(TbBaFlujoCategoria domain);
        TbBaFlujoCategoria Update(TbBaFlujoCategoria domain);
        IList<TbBaFlujoCategoria> GetAllFlujoCategoria();
        TbBaFlujoCategoria GetFlujoCategoriaById(int id);
        TbBaFlujoCategoria GetFlujoCategoriaByDesc(string cod, int idTipo);//valida existencia
        TbBaFlujoCategoria GetFlujoCategoriaByTipo(int tipo);
        bool ExisteCatFlujoCadaTipo();

    }
}
