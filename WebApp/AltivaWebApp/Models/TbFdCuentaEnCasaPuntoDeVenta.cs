﻿using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdCuentaEnCasaPuntoDeVenta
    {
        public long Id { get; set; }
        public long IdCuentaEnCasa { get; set; }
        public long IdPuntoVenta { get; set; }
        public bool Credito { get; set; }

        public virtual TbFdCuentaEnCasa IdCuentaEnCasaNavigation { get; set; }
    }
}
