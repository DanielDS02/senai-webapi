# Aula 04 16/01/2024

- Aprender realizar a valida��o de um objeto
- Data annotations
- Usar fluent validations
- Aprender IOC 
- Scoped
- Transient
- Singleton
- Exercicio para pr�ticar.

## Materiais

- https://docs.fluentvalidation.net/en/latest/
- https://learn.microsoft.com/pt-br/aspnet/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api
- https://learn.microsoft.com/pt-br/dotnet/api/system.componentmodel.dataannotations?view=net-8.0 
- https://learn.microsoft.com/pt-br/dotnet/core/extensions/dependency-injection

## C�digo resumo 

```Valida��o de dados

StringLength(8, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
public string Senha;

\\Classe para fluent validations
 public class ValidadorComFluent : AbstractValidator<Usuario>
    {
        public ValidadorComFluent() 
        { 
            RuleFor( usuario => usuario.ID ).NotEmpty().MinimumLength(5);
            RuleFor( usuario => usuario.Email ).NotEmpty().MinimumLength(7).EmailAddress();
        }
    }

\\ Valida��o manual

 public class ValidadorDeUsuario
    {
        public string Validar(Usuario usuario)
        {
            string erro = string.Empty;

            if(string.IsNullOrEmpty(usuario.ID))
            {
                erro = "N�o pode passar ID vazio";
                return erro;
            }
            ...      
```
```
\\Inje��o de dependencia

public static class Aula4Extension
    {
        public static void AdicionarDependencia( this IServiceCollection services)
        {
            //services.AddTransient<ValidadorDeUsuario>();
            services.AddScoped<ValidadorDeUsuario>();
            services.AddSingleton<IValidator<Usuario>, ValidadorComFluent>();
        }
    }
```


## Exercicio

01 - Fazer valida��o para todo o modelo do usuario das 3 maneiras 
02 - Fazer valida��o usando uma das 3 maneiras para os controles da pizzaria


 ## Pr�ximos

- [voltar](aula3.md)
- [proximo](aula5.md)