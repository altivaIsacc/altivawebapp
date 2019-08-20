using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AltivaWebApp.Repositories
{
    public class ContactoRepository : BaseRepository<TbCrContacto>, IContactoRepository
    {
        public ContactoRepository(EmpresasContext context) : base(context)
        {
        }


        public IList<TbFdTarea> GetTareas(int idContacto)
        {
            //return context.TbCrContacto
            //  .Include(c => c.TbFdTarea).ThenInclude(c => c.IdTipoNavigation).Include(c => c.TbFdTarea).
            //  ThenInclude(c => c.IdEstadoNavigation)
            //  .FirstOrDefault(c => c.IdContacto == idContacto);

            return context.TbFdTarea.Include(t => t.IdTipoNavigation).Include(t => t.IdEstadoNavigation).Where(t => t.IdContacto == idContacto).ToList();
        }
        public IList<TbCrContacto> GetAllEmpresas()
        {
            return context.TbCrContacto.Where(u => u.Empresa == true).ToList();
        }

        public IList<TbCrContacto> GetAllPersonas()
        {
            return context.TbCrContacto.Where(u => u.Persona == true).ToList();
        }

        public IList<TbCrContacto> GetAllProveedores()
        {
            try
            {
                return context.TbCrContacto.Where(c => c.Proveedor == true).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public IList<TbCrContacto> GetAllClientes()
        {
            try
            {
                return context.TbCrContacto.Where(c => c.Cliente == true).ToList();
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public TbCrContacto GetByCedulaContacto(string cedula)
        {
            TbCrContacto con = new TbCrContacto();

            con = context.TbCrContacto.AsNoTracking().Where(cont => cont.Cedula == cedula).FirstOrDefault();

            return con;
        }


        public TbCrContacto GetByEmailContacto(string correo)
        {
            try
            {
                TbCrContacto con = new TbCrContacto();

                con = context.TbCrContacto.Where(i => i.Correo == correo).FirstOrDefault();
                return con;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }


        public TbCrContacto GetByIdContacto(long id)
        {
            return context.TbCrContacto.AsNoTracking().Where(u => u.IdContacto == id).FirstOrDefault();
        }

        public IList<TbCeCanton> GetCantones(int idProvincia)
        {
            return context.TbCeCanton.Where(u => u.IdProvincia == idProvincia).ToList();

        }

        public IList<TbCrContactoRelacion> GetContactosRelacion(int id)
        {

            return context.TbCrContactoRelacion
                    .Include(c => c.IdContactoHijoNavigation)
                    .Include(c => c.IdContactoPadreNavigation)
                    .Where(c => c.IdContactoHijo == id || c.IdContactoPadre == id).ToList();

            //return (from con in context.TbCrContacto
            //        join cr in context.TbCrContactoRelacion on con.IdContacto equals cr.IdContactoHijo
            //        where cr.IdContactoPadre == id || cr.IdContactoHijo == id

            //        select new TbCrContactoRelacion
            //        {
            //            Id = cr.Id,
            //            Estado = cr.Estado,
            //            IdContactoHijo = cr.IdContactoHijo,
            //            IdContactoPadre = cr.IdContactoPadre,
            //            IdContactoHijoNavigation = new TbCrContacto
            //            {
            //                IdContacto = (long)con.TbCrContactoRelacionIdContactoHijoNavigation.FirstOrDefault(c => c.IdContactoPadre == con.IdContacto).IdContactoHijo,
            //                Apellidos = con.Apellidos,
            //                Cedula = con.Cedula,
            //                Empresa = con.Empresa,
            //                Nombre = con.Nombre,
            //                NombreComercial = con.NombreComercial,
            //                NombreJuridico = con.NombreJuridico,
            //                Persona = con.Persona
            //            },
            //            IdContactoPadreNavigation = new TbCrContacto
            //            {
            //                IdContacto = con.IdContacto,
            //                Apellidos = con.Apellidos,
            //                Cedula = con.Cedula,
            //                Empresa = con.Empresa,
            //                Nombre = con.Nombre,
            //                NombreComercial = con.NombreComercial,
            //                NombreJuridico = con.NombreJuridico,
            //                Persona = con.Persona
            //            },
            //            NotaRelacion = cr.NotaRelacion
            //        }).ToList();
        }


        public bool EliminarRelacion(int idRelacion)
        {
            try
            {
                var rel = context.TbCrContactoRelacion.FirstOrDefault(r => r.Id == idRelacion);

                context.TbCrContactoRelacion.Remove(rel);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public IList<TbCeDistrito> GetDistrito(int idCanton, int idProvincia)
        {
            return context.TbCeDistrito.Where(u => u.IdCanton == idCanton && u.IdProvincia == idProvincia).ToList();
        }

        public IList<TbCeProvincias> GetProvincias()
        {
            return context.TbCeProvincias.ToList();

        }
    }
}
