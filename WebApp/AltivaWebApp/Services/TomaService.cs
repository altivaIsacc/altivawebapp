using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;


namespace AltivaWebApp.Services
{
    public class TomaService : ITomaService
    {
        private readonly ITomaRepository repository;
        public TomaService(ITomaRepository repository)
        {
            this.repository = repository;
        }

        public IList<TbPrTomaDetalle> EliminarTomaDetalle(IList<TbPrTomaDetalle> domain)
        {
            return repository.EliminarTomaDetalle(domain);
        }

        public IList<TbPrTomaDetalle> GenerateTD(TbPrToma domain)
        {
            return repository.GenerateTD(domain);
        }

        public IList<TbPrToma> GetAll()
        {
            return repository.GetAll();
        }

        public IList<TbPrTomaDetalle> GetAllDetalleByIdD(IList<int> domain)
        {
            return repository.GetAllDetalleByIdD(domain);
        }

        public IList<TbPrToma> GetAllTomaConBodega()
        {
            return repository.GetAllTomaConBodega();
        }

        public IList<TbPrTomaDetalle> GetDetallesByTomaId(long id)
        {
            return repository.GetDetallesByTomaId(id);
        }

        public TbPrToma GetTomaByID(long id)
        {
            return repository.GetTomaByID(id);
        }

        public TbPrToma Save(TbPrToma domain)
        {
            return repository.Save(domain);
        }

        public IList<TbPrTomaDetalle> SaveTomaDetalle(IList<TbPrTomaDetalle> domain)
        {
            return repository.SaveTomaDetalle(domain);
        }

        public TbPrToma Update(TbPrToma domain)
        {
            return repository.Update(domain);        
        }

        public IList<TbPrTomaDetalle> UpdateTomaDetalle(IList<TbPrTomaDetalle> domain)
        {
            return repository.UpdateTomaDetalle(domain);
        }
        public bool ExisteTomaInicial(int idBodega)
        {
            return repository.ExisteTomaInicial(idBodega);
        }

        public IList<TbPrToma> GetCombinables(int idBodega)
        {
            return repository.GetCombinables(idBodega);
        }


        public TbPrToma CombinarTomas(int id, IList<int> domain)
        {
            return repository.CombinarTomas(id, domain);
        }

        public TbPrToma GetTomaByIDCompleto(long id)
        {
            return repository.GetTomaByIDCompleto(id);
        }

        public bool TieneToma(DateTime fechaDoc)
        {
            return repository.TieneToma(fechaDoc);
        }

        public void AnularTomasBorrador(long id)
        {
            repository.AnularTomasBorrador(id);
        }
    }
}
