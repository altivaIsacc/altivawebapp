using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrAjuste
    {
        public int IdAjuste { get; set; }
        public bool Anulada { get; set; }
        public DateTime Fecha { get; set; }
        public double TotalEntrada { get; set; }
        public double TotalSalida { get; set; }
        public double SaldoGeneral { get; set; }
        public long IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
