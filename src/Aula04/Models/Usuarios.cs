using System.Diagnostics.Eventing.Reader;
using FluentValidation;

namespace Aula04.Models
{
    public class Usuario
    {
        public string? ID { get; set; }

        public string Email { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Estado { get; set; }

        public string CEP { get; set;}
    }

    public class ValidadorComFluent : AbstractValidator<Usuario>
    {
        public ValidadorComFluent()
        {
            RuleFor( usuario => usuario.ID ).NotEmpty().Length(5);
            RuleFor( usuario ) 
        }
    }

    public class ValidadorDeUsuario
    {
        public string Validar(Usuario usuario)
        {
            string erro = string.Empty;

            if (string.IsNullOrEmpty(usuario.ID))
            {
                erro = "Não pode passar ID vazio";
                return erro;
            }

            if (string.IsNullOrEmpty(usuario.Email))
            {
                if (usuario.Email.Contains("@"))
                {
                    if (usuario.Email.Length <= 7)
                    {
                        erro = "Deve ter no mínimo 7 caracteres";
                        return erro;
                    }
                }
                else
                {
                    erro = "Não pode passar email vazio";
                    return erro;
                }
            }
            else
            {
                erro = "Deve seguir o formato de email";
                return erro;
            }
            

            return erro;
        }
    }
}
