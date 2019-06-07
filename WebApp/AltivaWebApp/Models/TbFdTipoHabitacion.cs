using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdTipoHabitacion
    {
        public TbFdTipoHabitacion()
        {
            TbFdAuditoriaOcupacion = new HashSet<TbFdAuditoriaOcupacion>();
            TbFdAuditoriaRooming = new HashSet<TbFdAuditoriaRooming>();
            TbFdContratoTipoHabitacion = new HashSet<TbFdContratoTipoHabitacion>();
            TbFdHabitacion = new HashSet<TbFdHabitacion>();
            TbFdReservacionHospedaje = new HashSet<TbFdReservacionHospedaje>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string SobreVentas { get; set; }
        public bool Inactivo { get; set; }
        public string Color { get; set; }
        public string IdCuentaContable { get; set; }
        public string NombreCuenta { get; set; }
        public bool ExcluirAuditoria { get; set; }

        public virtual ICollection<TbFdAuditoriaOcupacion> TbFdAuditoriaOcupacion { get; set; }
        public virtual ICollection<TbFdAuditoriaRooming> TbFdAuditoriaRooming { get; set; }
        public virtual ICollection<TbFdContratoTipoHabitacion> TbFdContratoTipoHabitacion { get; set; }
        public virtual ICollection<TbFdHabitacion> TbFdHabitacion { get; set; }
        public virtual ICollection<TbFdReservacionHospedaje> TbFdReservacionHospedaje { get; set; }
    }
}
