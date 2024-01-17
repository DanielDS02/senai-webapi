using Aula5.Models;
using Microsoft.Extensions.Configuration;

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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Integracoes>(builder.Configuration.GetSection("Integracoes"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

