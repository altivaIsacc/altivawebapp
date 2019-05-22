using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdContrato
    {
        public TbFdContrato()
        {
            TbFdCliente = new HashSet<TbFdCliente>();
            TbFdContratoDescuento = new HashSet<TbFdContratoDescuento>();
            TbFdContratoHospedaje = new HashSet<TbFdContratoHospedaje>();
            TbFdContratoServicio = new HashSet<TbFdContratoServicio>();
            TbFdContratoServicioTemp = new HashSet<TbFdContratoServicioTemp>();
            TbFdContratoTipoHabitacion = new HashSet<TbFdContratoTipoHabitacion>();
            TbFdContratoTipoTarifa = new HashSet<TbFdContratoTipoTarifa>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public bool Inactivo { get; set; }
        public bool General { get; set; }
        public long IdTemporadaGrupo { get; set; }

        public virtual ICollection<TbFdCliente> TbFdCliente { get; set; }
        public virtual ICollection<TbFdContratoDescuento> TbFdContratoDescuento { get; set; }
        public virtual ICollection<TbFdContratoHospedaje> TbFdContratoHospedaje { get; set; }
        public virtual ICollection<TbFdContratoServicio> TbFdContratoServicio { get; set; }
        public virtual ICollection<TbFdContratoServicioTemp> TbFdContratoServicioTemp { get; set; }
        public virtual ICollection<TbFdContratoTipoHabitacion> TbFdContratoTipoHabitacion { get; set; }
        public virtual ICollection<TbFdContratoTipoTarifa> TbFdContratoTipoTarifa { get; set; }
    }
}
