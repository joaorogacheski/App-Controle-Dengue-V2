using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Web.Hosting;
using System.IO;

namespace ControleDengue.Controllers
{
    public class EmailDAO
    {

        public async static Task MandarEmailAsync(string email, string assunto, string mensagem)
        {
            try
            {
                var _email = "vitorjoao2112@hotmail.com";
                var _senha = ConfigurationManager.AppSettings["EmailPassword"];
                var _displayName = "APP Controle Dengue";
                MailMessage minhaMensagem = new MailMessage();
                minhaMensagem.To.Add(email);
                minhaMensagem.From = new MailAddress(_email, _displayName);
                minhaMensagem.Subject = assunto;
                minhaMensagem.Body = mensagem;
                minhaMensagem.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.live.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_email, _senha);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.SendCompleted += (s, e) => { smtp.Dispose(); };
                    await smtp.SendMailAsync(minhaMensagem);

                }


            }

            catch (Exception e)
            {
                throw e;
            }
        }


        public static async Task<String> EmailTemplate(string template)
        {
            var templateFilePath = HostingEnvironment.MapPath("~/Content/templates/") + template + ".cshtml";
            StreamReader objstreamreaderfile = new StreamReader(templateFilePath);
            var body = await objstreamreaderfile.ReadToEndAsync();
            return body;

        }
    }
}