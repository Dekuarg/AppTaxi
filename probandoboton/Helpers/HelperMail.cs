using System.Net;
using System.Net.Mail;
namespace probandoboton.Helpers
{
    public class HelperMail
    {
        private IConfiguration configuration;
        public HelperMail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        private MailMessage ConfigureMail(string destinatario, string mensaje)
        // Armado de como seran los mails que se enviaran(todos seran iguales) y constan de:
        // From: quien lo envia
        // To: para quien va dirigido
        // Subject: El asunto
        // Body: El mensaje que en este caso serian los 5 numeros aleatorios.
        {
            string from = this.configuration.GetValue<string>("MailSettings:user");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(destinatario));
            mail.Subject = "NO RESPONDER A ESTE MAIL";
            mail.Body = mensaje;
            mail.IsBodyHtml = true;
            return mail;
        }

        private void ConfigureSmtp(MailMessage mail)
        // Configuracion del emisor de los mails que se van a generar en este caso seria "aplicaciontaxi4679@gmail.com".
        // Esta informacion se encuentra en appsettings.json.
        {
            string user =
                this.configuration.GetValue<string>("MailSettings:user");
            string password =
                this.configuration.GetValue<string>("MailSettings:password");
            string host =
                this.configuration.GetValue<string>("MailSettings:host");

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Host = host;
            NetworkCredential credentials =
                new NetworkCredential(user, password);
            client.Credentials = credentials;
            client.Send(mail);
        }

        public void SendMail(string destinatario, string mensaje)
        // Metodo que se utiliza para enviar el mail.
        {
            MailMessage mail = this.ConfigureMail(destinatario, mensaje);
            this.ConfigureSmtp(mail);
        }

        public static string devolver()
        {
            //Con esta funcion lo que hacemos es devolver un string con los numeros aleatorios que vamos a utilizar para confirmar el mail y para recuperar contraseña
            int[] vector = new int[5];
            Random rand = new Random();
            for (int i = 0; i < vector.Length; i++) 
            {
                vector[i] = rand.Next(1, 10);
            }
            string newtext = String.Join(", ", vector);
            return newtext;
        }
    }
}
