using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFaDescuentoUsuario
    {
        public int IdDescuentoUsuario { get; set; }
        public int IdRebajaConfig { get; set; }
        public long IdUsuario { get; set; }
        public double MaxDescuento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuarioCreador { get; set; }
        public string Nota { get; set; }

        public virtual TbFaRebajaConfig IdRebajaConfigNavigation { get; set; }
    }
}
