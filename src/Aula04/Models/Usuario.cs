using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Aula04.Models
{
    public class Usuario
    {
        public string? ID { get; set; }

        /*[Required]
        [StringLength(50)]
        [MinLength(7)]
        [EmailAddress]*/
        //[StringLength(8, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string Email { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Estado { get; set; }
        public string Cep { get; set; }

    }

    public class ValidadorComFluent : AbstractValidator<Usuario>
    {
        public ValidadorComFluent() 
        { 
            RuleFor( usuario => usuario.ID ).NotEmpty().MinimumLength(5);
            RuleFor( usuario => usuario.Email ).NotEmpty().MinimumLength(7).EmailAddress();
        }
    }

    public class ValidadorDeUsuario
    {
        public string Validar(Usuario usuario)
        {
            string erro = string.Empty;

            if(string.IsNullOrEmpty(usuario.ID))
            {
                erro = "Não pode passar ID vazio";
                return erro;
            }

            if (string.IsNullOrEmpty(usuario.Email))
            {
                erro = "Não pode passar email vazio";
                return erro;
            }
            else
            {
                if (usuario.Email.Contains("@"))
                {
                    if (usuario.Email.Length <= 7)
                    {
                        erro = "Deve ter no minimo 7 characteres";
                        return erro;
                    }
                }
                else
                {
                    erro = "Deve seguir formato de email";
                    return erro;
                }
            }

            return erro;
        }
    }
}
