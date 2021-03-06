﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;

namespace AltivaWebApp.Repositories
{
    public class TipoClienteRepository : BaseRepository<TbFdTipoCliente>, ITipoClienteRepository
    {
        public TipoClienteRepository(EmpresasContext context) : base(context)
        {
        }
        //devuelve un tipo de cliente
        public TbFdTipoCliente GetById(int idTipoCliente)
        {
            var model = context.TbFdTipoCliente.FirstOrDefault(tc => tc.Id == idTipoCliente);
            if (model.IdTipoPrecio != 0)
            {
                model.IdTipoPrecioNavigation = context.TbPrPrecios.FirstOrDefault(p => p.Id == model.IdTipoPrecio);
            }

            return model;
        }
        //devuelve todos las familia de los tipos de clientes
        public IList<TbFdTipoCliente> GetFamiliaTipoCliente(int IdTipoCLiente)
        {
            return context.TbFdTipoCliente.Where(a => a.IdPadre == IdTipoCLiente).ToList();
        }
        //devuelve todos las subfamilia de las familias
        public IList<TbFdTipoCliente> GetSubFamilia(int IdTipoCliente)
        {
            return context.TbFdTipoCliente.Where(a => a.IdPadre == IdTipoCliente).ToList();
        }

        //devuelve todos los tipos de cliente
        public IList<TbFdTipoCliente> GetTipoCliente()
        {
            return context.TbFdTipoCliente.Where(a => a.IdPadre == 0).ToList();
        }


    }
}
