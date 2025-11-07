using Microsoft.EntityFrameworkCore;
using NexFinance.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Kestrel: escuta todas as interfaces
builder.WebHost.ConfigureKestrel(options => {
    options.ListenAnyIP(5163); // HTTP
    options.ListenAnyIP(7075, listenOptions => listenOptions.UseHttps()); // HTTPS
});

// DbContext PostgreSQL
builder.Services.AddDbContext<NexFinanceContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS Angular
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAngularApp", policy =>
        policy.WithOrigins("http://localhost:4200")
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
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
