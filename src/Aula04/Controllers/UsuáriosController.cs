using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aula04.Models;
using System.Security.Cryptography.X509Certificates;

namespace Aula04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuáriosController : ControllerBase
    {
        public readonly ValidadorDeUsuario _validadorDeUsuario;

        public UsuáriosController()
        {
            _validadorDeUsuario = new ValidadorDeUsuario();
        }

        [HttpPost]
        public ActionResult AdicionarUsuario(Usuario usuario)
        {
            string validacaoUsuario = _validadorDeUsuario.Validar(usuario);
            if (string.IsNullOrEmpty(validacaoUsuario) is false)
            {
                return BadRequest(validacaoUsuario);
            }

            return Ok();
        }

    }
}
