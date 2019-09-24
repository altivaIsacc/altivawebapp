﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class MovimientoViewModel
    {
        public long IdMovimiento { get; set; }
        public long IdContacto { get; set; }
        public long IdDocumento { get; set; }
        public int IdTipoDocumento { get; set; }
        public long? IdUsuario { get; set; }
        public bool Cxp { get; set; }
        public bool Cxc { get; set; }
        public int IdMoneda { get; set; }
        public double Monto { get; set; }
        public string DisponibleDolar { get; set; }
        public double DisponibleBase { get; set; }
        public double DisponibleEuro { get; set; }
        public double AplicadoBase { get; set; }
        public double AplicadoDolar { get; set; }
        public double AplicadoEuro { get; set; }
        public double? SaldoBase { get; set; }
        public double? SaldoDolar { get; set; }
        public double SaldoEuro { get; set; }
        public DateTime FechaCreacion { get; set; }
        public IList<MovimientoJustificanteViewModel> movimientoJustificante { get; set; }

    }
}
