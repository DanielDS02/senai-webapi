# Aula 05 17/01/2024

- Arquivo de configura��o
- Log

# Materiais 

https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration 
https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-8.0 
https://learn.microsoft.com/pt-br/dotnet/core/extensions/logging?tabs=command-line 

## Exemplo c�digo

```
\\ Buscar configura��o
builder.Configuration 
\\ Inje��o de dependencia de parte do arquivo de configura��o
builder.Services.Configure<Integracoes>(builder.Configuration.GetSection("Integracoes"));
\\Buscar se��o do arquivo 
var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

var integracoes = config.GetSection("Integracoes").Get<Integracoes>();

\\Usar em classe que precisa do arquivo
 public Integracoes Integracoes { get; set; }

        public ArquivoDeConfiguracaoController(
            IOptions<Integracoes> integracoes)
        {
            Integracoes = integracoes.Value;
        }
```
```
 Logger.LogInformation("Ola eu sou informa��o");
            Logger.LogInformation("Aplica��o construida e sendo iniciada");
            Logger.LogDebug("Ola eu sou debug");
            Logger.LogTrace("Ola eu sou trace");
            Logger.LogWarning("Ola eu sou warning");
            Logger.LogError("Ola eu sou erro");
            Logger.LogCritical("Ola eu sou critical");

 ILogger<ArquivoDeConfiguracaoController> logger

 builder.Services.AddLogging(configure =>
{
    configure.AddConsole();
    configure.AddSerilog();
});

//Nuget
    Serilog
    Serilog.Extensions.Logging
    Serilog.Settings.Configuration
    Serilog.Sinks.File

```

## Exercicio

- 01 Continuar parte do que foi mostrado para configura��o agora pegando
a se��o do banco de dados e passando via inje��o de dependencia
- 02 Adicionar configura��o no aplicativo da pizzaria para indicar o caminho do banco de dados
- 03 Adicionar log nas a��es de negocio da pizzaria

 ## Pr�ximos

- [voltar](../README.md)
- [proximo](aula6.md)