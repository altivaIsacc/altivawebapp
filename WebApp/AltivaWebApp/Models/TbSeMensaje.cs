using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbSeMensaje
    {
        public TbSeMensaje()
        {
            TbSeAdjunto = new HashSet<TbSeAdjunto>();
            TbSeMensajeReceptor = new HashSet<TbSeMensajeReceptor>();
        }

        public int Id { get; set; }
        public string Mensaje { get; set; }
        public string Tipo { get; set; }
        public int? IdReferencia { get; set; }
        public string TipoReferencia { get; set; }
        public long? IdUsuario { get; set; }
        public string Estado { get; set; }

        public virtual TbSeUsuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<TbSeAdjunto> TbSeAdjunto { get; set; }
        public virtual ICollection<TbSeMensajeReceptor> TbSeMensajeReceptor { get; set; }
    }
}
