using Aula04.Models;
using FluentValidation;

namespace Aula04
{
    public static class Aula4Extension
    {
        public static void AdicionarDependencia( this IServiceCollection services)
        {
            services.AddScoped<ValidadorDeUsuario>();
            services.AddSingleton<IValidator<Usuario>, ValidadorComFluent>();
        }
    }
}
