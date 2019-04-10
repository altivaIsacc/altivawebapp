using System;
using System.Collections.Generic;

namespace AltivaWebApp.GEDomain
{
    public partial class TbSeAdjunto
    {
        public int Id { get; set; }
        public int? IdMensaje { get; set; }
        public string Ruta { get; set; }
        public bool Estado { get; set; }

        public virtual TbSeMensaje IdMensajeNavigation { get; set; }
    }
}
