using AltivaWebApp.Context;
using AltivaWebApp.GEDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public class GERepository : BaseRepositoryGE<TbGeEmpresa>, IGERepository
    {

        public GERepository(GrupoEmpresarialContext context)
            : base(context)
        {

        }

        public bool CrearBD(string nombre)
        {
            try
            {
                var conf = new ConfigurationBuilder()
                .SetBasePath(Startup.entorno.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();

                var p = conf["rutaPlantilla"];

                SqlParameter param = new SqlParameter("@NombreBd", nombre);
                SqlParameter param2 = new SqlParameter("@rutaRoot", conf["rutaPlantilla"]);
                SqlParameter param3 = new SqlParameter("@plantillaBD", conf["nombrePlantillaBD"]);

                context.Database.ExecuteSqlCommand("pr_GE_CrearEmpresaBD @NombreBd, @rutaRoot, @plantillaBD", param, param2, param3);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool AgregarUsuarios(int idEmpresa)
        {
            try
            {
                var usuarios = context.TbSeUsuario.ToList();

                var ue = new List<TbSeEmpresaUsuario>();

                foreach (var item in usuarios)
                {
                    ue.Add(new TbSeEmpresaUsuario
                    {
                        Estado = true,
                        IdEmpresa = idEmpresa,
                        IdUsuario = item.Id
                    });
                }

                context.TbSeEmpresaUsuario.AddRange(ue);
                context.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }

        public TbGeGrupoEmpresarial GetGE()
        {
            return context.TbGeGrupoEmpresarial.FirstOrDefault();
        }

        public TbGeEmpresa GetEmpresaById(int id)
        {
            return context.TbGeEmpresa.FirstOrDefault(e => e.Id == id);
        }

        public TbGeEmpresa GetEmpresaByNombre(string nombre)
        {
            return context.TbGeEmpresa.FirstOrDefault(e => e.Nombre == nombre);
        }

        public IList<TbGeEmpresa> GetAllByUsuario(int id)
        {
            var model = (from eu in context.TbSeEmpresaUsuario
                         join e in context.TbGeEmpresa on eu.IdEmpresa equals e.Id
                         join u in context.TbSeUsuario on eu.IdUsuario equals u.Id
                         where eu.IdUsuario == id
                         select new TbGeEmpresa
                         {
                             Id = e.Id,
                             Bd = e.Bd,
                             CedJuridica = e.CedJuridica,
                             Correo = e.Correo,
                             Direccion = e.Direccion,
                             Estado = e.Estado,
                             FechaCreacion = e.FechaCreacion,
                             FechaMod = e.FechaMod,
                             IdGrupoEmpresarial = e.IdGrupoEmpresarial,
                             Nombre = e.Nombre,
                             Foto = e.Foto,
                             Telefono1 = e.Telefono1,
                             Telefono2 = e.Telefono2
                         }
                         ).ToList();
            return model;
        }

        public TbGeEmpresa GetByCedula(string cedula)
        {
            return context.TbGeEmpresa.FirstOrDefault(e => e.CedJuridica == cedula);
        }

        public bool EliminarEmpresa(TbGeEmpresa domain)
        {
            try
            {
                var empresas = context.TbSeEmpresaUsuario.Where(e => e.IdEmpresa == domain.Id);
                context.TbSeEmpresaUsuario.RemoveRange(empresas);
                context.TbGeEmpresa.Remove(domain);

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }



    }
}
