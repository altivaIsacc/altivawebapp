using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbCoCuentaContable
    {
        public TbCoCuentaContable()
        {
            TbCoAsientoContableDetalle = new HashSet<TbCoAsientoContableDetalle>();
            TbPrAjusteInventario = new HashSet<TbPrAjusteInventario>();
        }

        public long Id { get; set; }
        public string CuentaContable { get; set; }
        public string Descripcion { get; set; }
        public short Nivel { get; set; }
        public string Tipo { get; set; }
        public int Parentid { get; set; }
        public string CuentaMadre { get; set; }
        public string DescCuentaMadre { get; set; }
        public bool Movimiento { get; set; }
        public bool Evaluacion { get; set; }
        public int CodTipoCompra { get; set; }
        public string DescTipoCompra { get; set; }
        public string CuentaContablePresupuesto { get; set; }
        public bool? PermisoCheque { get; set; }
        public bool? PermisoBancos { get; set; }
        public bool? PermisoCont { get; set; }
        public bool? PermisoCxP { get; set; }
        public bool? PermisoCxC { get; set; }
        public bool? PermisoAcF { get; set; }
        public bool? PermisoInv { get; set; }
        public bool? PermisoGas { get; set; }
        public bool? PermisoPla { get; set; }
        public bool? PermisoFac { get; set; }
        public bool? PermisoConf { get; set; }
        public bool? PermisoDepositos { get; set; }
        public bool? PermisoNotaCre { get; set; }
        public bool? PermisoNotaDe { get; set; }
        public bool GastoNoDeducible { get; set; }
        public string Moneda { get; set; }
        public string TipoConversion { get; set; }
        public string Notas { get; set; }
        public bool Inactivo { get; set; }

        public virtual ICollection<TbCoAsientoContableDetalle> TbCoAsientoContableDetalle { get; set; }
        public virtual ICollection<TbPrAjusteInventario> TbPrAjusteInventario { get; set; }
    }
}
