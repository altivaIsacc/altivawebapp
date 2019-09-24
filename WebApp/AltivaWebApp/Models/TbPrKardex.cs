using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrKardex
    {
        public long Id { get; set; }
        public long IdInventario { get; set; }
        public long IdDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public DateTime Fecha { get; set; }
        public double ExistAnt { get; set; }
        public double CantidadMov { get; set; }
        public double ExistAct { get; set; }
        public double PrecioUnit { get; set; }
        public double CostoMov { get; set; }
        public int IdMoneda { get; set; }
        public long IdBodegaOrigen { get; set; }
        public long IdBodegaDestino { get; set; }
        public double ExistAntBod { get; set; }
        public double ExistActBod { get; set; }
        public string Observaciones { get; set; }
        public double CostoPromedio { get; set; }
        public double SaldoFinal { get; set; }
        public double PrecioPromedio { get; set; }
        public long IdUsuario { get; set; }
    }
}
