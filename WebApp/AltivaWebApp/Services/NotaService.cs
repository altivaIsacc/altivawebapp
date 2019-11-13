using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class NotaService: INotaService
    {
        private readonly INotaRepository repository;

        public NotaService(INotaRepository repository)
        {
            this.repository = repository;
        }
        public IList<TbFaNota> GetAll()
        {
            return repository.GetAll(); 
        }     

        public TbFaNota GetNotaById(long id)
        {
            return repository.GetNotaById(id);
        }
        public  TbFaPago GetPagoById(long id)
        {
            return repository.GetPagoById(id);

        }


        public TbFaNota Save(TbFaNota domain)
        {
            return repository.Save(domain);
        }
        public TbFaNota Update(TbFaNota domain)
        {
            return repository.Update(domain);
        }
        public TbFaPago UpdateDoc(TbFaPago domain)
        {
            return repository.UpdateDoc(domain);
        }
        public IList<TbFaTipoDocumento> GetAllTipoDocumento()
        {
            return repository.GetAllTipoDocumento();
        }
        public TbFaMovimiento SaveMovimiento(TbFaMovimiento domain)
        {
            return repository.SaveMovimiento(domain);
        }
 

    }
}
