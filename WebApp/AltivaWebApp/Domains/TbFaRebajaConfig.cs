﻿using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFaRebajaConfig
    {
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
    }
}