using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbReOrden
    {
        public TbReOrden()
        {
            TbReLineaOrden = new HashSet<TbReLineaOrden>();
        }

        public long IdOrden { get; set; }
        public long? IdUsuario { get; set; }
        public long IdComanda { get; set; }
        public DateTime? FechaOrden { get; set; }
        public string Estado { get; set; }
        public string Impresora { get; set; }
        public string Observacion { get; set; }
        public long? IdUsuarioModificador { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual TbReComanda IdComandaNavigation { get; set; }
        public virtual ICollection<TbReLineaOrden> TbReLineaOrden { get; set; }
    }
}
