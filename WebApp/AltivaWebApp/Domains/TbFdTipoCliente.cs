using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdTipoCliente
    {
        public TbFdTipoCliente()
        {
            InverseIdPadreNavigation = new HashSet<TbFdTipoCliente>();
        }

        public long Id { get; set; }
        public long? IdPadre { get; set; }
        public string Nombre { get; set; }
        public bool? Inactivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long? IdUsuario { get; set; }

        public virtual TbFdTipoCliente IdPadreNavigation { get; set; }
        public virtual ICollection<TbFdTipoCliente> InverseIdPadreNavigation { get; set; }
    }
}
