using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Context;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;
namespace AltivaWebApp.Repositories
{
    public class MensajeRepository : BaseRepositoryGE<TbSeMensaje>, IMensajeRepository
    {

        public MensajeRepository(GrupoEmpresarialContext context)
           : base(context)
        {

        }

        
public List<MensajeRecibidoViewModel> Recibido(int id)
{
   var model = (from us in context.TbSeUsuario join me in context.TbSeMensaje on us.Id equals me.IdUsuario
                join a in context.TbSeAdjunto on me.Id equals a.IdMensaje
                join mr in context.TbSeMensajeReceptor on me.Id equals mr.IdMensaje
                where mr.IdReceptor == id && mr.Estado != "Archivado" && mr.Estado != "Eliminado" && me.Tipo == "ME"  orderby mr.IdMensaje descending
                select new MensajeRecibidoViewModel
                {
                    
                    Id = mr.Id,
                    IdMensaje = me.Id,
                    Mensaje = me.Mensaje,
                   Estado = mr.Estado,
                   ruta = a.Ruta,
        
                    UsuarioEmisor = us.Nombre

                }).ToList();

   return model;
}
        
        public List<MensajeRecibidoViewModel> Enviados(int id)
        {
            var model = (from us in context.TbSeUsuario
                         join me in context.TbSeMensaje on us.Id equals me.IdUsuario
                         join a in context.TbSeAdjunto on me.Id equals a.IdMensaje
                         join mr in context.TbSeMensajeReceptor on me.Id equals mr.IdMensaje
                         join u in context.TbSeUsuario on mr.IdReceptor equals u.Id
                         where me.IdUsuario == id
                         select new MensajeRecibidoViewModel
                         {
                             Id = mr.Id,
                             Mensaje = me.Mensaje,
                             Estado = mr.Estado,
                             ruta = a.Ruta,
                             UsuarioEmisor = us.Nombre,
                             UsuarioReceptor = u.Nombre
                         }).ToList();

            return model;
        }

        public List<MensajeRecibidoViewModel> Archivados(int id)
        {
            var model = (from us in context.TbSeUsuario
                         join me in context.TbSeMensaje on us.Id equals me.IdUsuario
                         join a in context.TbSeAdjunto on me.Id equals a.IdMensaje
                         join mr in context.TbSeMensajeReceptor on me.Id equals mr.IdMensaje
                         join u in context.TbSeUsuario on mr.IdReceptor equals u.Id
                         where me.IdUsuario == id && mr.Estado == "Archivado" 
                         select new MensajeRecibidoViewModel
                         {
                             Id = mr.Id,
                             Mensaje = me.Mensaje,
                             Estado = mr.Estado,
                             ruta = a.Ruta,
                             UsuarioEmisor = us.Nombre,
                             UsuarioReceptor = u.Nombre
                         }).ToList();

            return model;
        }

        public int Contador(int id)
        {
            int contador = 0;
            var model = (from us in context.TbSeUsuario
                         join me in context.TbSeMensaje on us.Id equals me.IdUsuario
                         join a in context.TbSeAdjunto on me.Id equals a.IdMensaje
                         join mr in context.TbSeMensajeReceptor on me.Id equals mr.IdMensaje
                         where mr.IdReceptor == id && mr.Estado == "NoLeido"
                         select new MensajeRecibidoViewModel
                         {
                             Id = mr.Id,
                             Mensaje = me.Mensaje,
                             Estado = mr.Estado,
                             ruta = a.Ruta,

                             UsuarioEmisor = us.Nombre

                         }).ToList();
            foreach (var item in model)
            {
                contador = contador + 1;
            }
            return contador;
        }

        public List<MensajeRecibidoViewModel> FilterByName(int id,string valor)
        {

            var we = (from p in context.TbSeUsuario
                         where p.Codigo.Contains(valor) && p.IdUsuario == id
                         select new MensajeRecibidoViewModel
                         {
              
                             UsuarioReceptor = p.Codigo,
                             IdUsuarioReceptor =p.Id
                         }).ToList();
            
            return we;
        }

        public List<MensajeRecibidoViewModel> Ver(int id)
        {
        
             var model = (from us in context.TbSeUsuario
                                join me in context.TbSeMensaje on us.Id equals me.IdUsuario
                                join a in context.TbSeAdjunto on me.Id equals a.IdMensaje
                                join mr in context.TbSeMensajeReceptor on me.Id equals mr.IdMensaje
                                where mr.Id == id 
                                select new MensajeRecibidoViewModel
                                {
                                  
                                    Mensaje = me.Mensaje,
                     
                                    ruta = a.Ruta,


                                }).ToList();
            return model;

        }

        public List<MensajeRecibidoViewModel> BuscarNombre(int id)
        {
            var model = (from us in context.TbSeUsuario
                        
                         where us.Id == id
                         select new MensajeRecibidoViewModel
                         {

                            UsuarioReceptor = us.Codigo


                         }).ToList();
            return model;
        }

        public List<MensajeRecibidoViewModel> GetComentarios(ComentarioViewModel comentario)
        {
            return (from us in context.TbSeUsuario
                         join me in context.TbSeMensaje on us.Id equals me.IdUsuario
                         join a in context.TbSeAdjunto on me.Id equals a.IdMensaje
                         where me.IdReferencia == comentario.IdReferencia && me.TipoReferencia == comentario.TipoReferencia && me.Estado != "Eliminar"
                         select new MensajeRecibidoViewModel
                         {
                             IdMensaje = me.Id,
                             Mensaje = me.Mensaje,
                             ruta = a.Ruta,
                             UsuarioEmisor = us.Nombre,
                             tipoReferencia = me.TipoReferencia
                         }).ToList();
            
        }

        public List<MensajeRecibidoViewModel> VerComentarios(int id)
        {
            var model = (from us in context.TbSeUsuario
                         join me in context.TbSeMensaje on us.Id equals me.IdUsuario
                         join a in context.TbSeAdjunto on me.Id equals a.IdMensaje
                         where me.Id == id 
                         select new MensajeRecibidoViewModel
                         {

                             Mensaje = me.Mensaje,

                             ruta = a.Ruta,


                         }

     ).ToList();
            return model;
        }

        public List<MensajeRecibidoViewModel> VerComentariosUsuarios(int id)
        {
            var model = (from us in context.TbSeUsuario
                         join me in context.TbSeMensaje on us.Id equals me.IdUsuario
                         join a in context.TbSeAdjunto on me.Id equals a.IdMensaje
                         where me.IdReferencia == id && me.TipoReferencia == "Usuario" && me.Estado != "Eliminar"
                         select new MensajeRecibidoViewModel
                         {


                             IdMensaje = me.Id,
                             Mensaje = me.Mensaje,
                             ruta = a.Ruta,
                             UsuarioEmisor = us.Nombre,
                             tipoReferencia = me.TipoReferencia
                         }

     ).ToList();
            return model;
        }

        public TbSeMensaje Consultar(int id)
        {


            return this.context.TbSeMensaje.SingleOrDefault(u => u.Id == id);
        }
    }
}
