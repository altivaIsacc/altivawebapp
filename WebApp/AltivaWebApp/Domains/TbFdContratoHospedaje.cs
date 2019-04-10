using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdContratoHospedaje
    {
        public long Id { get; set; }
        public long IdContrato { get; set; }
        public long IdTipoTarifa { get; set; }
        public long IdTipoHabitacion { get; set; }
        public long IdTemporada { get; set; }
        public double Sencilla { get; set; }
        public double Doble { get; set; }
        public double Triple { get; set; }
        public double Cuadruple { get; set; }
        public double AdultoAdicional { get; set; }
        public double NiñoAdicional { get; set; }

        public virtual TbFdContrato IdContratoNavigation { get; set; }
    }
}
