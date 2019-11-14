using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
   public interface ISaldoGeneralRepository
    {
        IList<DocumentosSaldoGeneralViewModel> GetDocumentos();

        IList<ContactoSaldoGeneralViewModel> GetContactos();
    }
}
