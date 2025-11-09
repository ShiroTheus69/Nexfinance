using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using NexFinance.src.Api.Data;
using NexFinance.src.Application.Interfaces;
using NexFinance.src.Application.Interfaces.Repositories;
using NexFinance.src.Application.Mapping;
using NexFinance.src.Application.Services;
using NexFinance.src.Infrastructure.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);

// Kestrel: define portas
builder.WebHost.ConfigureKestrel(options => {
    options.ListenAnyIP(5165); // HTTP
});

// DbContext com PostgreSQL
builder.Services.AddDbContext<NexFinanceContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);


// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories (assumindo implementações já criadas)
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();
builder.Services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();

// Services
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IContaService, ContaService>();
builder.Services.AddScoped<ILancamentoService, LancamentoService>();
builder.Services.AddScoped<ITransferenciaService, TransferenciaService>();

// CORS para Angular
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAngularApp", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");
app.UseAuthorization();
app.MapControllers();

app.Run();
