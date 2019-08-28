using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltivaWebApp.DomainsConta
{
    [Table("tb_CO_AsientoContable")]
    public class Asiento
    {
        [Key]
        public long IdAsientoAsientoContable { get; set; }
        public DateTime  Fecha { get; set; }
        public string Codigo { get; set; }
        public string Estado { get; set; }
        public float Descripcion { get; set; }
        public long CodigoMoneda { get; set; }
        public float MontoColones { get; set; }
        public float MontoDolar { get; set; }
        public string Modulo { get; set; }
        public long IdTipoDocumento { get; set; }
        public long IdDocumento { get; set; }
        public short IdUsuarioCreador { get; set; }
        public short IdUsuarioMod { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public bool Frecuente { get; set; }

    }

    [Table("tb_CO_AsientoContableDetalle")]
    public class AsientoDetalle
    {
        [Key]
        public long IdDetalleAsientoContable { get; set; }
        public long IdAsientoContable { get; set; }
        public string IdCuentaContable { get; set; }
        public float MontoColones { get; set; }
        public float MontoDolares { get; set; }
        public float MontoEuro { get; set; }
        public bool Debe { get; set; }
        public bool Haber { get; set; }
        public float TipoCambioDolar { get; set; }
        public float TipoCambioEuro { get; set; }
        public long IdCentrosDeGastos { get; set; }
    }

}
