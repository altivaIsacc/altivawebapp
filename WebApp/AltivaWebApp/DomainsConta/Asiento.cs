using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltivaWebApp.DomainsConta
{
    [Table("tb_CO_AsientoContable")]
    public class Asiento
    {
        [Key]
        public long IdAsientoContable { get; set; }
        public DateTime Fecha { get; set; }
        public string Codigo { get; set; }
        public int Estado { get; set; }
        public string Descripcion { get; set; }
        public int CodigoMoneda { get; set; }
        public double MontoColones { get; set; }
        public double MontoDolar { get; set; }
        public double MontoEuro { get; set; }
        public string Modulo { get; set; }
        public long IdTipoDocumento { get; set; }
        public long IdDocumento { get; set; }
        public long IdPeriodoTrabajo { get; set; }
        public long IdUsuarioCreador { get; set; }
        public long IdUsuarioMod { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public bool Frecuente { get; set; }
        public IList<AsientoDetalle> detalle { get; set; }
    }

    [Table("tb_CO_AsientoContableDetalle")]
    public class AsientoDetalle
    {
        [Key]
        public long IdDetalleAsientoContable { get; set; }
        public long IdAsientoContable { get; set; }
        public long IdCuentaContable { get; set; }
        public double MontoColones { get; set; }
        public double MontoDolares { get; set; }
        public double MontoEuro { get; set; }
        public bool Debe { get; set; }
        public bool Haber { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }
        public long IdCentrosDeGastos { get; set; }
        public string NumDocumento{ get;set; }
        public long IdTipoDocumento { get; set; }
        public string Observacion { get; set; }
    }

}
