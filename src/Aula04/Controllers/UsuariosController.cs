using Aula04.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ValidadorDeUsuario _validadorDeUsuario;
        private readonly IValidator<Usuario> _validadorComFluent;



        public UsuariosController(
            ValidadorDeUsuario validadorDeUsuario,
            IValidator<Usuario> validator
            )
        {
            _validadorDeUsuario = validadorDeUsuario;
            _validadorComFluent = validator;
        }

        [HttpPost]
        public ActionResult AdicionarUsuario(Usuario usuario)
        {
            //FluentValidation
            var validacaoComFluent = _validadorComFluent.Validate(usuario);
            if (validacaoComFluent.IsValid is false)
            {
                return BadRequest(validacaoComFluent.Errors);
            }

            //Data annotation
            if (ModelState.IsValid is false)
            {
                return BadRequest(ModelState);
            }

            //Na mao
            string validacaoUsuario = _validadorDeUsuario.Validar(usuario);
            if (string.IsNullOrEmpty(validacaoUsuario) is false)
            {
                return BadRequest(validacaoUsuario);
            }

            return Ok();
        }
    }
}
