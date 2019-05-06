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
        public TbCrContacto GetTareas(int idContacto)
        {
            return context.TbCrContacto
              .Include(c => c.TbFdTarea).ThenInclude(c => c.IdTipoNavigation).Include(c => c.TbFdTarea).
              ThenInclude(c => c.IdEstadoNavigation)
              .FirstOrDefault(c => c.IdContacto == idContacto);
        }
        public IList<TbCrContacto> GetAllEmpresas()
        {
            return context.TbCrContacto.Where(u => u.Empresa == true).ToList();
        }

        public IList<TbCrContacto> GetAllPersonas()
        {
            return context.TbCrContacto.Where(u => u.Persona == true).ToList();
        }

        public TbCrContacto GetByCedulaContacto(string cedula)
        {
            TbCrContacto con = new TbCrContacto();

            con = context.TbCrContacto.Where(cont => cont.Cedula == cedula).FirstOrDefault();

            return con;
        }

        public ContactoViewModel GetByEdit(int id)
        {
            ContactoViewModel sd = new ContactoViewModel();
     
            var model = (from con in context.TbCrContacto  
                         where con.IdContacto == id

                         select new ContactoViewModel
                         {
                             Id = con.IdContacto,
                             Nombre = con.Nombre,
                             Apellidos = con.Apellidos,
                             NombreComercial = con.NombreComercial,
                             NombreJuridico = con.NombreJuridico,
                             TipoCedula = con.TipoCedula,
                             Cedula = con.Cedula,
                             Telefono = con.Telefono,
                             Correo = con.Correo,
                             Pais = con.Pais,
                             
                             Persona = con.Persona,
                             Empresa = con.Empresa,
                             Provincia = con.Provincia,
                             Canton = con.Canton,
                             Distrito = con.Distrito,
                             OtrasSenas = con.OtrasSenas,
                            Cliente = con.Cliente,
                            Proveedor = con.Proveedor,
                            juridica = con.Cedula,
                            dimex = con.Cedula,
                            nite = con.Cedula,
                            IdUsuario = con.IdUsuario,
                            WebLink = con.WebLink,
                            MapLink = con.MapLink

                            
                         }

     ).FirstOrDefault();
            if (model.IdUsuario.Equals(null))
            {
                model.IdUsuario = 0;
            }
                if (model.TipoCedula == "CedulaFisica")
            {
                model.dimex = "";
                model.nite = "";
                model.juridica = "";

            }else if (model.TipoCedula == "CedulaJuridica")
            {
                model.Cedula = "";
                model.dimex = "";
                model.nite = "";
            }else if (model.TipoCedula == "Dimex")
            {
                model.Cedula = "";
                model.nite = "";
                model.juridica = "";
            }else if (model.TipoCedula == "NITE")
            {
                model.Cedula = "";
                model.dimex = "";
                model.juridica = "";
            }
            return model;
        }

        public TbCrContacto GetByEmailContacto(string correo)
        {
            try
            {
                TbCrContacto con = new TbCrContacto();

                con = context.TbCrContacto.Where(i => i.Correo == correo).FirstOrDefault();
                return con;
            }
            catch
            {
                throw;
            }
        
        }

        public ContactoViemModelDetalle getById(int id)
        {
            TbCrContacto con = new TbCrContacto();

            con = context.TbCrContacto.Where(cont => cont.IdContacto == id).FirstOrDefault();
            ContactoViemModelDetalle detalle = new ContactoViemModelDetalle();
            TbCeCanton canton;
            TbCeDistrito distrito;
            TbCeProvincias provincias;
            canton = context.TbCeCanton.Where(u => u.IdProvincia == con.Provincia && u.IdCanton == con.Canton).FirstOrDefault();
            distrito = context.TbCeDistrito.Where(u => u.IdProvincia == con.Provincia && u.IdCanton == con.Canton && u.IdDistrito == con.Distrito).FirstOrDefault();
            provincias = context.TbCeProvincias.Where(u => u.IdProvincia == con.Provincia).FirstOrDefault();
            if (con.Provincia != null)
            {


                detalle.Nombre = con.Nombre;
                detalle.Apellidos = con.Apellidos;
                detalle.TipoCedula = con.TipoCedula;
                detalle.Cedula = con.Cedula;
                detalle.NombreComercial = con.NombreComercial;
                detalle.NombreJuridico = con.NombreJuridico;
                detalle.Correo = con.Correo;
                detalle.Telefono = con.Telefono;
                detalle.Pais = con.Pais;
                detalle.Canton = canton.DescCanton;
                detalle.Distrito = distrito.DescDistrito;
                detalle.Provincia = provincias.DescProvincia;
                detalle.Persona = con.Persona;
                detalle.Empresa = con.Empresa;
                detalle.Cliente = con.Cliente;
                detalle.Proveedor = con.Proveedor;
                detalle.Id = Convert.ToInt32( con.IdContacto);
                detalle.OtrasSenas = con.OtrasSenas;
            }
            else
            {
                detalle.Nombre = con.Nombre;
                detalle.Apellidos = con.Apellidos;
                detalle.TipoCedula = con.TipoCedula;
                detalle.Cedula = con.Cedula;
                detalle.NombreComercial = con.NombreComercial;
                detalle.NombreJuridico = con.NombreJuridico;
                detalle.Correo = con.Correo;
                detalle.Telefono = con.Telefono;
                detalle.Pais = con.Pais;
                detalle.Persona = con.Persona;
                detalle.Empresa = con.Empresa;
                detalle.Cliente = con.Cliente;
                detalle.Proveedor = con.Proveedor;
                detalle.Id = Convert.ToInt32(con.IdContacto);
                detalle.OtrasSenas = con.OtrasSenas;

            }
            return detalle;
        }

        public TbCrContacto GetByIdContacto(long id)
        {
            return context.TbCrContacto.Where(u => u.IdContacto == id).FirstOrDefault();
        }

        public IList<TbCeCanton> GetCantones(int idProvincia)
        {
            return context.TbCeCanton.Where(u => u.IdProvincia == idProvincia).ToList();

        }

        public IList<ContactoRelacionGETViewModel> GetContactosRelacion(int id)
        {
            var model = (from con in context.TbCrContacto join cr in context.TbCrContactoRelacion
                         on con.IdContacto equals cr.IdContactoHijo
                         where cr.IdContactoPadre == id
                       

                         select new ContactoRelacionGETViewModel
                         {
                            NotaRelacion = cr.NotaRelacion,
                            Nombre = con.Nombre,
                            Cedula = con.Cedula,
                            NombreComercial = con.NombreComercial,
                            IdContactoHijo = con.IdContacto,
                            Id = cr.Id
                           

                         }

      ).ToList();
            return model;
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
