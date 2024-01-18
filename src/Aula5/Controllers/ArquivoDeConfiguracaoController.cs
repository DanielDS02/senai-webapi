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
        public ConnectionStrings ConnectionStrings { get; set; }
        public ILogger<ArquivoDeConfiguracaoController> Logger { get; }

        public ArquivoDeConfiguracaoController(
            IOptions<Integracoes> integracoes,
            IOptions<ConnectionStrings> connectionStrings,
            ILogger<ArquivoDeConfiguracaoController> logger)
        {
            Integracoes = integracoes.Value;
            ConnectionStrings = connectionStrings.Value;
            Logger = logger;
        }

        [HttpGet("integracoes")]
        public ActionResult GetIntegracao()
        {
            Logger.LogInformation($"{nameof(GetIntegracao)}");
            return Ok(Integracoes);
        }

        [HttpGet("ConnectionStrings")]
        public ActionResult GetConnectionStrings()
        {
            Logger.LogInformation($"{nameof(GetIntegracao)}");
            Logger.LogDebug($"Dados do banco {ConnectionStrings}");
            return Ok(ConnectionStrings);
        }

        [HttpGet("logs")]
        public ActionResult GetLogs()
        {
            Logger.LogInformation("Ola eu sou informação");
            Logger.LogInformation("Aplicação construida e sendo iniciada");
            Logger.LogDebug("Ola eu sou debug");
            Logger.LogTrace("Ola eu sou trace");
            Logger.LogWarning("Ola eu sou warning");
            Logger.LogError("Ola eu sou erro");
            Logger.LogCritical("Ola eu sou critical");

            return Ok(Logger);
        }
    }
}
