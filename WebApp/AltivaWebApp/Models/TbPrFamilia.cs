using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrFamilia
    {
        public TbPrFamilia()
        {
            InverseIdFamiliaNavigation = new HashSet<TbPrFamilia>();
            TbPrInventario = new HashSet<TbPrInventario>();
        }

        public long Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public long? IdFamilia { get; set; }

        public virtual TbPrFamilia IdFamiliaNavigation { get; set; }
        public virtual ICollection<TbPrFamilia> InverseIdFamiliaNavigation { get; set; }
        public virtual ICollection<TbPrInventario> TbPrInventario { get; set; }
    }
}
