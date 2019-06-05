using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbCrContacto
    {
        public TbCrContacto()
        {
            TbCrContactoRelacionIdContactoHijoNavigation = new HashSet<TbCrContactoRelacion>();
            TbCrContactoRelacionIdContactoPadreNavigation = new HashSet<TbCrContactoRelacion>();
            TbCrContactosCamposPersonalizados = new HashSet<TbCrContactosCamposPersonalizados>();
            TbFaCotizacion = new HashSet<TbFaCotizacion>();
            TbFdCondicionesDePago = new HashSet<TbFdCondicionesDePago>();
            TbFdCuentasBancarias = new HashSet<TbFdCuentasBancarias>();
            TbFdTarea = new HashSet<TbFdTarea>();
            TbPrCompra = new HashSet<TbPrCompra>();
            TbPrOrden = new HashSet<TbPrOrden>();
        }

        public long IdContacto { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NombreComercial { get; set; }
        public string NombreJuridico { get; set; }
        public string Cedula { get; set; }
        public string TipoCedula { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Pais { get; set; }
        public int? Provincia { get; set; }
        public int? Canton { get; set; }
        public int? Distrito { get; set; }
        public bool? Persona { get; set; }
        public bool? Empresa { get; set; }
        public bool? Cliente { get; set; }
        public bool? Proveedor { get; set; }
        public string OtrasSenas { get; set; }
        public string Ruta { get; set; }
        public long? IdUsuario { get; set; }
        public long? IdFamiliaCliente { get; set; }
        public long? IdFamiliaProveedor { get; set; }
        public long? IdSubFamiliaCliente { get; set; }
        public long? IdSubFamiliaProveedor { get; set; }
        public long? IdTipoCliente { get; set; }
        public long? IdTipoProveedor { get; set; }
        public string MapLink { get; set; }
        public string WebLink { get; set; }

        public virtual ICollection<TbCrContactoRelacion> TbCrContactoRelacionIdContactoHijoNavigation { get; set; }
        public virtual ICollection<TbCrContactoRelacion> TbCrContactoRelacionIdContactoPadreNavigation { get; set; }
        public virtual ICollection<TbCrContactosCamposPersonalizados> TbCrContactosCamposPersonalizados { get; set; }
        public virtual ICollection<TbFaCotizacion> TbFaCotizacion { get; set; }
        public virtual ICollection<TbFdCondicionesDePago> TbFdCondicionesDePago { get; set; }
        public virtual ICollection<TbFdCuentasBancarias> TbFdCuentasBancarias { get; set; }
        public virtual ICollection<TbFdTarea> TbFdTarea { get; set; }
        public virtual ICollection<TbPrCompra> TbPrCompra { get; set; }
        public virtual ICollection<TbPrOrden> TbPrOrden { get; set; }
    }
}
