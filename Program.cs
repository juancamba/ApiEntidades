using ApiEntidades.Models;
using ApiEntidades.Repositories;
using ApiEntidades.Services;
using ApiEntidades.Services.Ficheros;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




// registra la interface
// alquien que pide IPlatformRepo, le damos PlatformRepo
builder.Services.AddTransient<IFicheroMuestraService, FicheroMuestraService>();
builder.Services.AddTransient<IMuestraRepository, MuestrasRepository>();
//builder.Services.AddTransient<IMuestraService, MuestraService>();
builder.Services.AddTransient<ICampoRepository, CampoRepository>();
builder.Services.AddTransient<CampoService>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BaseDeDatos"))); ;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost");
                      });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));





app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
