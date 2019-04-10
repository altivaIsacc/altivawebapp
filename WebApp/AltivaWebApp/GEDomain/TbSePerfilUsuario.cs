using System;
using System.Collections.Generic;

namespace AltivaWebApp.GEDomain
{
    public partial class TbSePerfilUsuario
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public long IdPerfil { get; set; }

        public virtual TbSePerfil IdPerfilNavigation { get; set; }
        public virtual TbSeUsuario IdUsuarioNavigation { get; set; }
    }
}
