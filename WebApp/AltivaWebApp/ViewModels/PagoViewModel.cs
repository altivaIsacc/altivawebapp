using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class PagoViewModel
    {

        public long IdPago { get; set; }
        public long IdContacto { get; set; }
        public int IdTipoDocumento { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string Nota { get; set; }

    }
}
