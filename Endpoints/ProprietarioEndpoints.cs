using DesafioPOO.DTOs;
using DesafioPOO.Interfaces;
using DesafioPOO.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPOO.Endpoints;

public static class ProprietarioEndpoints
{
  public static void MapProprietarioEndpoints(this IEndpointRouteBuilder app)
  {
    var group = app.MapGroup("/proprietarios").WithTags("Proprietario");

    group.MapGet("/proprietarios", (IProprietarioService proprietatioService) =>
    {
      var proprietarios = proprietatioService.Todos();

      return Results.Ok(proprietarios);
    }).WithTags("Proprietario");

    group.MapGet("proprietarios/{id}", ([FromRoute] int id, IProprietarioService proprietarioService) =>
    {
      var proprietario = proprietarioService.BuscaPorId(id);
      if (proprietario == null)
        return Results.NotFound();
      return Results.Ok(proprietario);
    }).WithTags("Proprietario");

    group.MapPost("/proprietarios", ([FromBody] ProprietarioDTO proprietarioDTO, IProprietarioService proprietatioService) =>
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

    group.MapPut("/proprietarios/{id}", ([FromRoute] int id, ProprietarioDTO proprietarioDTO, IProprietarioService proprietatioService) =>
    {
      var proprietario = proprietatioService.BuscaPorId(id);
      if (proprietario == null)
        return Results.NotFound();

      proprietario.Nome = proprietarioDTO.Nome;
      proprietario.Telefone = proprietarioDTO.Telefone;
      proprietario.Cpf = proprietarioDTO.Cpf;

      proprietatioService.Atualizar(proprietario);

      return Results.Ok(proprietario);
    }).WithTags("Proprietario");
  }
}