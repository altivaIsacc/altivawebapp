using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdTipoTarifa
    {
        public TbFdTipoTarifa()
        {
            TbFdContratoServicio = new HashSet<TbFdContratoServicio>();
            TbFdContratoTipoTarifa = new HashSet<TbFdContratoTipoTarifa>();
            TbFdReservacionHospedaje = new HashSet<TbFdReservacionHospedaje>();
            TbFdReservacionServicio = new HashSet<TbFdReservacionServicio>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Inactivo { get; set; }

        public virtual ICollection<TbFdContratoServicio> TbFdContratoServicio { get; set; }
        public virtual ICollection<TbFdContratoTipoTarifa> TbFdContratoTipoTarifa { get; set; }
        public virtual ICollection<TbFdReservacionHospedaje> TbFdReservacionHospedaje { get; set; }
        public virtual ICollection<TbFdReservacionServicio> TbFdReservacionServicio { get; set; }
    }
}
