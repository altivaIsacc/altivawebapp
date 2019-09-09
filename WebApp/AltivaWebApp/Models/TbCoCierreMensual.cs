using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbCoCierreMensual
    {
        public long Id { get; set; }
        public long IdPeriodoTrabajo { get; set; }
        public long IdCuentaContable { get; set; }
        public double SaldoAnteriorColones { get; set; }
        public double DebitosColones { get; set; }
        public double CreditosColones { get; set; }
        public double SaldoPeriodoColones { get; set; }
        public double SaldoActualColones { get; set; }
        public double SaldoAnteriorDolar { get; set; }
        public double DebitosDolar { get; set; }
        public double CreditosDolar { get; set; }
        public double SaldoPeriodoDolar { get; set; }
        public double SaldoActualDolar { get; set; }
        public double SaldoAnteriorEuros { get; set; }
        public double DebitosEuros { get; set; }
        public double CreditosEuros { get; set; }
        public double SaldoPeriodoEuro { get; set; }
        public double SaldoActualEuros { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuarioCreador { get; set; }
        public bool PeriodoFiscal { get; set; }
        public long IdPeriodoFiscal { get; set; }
    }
}
