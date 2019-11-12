using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface ISaldoGeneralService
    {
        IList<DocumentosSaldoGeneralViewModel> GetDocumentos();

        IList<ContactoSaldoGeneralViewModel> GetContactos();
    }
}
