using System;
using System.Collections.Generic;

namespace AltivaWebApp.GEDomain
{
    public partial class TbSeMensaje
    {
        public TbSeMensaje()
        {
            TbSeAdjunto = new HashSet<TbSeAdjunto>();
            TbSeMensajeReceptor = new HashSet<TbSeMensajeReceptor>();
        }
        public TbSeMensaje(string mensaje)
        {
            this.Mensaje = mensaje;
        }
        public TbSeMensaje(string mensaje,string tipo, long? id)
        {
            this.Mensaje = mensaje;
            this.Tipo = tipo;
            this.IdUsuario = id;
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
