using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbPrProveedor
    {
        public TbPrProveedor()
        {
            TbCpGastos = new HashSet<TbCpGastos>();
        }

        public long IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string PersoneriaJuridica { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public bool Inactiva { get; set; }
        public long IdUsuario { get; set; }
        public long IdTipoProveedor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EsEmpresa { get; set; }
        public string Telefono2 { get; set; }
        public string Fax { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Direccion { get; set; }
        public string SitioWeb { get; set; }
        public int IdPais { get; set; }
        public int PlazoenDiasCredito { get; set; }
        public bool TieneCredito { get; set; }
        public double MontoMaximoCredito { get; set; }
        public int CodigoMoneda { get; set; }

        public virtual ICollection<TbCpGastos> TbCpGastos { get; set; }
    }
}
