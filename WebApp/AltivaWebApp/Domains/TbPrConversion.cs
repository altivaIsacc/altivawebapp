using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrConversion
    {
        public long IdConversion { get; set; }
        public double Equivalencia { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public long IdUnidadOrigen { get; set; }
        public long IdUnidadDestino { get; set; }

        public virtual TbPrUnidadMedida IdUnidadDestinoNavigation { get; set; }
        public virtual TbPrUnidadMedida IdUnidadOrigenNavigation { get; set; }
    }
}
