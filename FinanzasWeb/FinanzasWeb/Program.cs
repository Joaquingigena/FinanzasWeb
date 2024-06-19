using AutoMapper;
using AutoMapper.Internal;
using FinanzasWeb.Data;
using FinanzasWeb.Interfaces;
using FinanzasWeb.Repository;
using FinanzasWeb.Utility;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opciones =>
    opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ITipoMovimientoRepositorio, TipoMovimientoRepositorio>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<IMovimientoRepositorio, MovimientoRepositorio>();
builder.Services.AddScoped<IReporteRepositorio, ReporteRepositorio>();

builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer("name=cadenaSql"));

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AllowNullCollections = true;
    mc.ShouldMapMethod = (m => false);//this is solution
    mc.AddProfile(new AutoMapperProfiles());
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app => {
        app.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
