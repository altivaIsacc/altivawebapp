
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//creada por lenin
namespace AltivaWebApp.Services
{
    public class FlujoCategoriaService:IFlujoCategoriaService
    {
        
        private readonly IFlujoCategoriaRepository repository;
        //constructor
        public FlujoCategoriaService(IFlujoCategoriaRepository repository)
        {
            this.repository = repository;
        }

        public TbBaFlujoCategoria Save(TbBaFlujoCategoria domain)
        {
            return repository.Save(domain);
        }
        public TbBaFlujoCategoria Update(TbBaFlujoCategoria domain)
        {
            return repository.Update(domain);
        }

        public IList<TbBaFlujoCategoria> GetAllFlujoCategoria()
        {
            return repository.GetAllFlujoCategoria();
        }

        public TbBaFlujoCategoria GetFlujoCategoriaById(int id)
        {
            return repository.GetFlujoCategoriaById(id);
        }

        public TbBaFlujoCategoria GetFlujoCategoriaByDesc(string cod, int idTipo)
        {
            return repository.GetFlujoCategoriaByDesc(cod, idTipo);
        }

        public TbBaFlujoCategoria GetFlujoCategoriaByTipo(int tipo)
        {
            return repository.GetFlujoCategoriaByTipo(tipo);
        }

        public bool ExisteCatFlujoCadaTipo()
        {
            return repository.ExisteCatFlujoCadaTipo();
        }

        public IList<TbBaFlujo> SaveFlujo(IList<TbBaFlujo> flujos)
        {
            return repository.SaveFlujo(flujos);
        }
    }
}
