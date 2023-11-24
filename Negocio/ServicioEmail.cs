using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ServicioEmail
    {
        private MailMessage email;
        private SmtpClient server;

        public ServicioEmail() {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("6f4c9c756e2e87", "6afde5b7709b3e");
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "sandbox.smtp.mailtrap.io";
            }
        public void armarCorreo(string emailDestino, string asunto, string cuerpo) 
        {
        email = new MailMessage();
            email.From= new MailAddress("noresponder@jpsalud");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;

        }
        public void enviarMail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
