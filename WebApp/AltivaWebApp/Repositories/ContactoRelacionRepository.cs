﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
namespace AltivaWebApp.Repositories
{
    public class ContactoRelacionRepository : BaseRepository<TbCrContactoRelacion>, IContactoRelacionRepository
    {
        public ContactoRelacionRepository(EmpresasContext context) : base(context)
        {
        }
    }
}
