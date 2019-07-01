using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrUnidadMedida
    {
        public TbPrUnidadMedida()
        {
            TbPrConversionIdUnidadDestinoNavigation = new HashSet<TbPrConversion>();
            TbPrConversionIdUnidadOrigenNavigation = new HashSet<TbPrConversion>();
        }

        public long Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }

        public virtual ICollection<TbPrConversion> TbPrConversionIdUnidadDestinoNavigation { get; set; }
        public virtual ICollection<TbPrConversion> TbPrConversionIdUnidadOrigenNavigation { get; set; }
    }
}
