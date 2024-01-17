using Aula5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Aula5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoDeConfiguracaoController : ControllerBase
    {
        public Integracoes Integracoes { get; set; }

        public ArquivoDeConfiguracaoController(
            IOptions<Integracoes> integracoes)
        {
            Integracoes = integracoes.Value;
        }

        [HttpGet("integracoes")]
        public ActionResult GetIntegracao()
        {
            return Ok(Integracoes);
        }
    }
}
