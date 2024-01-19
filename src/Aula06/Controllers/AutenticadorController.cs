using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aula06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class AutenticadorController : ControllerBase
    {
        List<Usuario> usuarios = new List<Usuario>();
        public string Secret { get; set; }
        public AutenticadorController(IOptions<Settings> settings)
        {
            usuarios.Add(new Usuario()
            {
                Email = "teste@senai.com",
                Id = 1,
                Password = "password",
                Role = "admin",
                UserName = "teste"
            });

            Secret = settings.Value.Secret;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<string> Autenticar(Usuario usuario)
        {
            Usuario? usarioParaAutenticar = usuarios.Find(x => x.Email == usuario.Email);
            if (usarioParaAutenticar?.Password == usuario.Password)
            {
                return GenerateToken(usarioParaAutenticar, Secret);
            }
            return string.Empty;
        }

        

        public static string GenerateToken(Usuario user, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim("isAuthenticated", "true"),
                    new Claim("userId", user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class Usuario 
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
