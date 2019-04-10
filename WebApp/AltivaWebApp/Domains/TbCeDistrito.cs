using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbCeDistrito
    {
        public int IdProvincia { get; set; }
        public int IdCanton { get; set; }
        public int IdDistrito { get; set; }
        public string DescDistrito { get; set; }
    }
}
