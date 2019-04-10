using System;
using System.Collections.Generic;

namespace AltivaWebApp.GEDomain
{
    public partial class TbSePerfil
    {
        public TbSePerfil()
        {
            TbSePerfilModulo = new HashSet<TbSePerfilModulo>();
            TbSePerfilUsuario = new HashSet<TbSePerfilUsuario>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TbSePerfilModulo> TbSePerfilModulo { get; set; }
        public virtual ICollection<TbSePerfilUsuario> TbSePerfilUsuario { get; set; }
    }
}
