using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AltivaWebApp.Repositories
{
    public class CentroCostosRepository : BaseRepositoryGE<TbFdUsuarioCosto>, ICentroCostosRepository
    {

        //contructor de llama al context
        public CentroCostosRepository(GrupoEmpresarialContext context) : base(context)
        {
        }
        //devuelve el costo de cada usuario..
        public TbFdUsuarioCosto GetById(int idUsuarioCosto)
        {
           return context.TbFdUsuarioCosto.FirstOrDefault(cont => cont.IdUsuario == idUsuarioCosto);

        }

        public IList<TbSeUsuario> GetUsuarioConCosto()
        {

            return context.TbSeUsuario.Include(c => c.TbFdUsuarioCosto).ToList();

           
        }
    }
}
