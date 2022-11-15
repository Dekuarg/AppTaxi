using Microsoft.AspNetCore.Mvc;
using probandoboton.Models;
using probandoboton.Encriptacion;
using MySqlX.XDevAPI;

namespace probandoboton.Controllers
{
    public class AccessController : Controller
    //Controlador que utilizamos para el registro de usuario y su login.
    {
        private readonly ApplicationUser _auc;

        public AccessController(ApplicationUser auc)
        {
            _auc = auc;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create([FromBody] UserRegister uc)
        {
            if (!uc.IsValid())
                return NotFound();

            User oUser = new User();
            oUser.Usuario = uc.Usuario;
            oUser.Email = uc.Email;
            oUser.Clave = uc.Clave;
            oUser.Token = null;
            bool success = false;
            if (!string.IsNullOrEmpty(uc.Clave))
            {
                success = true;
                oUser.Token = GenerateToken.Token(oUser);
                oUser.Clave = Encriptados.GetSHA256(uc.Clave);
            }
            else
            {
                return StatusCode(418, "No se pudo crear la clave");
            }
            _auc.Add(oUser);
            _auc.SaveChanges();
            return Ok(success ? "OK" : "ERROR");

        }

        [HttpGet]

        public IActionResult Getlogin([FromBody] UserLogin uc)
        {
            if (!uc.IsValid())
                return NotFound();

            if (!string.IsNullOrEmpty(uc.Clave))
            {
                uc.Clave = Encriptados.GetSHA256(uc.Clave);
            }
            var usuario = _auc.prueba.Where(s => s.Usuario == uc.Usuario && s.Clave == uc.Clave);

            if (usuario.Any())
            {
                return Ok("Login Exitoso");
            }
            else
            {
                return Unauthorized("Login Incorrecto");
            }
        }

        [HttpPost]

        public IActionResult ResetearPass([FromBody] User uc)
        {
            if (uc.Email == null) { return BadRequest("Usuario no Encontrado"); }

            if (string.IsNullOrEmpty(uc.Clave))
            {
                uc.Clave = Encriptados.GetSHA256(uc.Clave);
            }

            var reseteo = _auc.prueba.Where(s => s.Email == uc.Email).FirstOrDefault();



            if (reseteo != null)
            {

                reseteo.Clave = Encriptados.GetSHA256(uc.Clave);
                _auc.prueba.Update(reseteo);
                _auc.SaveChanges();

                return Ok("Cambio Exitoso");
            }
            else
            {
                return BadRequest("Cambio Fallido");
            }
        }
    }
}
