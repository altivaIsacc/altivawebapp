using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFaRebajaConfig
    {
        public TbFaRebajaConfig()
        {
            TbFaDescuentoUsuario = new HashSet<TbFaDescuentoUsuario>();
            TbFaDescuentoUsuarioClave = new HashSet<TbFaDescuentoUsuarioClave>();
            TbFaDescuentoUsuarioRango = new HashSet<TbFaDescuentoUsuarioRango>();
            TbFaPromocionProducto = new HashSet<TbFaPromocionProducto>();
        }

        public int IdRebajaConfig { get; set; }
        public bool ActivaMaxGeneral { get; set; }
        public double PorcMaxGeneral { get; set; }
        public bool ActivaMaxUsuario { get; set; }
        public bool ActivaMaxUsuarioRango { get; set; }
        public bool ActivaMaxUsuarioClave { get; set; }
        public bool ActivaPromoProducto { get; set; }
        public bool ActivaPromoProductoUsuario { get; set; }
        public bool ActivaDescuentoPromoUsuario { get; set; }
        public bool ActivaDescuentoPromoUsuarioClave { get; set; }

        public virtual ICollection<TbFaDescuentoUsuario> TbFaDescuentoUsuario { get; set; }
        public virtual ICollection<TbFaDescuentoUsuarioClave> TbFaDescuentoUsuarioClave { get; set; }
        public virtual ICollection<TbFaDescuentoUsuarioRango> TbFaDescuentoUsuarioRango { get; set; }
        public virtual ICollection<TbFaPromocionProducto> TbFaPromocionProducto { get; set; }
    }
}
