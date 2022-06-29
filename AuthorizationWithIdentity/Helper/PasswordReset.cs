using System.Net.Mail;
namespace AuthorizationWithIdentity.Helper
{
    public static class PasswordReset
    {
        public static void PasswordResetSendEmail(string link) // link controllerdan gelecek
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("mail.photographybella.com");
            mail.From= new MailAddress("boost@photographybella.com");
            mail.To.Add("hkaban12@gmail.com");
            mail.Subject = $"www.hakan.com :: Şifre Sıfırlama";
            mail.Body = "<h2>Şifrenizi yenilemek için aşağıdaki linke tıklayınız</h2><hr/>";
            mail.Body += $"<a href='{link}' şifre yenileme linki </a>";
            mail.IsBodyHtml = true;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential("boost@photographybella.com", "45526201Co");
            smtpClient.Send(mail);
        }
    }
}
