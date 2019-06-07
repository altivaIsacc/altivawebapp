using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbBaMovimientoBancarios
    {
        public long IdMovimiento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Estado { get; set; }
        public double MontoDolar { get; set; }
        public double MontoColon { get; set; }
        public double MontoEuro { get; set; }
        public double Tccdolar { get; set; }
        public double Tcvdolar { get; set; }
        public double Tcceuro { get; set; }
        public double Tcveuro { get; set; }
        public double IdUsuarioCreador { get; set; }
        public double IdUsuarioModificador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Observacion { get; set; }
        public long IdMoneda { get; set; }
        public long IdCuentaBancaria { get; set; }
        public long IdCuentaBancariaDestino { get; set; }
        public long IdMonedaDestino { get; set; }
        public bool ConciliadoDebe { get; set; }
        public bool ConciliadoHaber { get; set; }
    }
}
