using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbSeMensajeReceptor
    {
        public int Id { get; set; }
        public int? IdMensaje { get; set; }
        public string Estado { get; set; }
        public long? IdReceptor { get; set; }

        public virtual TbSeMensaje IdMensajeNavigation { get; set; }
        public virtual TbSeUsuario IdReceptorNavigation { get; set; }
    }
}
