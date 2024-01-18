# Aula 06 18/01/2024

- Autenticação e Authorização
- Documentação

# Materiais 

- https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-8.0
- https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-7.0&viewFallbackFrom=aspnetcore-8.0&tabs=visual-studio

## Exemplo código

```
// Exemplo de Configuração do Swagger para Documentação da API

// Adicione o pacote NuGet Swashbuckle.AspNetCore

// No Startup.cs:

using Microsoft.OpenApi.Models;

// ...

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nome da Sua API", Version = "v1" });

    // Adicione os comentários XML para melhorar a documentação
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// No método Configure:

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nome da Sua API V1");
});

//No metodo do controller 

/// <summary>
/// Trazer a configuração de integração do arquivo de configuração
/// </summary>
/// <returns>A configuração de integracao</returns>
[HttpGet("integracoes")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Integracoes))]

```
```
// Add services to the container.
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
   x.RequireHttpsMetadata = false;
   x.SaveToken = true;
   x.TokenValidationParameters = new TokenValidationParameters
   {
       ValidateIssuerSigningKey = true,
       IssuerSigningKey = new SymmetricSecurityKey(key),
       ValidateIssuer = false,
       ValidateAudience = false
   };
});

app.UseAuthentication();
app.UseAuthorization();


[HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Authenticate(AuthenticateModel model)
        {
            // Recupera o usuário
            var token = await _authenticationService.AuthenticateAsync(model);

            // Verifica se o usuário existe
            if (token == string.Empty)
                return BadRequest(new { message = "Usuário ou senha inválidos" });

            return Ok(token);
        }

public interface IUserRepository
    {
        List<User> Users { get; }

        Task<User> Get(string email, string password);
        Task<bool> Check(string email);
        Task<string> CheckIfIdExist(Guid id);
        Task<string> Create(User user);
        Task<string> Delete(Guid id);
        Task<IEnumerable<User>> GetAll();
        Task<string> Update(User user);
    }

 public class User : BaseEntity
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }

public static string GenerateToken(User user, string secret)
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

```
## Exercicio

- 01 
- 02 
- 03 

 ## Próximos

- [voltar](aula5.md)