using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbBaConciliacion
    {
        public long IdConciliacion { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public long IdUsuarioCreacion { get; set; }
        public long IdUsuarioModificador { get; set; }
        public long IdCuentaBancaria { get; set; }
        public double SaldoConciliado { get; set; }
        public double SaldoBanco { get; set; }
        public double SaldoNoconciliado { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public long IdMoneda { get; set; }
        public double SaldoConciliadoAnterior { get; set; }
    }
}
