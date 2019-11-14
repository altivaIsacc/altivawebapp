using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class DocumentosSaldoGeneralViewModel
    {
        public long IdMovimiento { get; set; }
        public double SaldoBase { get; set; }
        public double SaldoDolar { get; set; }
        public double SaldoEuro { get; set; }     
        public long IdContacto { get; set; }
        public long IdDocumento { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
