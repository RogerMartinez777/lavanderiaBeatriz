using Lavanderia_Beatriz_App.Models;
using Lavanderia_Beatriz_App.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// inyeccion del Context para la conexion: que datos pasamos ?
//-clase a la que aplicamos, -BD que utilizamos para conectar, -cadena de conexion.
builder.Services.AddDbContext<LavanderiaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Inyeccion de dependencia:
builder.Services.AddScoped<ILavanderiaRepository, LavanderiaRepository>();//crea una instancia por cada request.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
