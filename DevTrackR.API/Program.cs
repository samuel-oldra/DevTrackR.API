using DevTrackR.API.Persistence;
using DevTrackR.API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SendGrid.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// PARA ACESSO AO BANCO EM MEMÓRIA
// builder.Services.AddDbContext<DevTrackRContext>(o => o.UseInMemoryDatabase("DevTrackDb"));

// PARA ACESSO AO SQL Server
// var connectionString = builder.Configuration.GetConnectionString("DevTrackCs");
// builder.Services.AddDbContext<DevTrackRContext>(o => o.UseSqlServer(connectionString));

// PARA ACESSO AO SQLite
var connectionString = builder.Configuration.GetConnectionString("DevTrackCs");
builder.Services.AddDbContext<DevTrackRContext>(o => o.UseSqlite(connectionString));

// Injeção de Dependência
// Tipos: Transient, Scoped, Singleton
// Padrão Repository
builder.Services.AddScoped<IPackageRepository, PackageRepository>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DevTrackR.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Samuel B. Oldra",
            Email = "samuel.oldra@gmail.com",
            Url = new Uri("https://github.com/samuel-oldra")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    o.IncludeXmlComments(xmlPath);
});

// SendGrid
var sendGridApiKey = builder.Configuration.GetSection("SendGridApiKey").Value;
builder.Services.AddSendGrid(o => o.ApiKey = sendGridApiKey);

var app = builder.Build();

// Configure the HTTP request pipeline.
// INFO: Swagger visível só em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(o =>
    {
        o.RoutePrefix = string.Empty;
        o.SwaggerEndpoint("/swagger/v1/swagger.json", "DevTrackR.API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();