using AltivaWebApp.Repositories;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class SaldoGeneralService : ISaldoGeneralService
    {
        private readonly ISaldoGeneralRepository repository;
        public SaldoGeneralService(ISaldoGeneralRepository repository)
        {
            this.repository = repository;
        }

        public IList<DocumentosSaldoGeneralViewModel> GetDocumentos()
        {
            return repository.GetDocumentos();
        }
        public IList<ContactoSaldoGeneralViewModel> GetContactos()
        {
            return repository.GetContactos();
        }
    }
}
