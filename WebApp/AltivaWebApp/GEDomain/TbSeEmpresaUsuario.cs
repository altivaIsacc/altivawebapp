using System;
using System.Collections.Generic;

namespace AltivaWebApp.GEDomain
{
    public partial class TbSeEmpresaUsuario
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public long IdEmpresa { get; set; }
        public bool Estado { get; set; }

        public virtual TbGeEmpresa IdEmpresaNavigation { get; set; }
        public virtual TbSeUsuario IdUsuarioNavigation { get; set; }
    }
}
