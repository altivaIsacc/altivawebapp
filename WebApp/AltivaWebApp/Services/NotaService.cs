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
        private readonly INotaRepository reposistory;

        public NotaService(INotaRepository reposistory)
        {
            this.reposistory = reposistory;
        }
        public IList<TbFaNota> GetAll()
        {
            return reposistory.GetAll(); 
        }     

        public TbFaNota GetNotaById(long id)
        {
            return reposistory.GetNotaById(id);
        }
        
        public TbFaNota Save(TbFaNota domain)
        {
            return reposistory.Save(domain);
        }
        public TbFaNota Update(TbFaNota domain)
        {
            return reposistory.Update(domain);
        }
        public IList<TbFaTipoDocumento> GetAllTipoDocumento()
        {
            return reposistory.GetAllTipoDocumento();
        }
        public TbFaMovimiento SaveMovimiento(TbFaMovimiento domain)
        {
            return reposistory.SaveMovimiento(domain);
        }


    }
}
