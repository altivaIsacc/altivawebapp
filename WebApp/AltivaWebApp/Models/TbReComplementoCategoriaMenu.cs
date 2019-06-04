using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbReComplementoCategoriaMenu
    {
        public int IdComplementoCategoriaMenu { get; set; }
        public int IdComplemento { get; set; }
        public int IdCategoria { get; set; }

        public virtual TbReCategoriaMenu IdCategoriaNavigation { get; set; }
        public virtual TbReComplemento IdComplementoNavigation { get; set; }
    }
}
