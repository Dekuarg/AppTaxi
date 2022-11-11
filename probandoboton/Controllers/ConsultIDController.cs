using Microsoft.AspNetCore.Mvc;
using probandoboton.Encriptacion;
using probandoboton.Models;

namespace probandoboton.Controllers
{
    public class ConsultIDController : Controller

    {
        private readonly ApplicationUser _auc;
        public ConsultIDController(ApplicationUser auc)
        {
            _auc = auc;
        }

        [HttpGet]

        public IActionResult ConsultaToken([FromBody] User uc)
        {

            var usuario = _auc.prueba.Where(s => s.Usuario == uc.Usuario);

            if (usuario.Any())
            {
                return Ok("token encontrado");
            }
            else
            {
                return NotFound("Token no encontrado");
            }
        }

        [HttpGet]
        public IActionResult Consult([FromBody] string token)
        {
            if (!string.IsNullOrEmpty(token))
            {

                return Ok(GenerateToken.ValidateToken(token));
            }
            else
            {
                return BadRequest("token no encontrado");
            }

        }
    }
}
