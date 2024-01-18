using Aula5.Models;
using Microsoft.Extensions.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

/*
 *  Maneira de buscar configuração sem ser pela injeção de dependencia
var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

var integracoes = config.GetSection("Integracoes").Get<Integracoes>();
*/
// Add services to the container.
//var settings = builder.Configuration.GetSection("Integracoes").Get<Integracoes>();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

/*var logger = new LoggerConfiguration()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();*/

Log.Logger = logger;
logger.Debug("Teste");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Integracoes>(builder.Configuration.GetSection("Integracoes"));
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddLogging(configure =>
{
    configure.AddConsole();
	configure.AddSerilog();
});


var app = builder.Build();

app.Logger.LogInformation("Ola eu sou informação");
app.Logger.LogInformation("Aplicação construida e sendo iniciada");
app.Logger.LogDebug("Ola eu sou debug");
app.Logger.LogTrace("Ola eu sou trace");
app.Logger.LogWarning("Ola eu sou warning");
app.Logger.LogError("Ola eu sou erro");
app.Logger.LogCritical("Ola eu sou critical");

try
{

	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseAuthorization();

	app.MapControllers();

	app.Run();
}
catch (Exception ex) 
{
	app.Logger.LogCritical(ex, "Parou tudo");
}

