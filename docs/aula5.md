# Aula 05 17/01/2024

- Arquivo de configuração
- Log

# Materiais 

https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration 
https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-8.0 
https://learn.microsoft.com/pt-br/dotnet/core/extensions/logging?tabs=command-line 

## Exemplo código

```
\\ Buscar configuração
builder.Configuration 
\\ Injeção de dependencia de parte do arquivo de configuração
builder.Services.Configure<Integracoes>(builder.Configuration.GetSection("Integracoes"));
\\Buscar seção do arquivo 
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

- 01 Continuar parte do que foi mostrado para configuração agora pegando
a seção do banco de dados e passando via injeção de dependencia

 ## Próximos

- [voltar](../README.md)
- [proximo](aula6.md)