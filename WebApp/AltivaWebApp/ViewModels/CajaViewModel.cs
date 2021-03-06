﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CajaViewModel
    {
        public long IdCaja { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public long IdPuntoVenta { get; set; }

        public IList<CajaAperturaDenominacionViewModel> TbFaCajaAperturaDenominacion { get; set; }
        public IList<CajaArqueoDenominacionViewModel> TbFaCajaArqueoDenominacion { get; set; }
        public IList<CajaArqueoViewModel> TbFaCajaArqueo { get; set; }
        public IList<CajaCierreViewModel> TbFaCajaCierre { get; set; }


    }
}
