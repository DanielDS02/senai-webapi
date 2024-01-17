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

## Exercicio

- 01 Continuar parte do que foi mostrado para configura��o agora pegando
a se��o do banco de dados e passando via inje��o de dependencia

 ## Pr�ximos

- [voltar](../README.md)
- [proximo](aula6.md)