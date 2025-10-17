using DesafioPOO.Db;
using DesafioPOO.Interfaces;
using DesafioPOO.DTOs;
using Microsoft.EntityFrameworkCore;
using DesafioPOO.Models;
using Microsoft.AspNetCore.Mvc;
using DesafioPOO.Services;

#region Builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProprietarioService, ProprietarioService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContexto>(options =>
{
  options.UseMySql(
    builder.Configuration.GetConnectionString("mysql"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
  );
});

var app = builder.Build();
#endregion

#region Proprietario
app.MapGet("/proprietarios", (IProprietarioService proprietatioService) =>
{
  var proprietarios = proprietatioService.Todos();

  return Results.Ok(proprietarios);
}).WithTags("Proprietario");

app.MapPost("/proprietarios", ([FromBody] ProprietarioDTO proprietarioDTO, IProprietarioService proprietatioService) =>
{
  var proprietario = new Proprietario
  {
    Nome = proprietarioDTO.Nome,
    Telefone = proprietarioDTO.Telefone,
    Cpf = proprietarioDTO.Cpf
  };

  proprietatioService.Adicionar(proprietario);

  return Results.Created($"/proprietarios/{proprietario.Id}", proprietario);
}).WithTags("Proprietario");
#endregion

#region App
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
#endregion