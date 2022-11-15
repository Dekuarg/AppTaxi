namespace probandoboton.Models
{
    public class CorreoOnly
    {

        public string Destinatario { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Destinatario))
                return false;

            return true;
        }
    }
}
