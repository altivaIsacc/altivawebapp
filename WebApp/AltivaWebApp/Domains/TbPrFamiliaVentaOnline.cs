using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains

{
    public partial class TbPrFamiliaVentaOnline
    {
        public TbPrFamiliaVentaOnline()
        {
            InverseIdFamiliaNavigation = new HashSet<TbPrFamiliaVentaOnline>();
        }

        public long Id { get; set; }
        public byte[] Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public long? IdUsuario { get; set; }
        public long? IdFamilia { get; set; }

        public virtual TbPrFamiliaVentaOnline IdFamiliaNavigation { get; set; }
        public virtual ICollection<TbPrFamiliaVentaOnline> InverseIdFamiliaNavigation { get; set; }
    }
}
