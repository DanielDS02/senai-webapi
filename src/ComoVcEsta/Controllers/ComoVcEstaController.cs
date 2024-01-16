using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ComoVcEsta.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComoVcEstaController : ControllerBase
{
    private Sentimento Sentimento { get; set; }
    public ComoVcEstaController(Sentimento sentimento)
    {
        Sentimento = sentimento;
    }
    [HttpPost]
    public void AdicionarSentimento(string nome, string sentimento)
    {
        Sentimento.EscrevaOSentimento(nome, sentimento);
        //return Ok();
    }

    [HttpGet]
    public Sentimento[] TrazerSentimentos()
    {
        return Sentimento.TrazerSentimentos();
    }


    [HttpGet("trazer-sentimentos")]
    public async Task<string> TrazerSentimentosDaApi()
    {
        using HttpClient client = new();
        var result = await client.GetAsync("http://localhost:5263/api/ComoVcEsta");

        return await result.Content.ReadAsStringAsync();
    }
   
}
