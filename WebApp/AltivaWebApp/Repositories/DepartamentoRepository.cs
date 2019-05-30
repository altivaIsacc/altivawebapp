using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class DepartamentoRepository: BaseRepository<TbPrDepartamento>, IDepartamentoRepository
    {
        public DepartamentoRepository (EmpresasContext context) : base(context)
        {

        }

        public TbPrDepartamento GetDepartamentoById(int id)
        {
            return context.TbPrDepartamento.FirstOrDefault(d => d.Id == id);
        }

        public IList<TbPrDepartamento> GetDepartamentoWithReqs()
        {
            return context.TbPrDepartamento.Include(r => r.TbPrRequisicion).ToList();
        }

        public IList<TbPrDepartamento> GetDepartamentosSinAnular()
        {
            return context.TbPrDepartamento.Where(d => d.Anulado == false).ToList();
        }

        public TbPrDepartamento GetDepartamentoByDesc(string desc)
        {
            return context.TbPrDepartamento.FirstOrDefault(d => d.Descripcion.ToLower() == desc.ToLower());
        }



    }
}
