using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Repositories;
using AltivaWebApp.Mappers;
namespace AltivaWebApp.Services
{
    public class EmailSender
    {
        public IUserRepository IUserRepository;
        public IMensajeService ImensajeService;
        public IMensajeReceptor IMensajeReceptorMap;
        public IMensajeReceptorRepository IMensajeReceptorRepository;
        public EmailSender(IUserRepository IUserRepository, IMensajeService ImensajeService, IMensajeReceptor IMensajeReceptorMap, IMensajeReceptorRepository IMensajeReceptorRepository)
        {
            this.IUserRepository = IUserRepository;
            this.ImensajeService = ImensajeService;
            this.IMensajeReceptorMap = IMensajeReceptorMap;
            this.IMensajeReceptorRepository = IMensajeReceptorRepository;
        }
        public  void insertarNotificacion(int idUsuario,string mensaje)
        {
            List<string> id = new List<string>();
       
            List<TbSeUsuario> usuariosAsociados = new List<TbSeUsuario>();
            List<TbSeMensajeReceptor> mensajeReceptor = new List<TbSeMensajeReceptor>();
          
            TbSeMensaje notificacion = new TbSeMensaje(mensaje, "NO", idUsuario);
            TbSeMensaje noti = new TbSeMensaje();
            List<TbSeUsuario> us = new List<TbSeUsuario>();
           IUserRepository.GetAllByIdUsuario(74);
            noti = this.ImensajeService.create(notificacion);
            TbSeMensajeReceptor msj = new TbSeMensajeReceptor();
          
            foreach (var item in IUserRepository.GetAllByIdUsuario(74))
            {
               
                msj = this.IMensajeReceptorMap.Crear(noti.Id, Convert.ToInt32(item.Id));
                mensajeReceptor.Add(msj);

                EmailSender.emailSender(item.Correo, noti.Mensaje, "Mensaje del Sistema Altiva Soluciones Seguridad");
            }

            this.IMensajeReceptorRepository.Crear(mensajeReceptor);

           


            

        }
        public static void emailSender(String direccion, string emailBody, string emailSubject)
        {
            SmtpClient client = new SmtpClient("mail.altivasoluciones.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("asistentesoporte@altivasoluciones.com", "2019+enero");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("asistentesoporte@altivasoluciones.com");
            mailMessage.To.Add(direccion);
            mailMessage.Body = emailBody;
            mailMessage.Subject = emailSubject;
            client.Send(mailMessage);
        }
    }
}
