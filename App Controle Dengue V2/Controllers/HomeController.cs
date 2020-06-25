using App_Controle_Dengue_V2.DAL;
using App_Controle_Dengue_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace App_Controle_Dengue_V2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txtNomeUsuario, string txtSenha)
        {
            Usuario usuario = UsuarioDAO.Login(txtNomeUsuario, txtSenha);
            if (usuario != null)
            {
                //Autenticação - FormsAuthentication
                FormsAuthentication.SetAuthCookie(usuario.NomeUsuario, true);
                //Sessao.Login(usuario.Email);
                return RedirectToAction("Index", "Denuncia");
            }
            ModelState.AddModelError("", "Login ou senha incorretos!");
            return View(usuario);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult EnviaEmail()
        {
            string emailDestinatario = Request.Form["txtEmail"];
            SendMail(emailDestinatario);
            return RedirectToAction("Index", "Denuncia");
        }

        public bool SendMail(string email)
        {
            try
            {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();
                // Remetente
                _mailMessage.From = new MailAddress("joaorogac@gmail.com");

                // Destinatario seta no metodo abaixo

                //Contrói o MailMessage
                _mailMessage.CC.Add(email);
                _mailMessage.Subject = "Alerta Controle Dengue";
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = "<b>Olá, os casos para está região estão aumentando!</b><p>Gostariamos de contactar que os casos de dengue estão aumentando na região!</p>";

                //CONFIGURAÇÃO COM PORTA
                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

                //CONFIGURAÇÃO SEM PORTA
                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
                _smtpClient.UseDefaultCredentials = false;

                _smtpClient.Credentials = new NetworkCredential("email", "senha");

                _smtpClient.EnableSsl = true;

                _smtpClient.Send(_mailMessage);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
