using System;
using System.Collections.Generic;

namespace AltivaWebApp.GEDomain
{
    public partial class TbSeUsuarioConfiguraion
    {
        public long Id { get; set; }
        public string Tema { get; set; }
        public string Idioma { get; set; }
        public long IdUsuario { get; set; }

        public virtual TbSeUsuario IdUsuarioNavigation { get; set; }
    }
}
