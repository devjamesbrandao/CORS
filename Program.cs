var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurando CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AppCORS", policy =>
    {
        policy.AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(x => true)
                .AllowCredentials();
    });
});

var app = builder.Build();

// Utilizando configuração de CORS
app.UseCors("AppCORS");

app.MapControllers();

app.Run();
