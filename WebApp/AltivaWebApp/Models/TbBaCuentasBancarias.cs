using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbBaCuentasBancarias
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public int IdMoneda { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FechaSaldoInicial { get; set; }
        public decimal SaldoInicial { get; set; }
        public long IdUsuarioCreador { get; set; }
        public long IdUsuarioModificador { get; set; }
        public bool Ingresos { get; set; }
        public bool Pago { get; set; }
        public bool Planilla { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
    }
}
