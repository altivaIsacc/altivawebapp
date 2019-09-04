using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbCeConsecutivoProvisionalHa
    {
        public long Id { get; set; }
        public long IdFactura { get; set; }
        public double NumFactura { get; set; }
        public string ConsecutivoHacienda { get; set; }
        public string TipoDocElectronico { get; set; }
    }
}
