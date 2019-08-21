using AltivaWebApp.Context;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using AltivaWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AltivaWebApp.Repositories
{
    public class UserRepository : BaseRepositoryGE<TbSeUsuario>, IUserRepository

    {

        public UserRepository(GrupoEmpresarialContext context)
             : base(context)
        {
        }

        public IList<TbSeUsuario> GetAllById(int id)
        {

            return context.TbSeUsuario.Where(u => u.IdUsuario == id).ToList();

        }



        public bool ExisteUsuarioPorCodigo(string codigo)
        {
            return context.TbSeUsuario.Any(u => u.Codigo == codigo);
        }

        public bool ExisteUsuarioPorCorreo(string correo)
        {
            return context.TbSeUsuario.Any(u => u.Correo == correo);
        }
        public TbSeUsuario GetUsuarioById(int id)
        {

            //return context.TbSeUsuario.Include(p => p.TbSePerfilUsuario).ThenInclude(pu => pu.IdPerfilNavigation).SingleOrDefault(u=>u.Id == id);
            return context.TbSeUsuario.FirstOrDefault(u => u.Id == id);
            // return context.TbSeUsuario.
        }

        public TbSeUsuario GetUsuarioConConfig(string usuario)
        {
            return context.TbSeUsuario.Include(u => u.TbSePerfilUsuario).ThenInclude(p => p.IdPerfilNavigation).Include(u => u.TbSeUsuarioConfiguraion).FirstOrDefault(u => u.Codigo == usuario || u.Correo == usuario);
        }


        public TbSeUsuario GetUsuarioConEmpresas(string usuario)
        {
            return context.TbSeUsuario.Include(c => c.TbSeUsuarioConfiguraion).Include(ge => ge.TbGeGrupoEmpresarial)
                .Include(em => em.TbSeEmpresaUsuario)
                .ThenInclude(em => em.IdEmpresaNavigation)
                .FirstOrDefault(u => u.Correo == usuario || u.Codigo == usuario);
            // return context.TbSeUsuario.
        }

        public TbSeUsuario GetUsuarioConPerfiles(string usuario)
        {
            return context.TbSeUsuario.Include(p => p.TbSePerfilUsuario).ThenInclude(pu => pu.IdPerfilNavigation)
                .FirstOrDefault(u => u.Correo == usuario || u.Codigo == usuario);
            // return context.TbSeUsuario.
        }

        public TbSeUsuario GetUsuarioConPerfilesById(int id)
        {
            return context.TbSeUsuario.Include(p => p.TbSePerfilUsuario).ThenInclude(pu => pu.IdPerfilNavigation)
                .FirstOrDefault(u => u.Id == id);
            // return context.TbSeUsuario.
        }

        public IEnumerable<TbSePerfil> GetPerfiles(int id)
        {
            //var user = context.TbSeUsuario.Where(u => u.Correo == usuario || u.Codigo == usuario).FirstOrDefault();


            var perfiles = context.TbSePerfil.Include(p => p.TbSePerfilUsuario)
                .Where(p => p.TbSePerfilUsuario.Any(u => u.IdUsuario == Convert.ToInt64(id)))
                .ToList();

            return perfiles;
        }

        public TbSeEmpresaUsuario CreateEmpresaUsuarioRel(TbSeEmpresaUsuario domain)
        {
            try
            {
                context.TbSeEmpresaUsuario.Add(domain);
                context.SaveChanges();
                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return null;
                throw;
            }
        }

        public TbSeUsuarioConfiguraion CreateOrUpdateConfiguracion(TbSeUsuarioConfiguraion domain)
        {
            try
            {
                var model = GetUConfiguracion((int)domain.IdUsuario);
                if (model != null)
                {
                    model.Idioma = domain.Idioma;
                    model.Tema = domain.Tema;
                    context.Update(model);
                }
                else
                {
                    context.TbSeUsuarioConfiguraion.Add(domain);
                }

                context.SaveChanges();
                return domain;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        private bool CompruebaConfiguracion(int idUsuario)
        {
            return context.TbSeUsuarioConfiguraion.Any(c => c.IdUsuario == idUsuario);
        }

        public TbSeUsuarioConfiguraion GetUConfiguracion(int idUsuario)
        {
            try
            {
                return context.TbSeUsuarioConfiguraion.FirstOrDefault(uc => uc.IdUsuario == idUsuario);
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }

        }


        public TbSeUsuario SaveUser(TbSeUsuario domain)
        {

            var userIdentity = new TbSeUsuario
            {
                Codigo = domain.Codigo,
                Nombre = domain.Nombre,
                Estado = domain.Estado,
                Iniciales = domain.Iniciales,
                Contrasena = domain.Contrasena,
                FechaMod = DateTime.Now,
                IdUsuario = domain.IdUsuario,
                Correo = domain.Correo
            };

            var result = context.TbSeUsuario.Add(userIdentity);

            if (!result.IsKeySet)
                return null;

            else
            {

                base.context.SaveChanges();

                return userIdentity;
            }



        }


        public bool CreatePerfilUsuario(IList<TbSePerfilUsuario> domain)
        {
            try
            {
                context.TbSePerfilUsuario.AddRange(domain);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                return false;
                throw;
            }

        }

        public TbSePerfilUsuario GetPerfilUsuario(PerfilUsuarioViewModel model)
        {
            return context.TbSePerfilUsuario.Include(u => u.IdUsuarioNavigation).FirstOrDefault(pu => pu.IdUsuario == model.IdUsuario && pu.IdPerfil == model.IdPerfil);
        }

        public bool DeletePU(TbSePerfilUsuario model)
        {
            try
            {
                //var model = context.TbSePerfilUsuario.FirstOrDefault(pu => pu. == id);
                context.Remove(model);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;

            }
        }

        public IList<TbSeUsuario> GetAllByIdEmpresa(int idEmpresa)
        {
            return (from eu in context.TbSeEmpresaUsuario
                    join u in context.TbSeUsuario on eu.IdUsuario equals u.Id
                    join e in context.TbGeEmpresa on eu.IdEmpresa equals e.Id
                    where e.Id == idEmpresa
                    select new TbSeUsuario
                    {
                        Id = u.Id,
                        Avatar = u.Avatar,
                        Codigo = u.Codigo,
                        Contrasena = u.Contrasena,
                        Correo = u.Correo,
                        Estado = u.Estado,
                        FechaMod = u.FechaMod,
                        IdUsuario = u.IdUsuario,
                        Iniciales = u.Iniciales,
                        Nombre = u.Nombre
                    }
                    ).ToList();

        }

        public IList<TbSeUsuario> GetAllByIdEmpresaConPerfiles(int idEmpresa)
        {

            return context.TbSeUsuario.Include(p => p.TbSePerfilUsuario).ThenInclude(pu => pu.IdPerfilNavigation)
                .Where(u => u.TbSeEmpresaUsuario.Any(e => e.IdEmpresa == idEmpresa) == true).ToList();
        }
        public IList<TbSePerfilModulo> GetAllPerfilModulo()
        {
            try
            {
                return context.TbSePerfilModulo.Where(u => u.Opcion1 == true).ToList();

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public IList<TbSePerfilUsuario> GetAllPerfilUsuario()
        {
            try
            {
                return context.TbSePerfilUsuario.ToList();

            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }

        public IList<TbSeUsuario> GetAllByIdUsuario(int id)
        {
            return context.TbSeUsuario.Where(u => u.IdUsuario == id).ToList();
        }

        public IList<TbGeEmpresa> GetEmpresasPorUsuario(int idUsuario)
        {
            return context.TbGeEmpresa.Include(r => r.TbSeEmpresaUsuario)
                    .Select(e => new TbGeEmpresa
                    {
                        Id = e.Id,
                        CedJuridica = e.CedJuridica,
                        Estado = e.Estado,
                        Nombre = e.Nombre,
                        TbSeEmpresaUsuario = e.TbSeEmpresaUsuario.Where(us => us.IdUsuario == idUsuario).Select(u => new TbSeEmpresaUsuario
                        {
                            IdEmpresa = u.IdEmpresa,
                            Estado = u.Estado,
                            Id = u.Id,
                            IdUsuario = u.IdUsuario
                        }).ToList()

                    }).ToList();
        }

        public IList<TbSeUsuario> GetAllConEmpresas()
        {
            return context.TbSeUsuario.Include(u => u.TbSeEmpresaUsuario).Select(u =>
                new TbSeUsuario
                {
                    Avatar = u.Avatar,
                    Codigo = u.Codigo,
                    Contrasena = u.Contrasena,
                    Correo = u.Correo,
                    Estado = u.Estado,
                    FechaMod = u.FechaMod,
                    Id = u.Id,
                    IdUsuario = u.IdUsuario,
                    Iniciales = u.Iniciales,
                    Nombre = u.Nombre,
                    TbSeEmpresaUsuario = u.TbSeEmpresaUsuario.Select(e => new TbSeEmpresaUsuario
                    {
                        IdEmpresa = e.IdEmpresa,
                        Estado = e.Estado,
                        Id = e.Id,
                        IdUsuario = e.IdUsuario
                    }).ToList()

                }).ToList();
        }


        public bool CrearRelEmpresaUsuario(IList<TbSeEmpresaUsuario> domain)
        {
            try
            {
                context.TbSeEmpresaUsuario.AddRange(domain);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");

                throw;
            }
        }

        public bool DesactivarRelEmpresaUsuario(IList<TbSeEmpresaUsuario> domain)
        {
            try
            {
                context.TbSeEmpresaUsuario.UpdateRange(domain);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                AltivaLog.Log.Insertar(ex.ToString(), "Error");
                throw;
            }
        }   

    }
}
