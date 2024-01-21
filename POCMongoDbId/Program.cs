using Microsoft.OpenApi.Models;
using POCMongoDBId.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<POCMongoDBId.Infrastructure.MongoDB>();
builder.Services.AddScoped<ItemRepository>();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Nome da sua API",
        Description = "Descrição da sua API",
        Contact = new OpenApiContact
        {
            Name = "Seu Nome",
            Email = "seu.email@example.com",
            Url = new Uri("https://seu-site.com"),
        }
    });
});
builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nome da sua API v1");
    c.RoutePrefix = "swagger"; // Configure o roteamento para o Swagger UI
});


app.Run();
