using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdUsuarioCosto
    {
        public long Id { get; set; }
        public long? IdUsuario { get; set; }
        public double? Costo { get; set; }

        public virtual TbSeUsuario IdUsuarioNavigation { get; set; }
    }
}
