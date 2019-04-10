using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbReComanda
    {
        public TbReComanda()
        {
            TbReCuenta = new HashSet<TbReCuenta>();
            TbReOrden = new HashSet<TbReOrden>();
        }

        public long IdComanda { get; set; }
        public string Tipo { get; set; }
        public long IdReferencia { get; set; }
        public string Nombre { get; set; }
        public long IdUsuario { get; set; }
        public DateTime Fecha { get; set; }

        public virtual ICollection<TbReCuenta> TbReCuenta { get; set; }
        public virtual ICollection<TbReOrden> TbReOrden { get; set; }
    }
}
