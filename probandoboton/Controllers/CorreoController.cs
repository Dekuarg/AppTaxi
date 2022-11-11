using Microsoft.AspNetCore.Mvc;
using probandoboton.Helpers;

namespace probandoboton.Controllers
{
    public class CorreoController : Controller
        //Controlador utilizado para generar el envio de un correo al usuario 
        // para confirmar su mail y para recuperar contraseña
    {
        private string areglorandom = HelperMail.devolver();
        public IActionResult Index()
        {
            return View();
        }
        private HelperMail helpermail;
        public CorreoController(HelperMail helpermail)
        {
            this.helpermail = helpermail;
        }
        [HttpPost]
        public IActionResult Index([FromBody] string receptor, string texto)
        {
            string mensajefinal = "ingrese este codigo en su aplicacion" + areglorandom;
            this.helpermail.SendMail(receptor, mensajefinal);
            return Ok("okaaaa");
        }

        [HttpPost]
        // Metodo utilizado para comparar el codigo enviado al usuario con el que coloca en la aplicacion

        public IActionResult Compare([FromBody] int[] arreglo)
        {
            char[] newarray;
            string Numbercompare = areglorandom;
            newarray = Numbercompare.ToCharArray();
            int[] arraypass = newarray.Select(x => Convert.ToInt32(x)).ToArray();
            if (arreglo.SequenceEqual(arraypass))
            {
                return Ok("Comparacion Correcta");
            }
            else
            {
                return BadRequest("no son el mismo numero");
            }

        }
    }
}
