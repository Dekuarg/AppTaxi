using Microsoft.AspNetCore.Mvc;
using probandoboton.Models;
using probandoboton.Encriptacion;
using MySqlX.XDevAPI;

namespace probandoboton.Controllers
{
    public class AccessController : Controller
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
    
        public IActionResult Create([FromBody] User uc)
        {
            bool success = false;
            if (!string.IsNullOrEmpty(uc.Clave))
            {
                success = true;
                uc.Token = GenerateToken.Token(uc);
                uc.Clave = Encriptados.ConvertMD5(uc.Clave); 
            }
            else
            {
                return StatusCode(418,"No se pudo crear la clave");
            }
            
            _auc.Add(uc);
            _auc.SaveChanges();
            return Ok(success ? "OK" : "ERROR");
                            
            
        }

        //[HttpPost]

        //public IActionResult login([FromBody] User uc)
        //{
            
        //    if (!string.IsNullOrEmpty(uc.Clave))
        //    {
                
        //        uc.Clave = Encriptados.ConvertSha256(uc.Clave);
        //    }
        //    var usuario = _auc.prueba.Where(s => s.Usuario == uc.Usuario && s.Clave == uc.Clave);

        //    if (usuario.Any())
        //    {
        //       return Ok("Login Exitoso");
        //    }
        //    else
        //    {
        //        return Unauthorized("Login Incorrecto");
        //    }
            
           


        //}

        [HttpGet]

        public IActionResult Getlogin([FromBody] User uc)
        {
           
            if (!string.IsNullOrEmpty(uc.Clave))
            {
                
                uc.Clave = Encriptados.ConvertMD5(uc.Clave);
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
    }
}
