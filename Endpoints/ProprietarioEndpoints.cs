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

    group.MapGet("/", (IProprietarioService proprietatioService) =>
    {
      var proprietarios = proprietatioService.Todos();

      return Results.Ok(proprietarios);
    });

    group.MapGet("/{id}", ([FromRoute] int id, IProprietarioService proprietarioService) =>
    {
      var proprietario = proprietarioService.BuscaPorId(id);
      if (proprietario == null)
        return Results.NotFound();
      return Results.Ok(proprietario);
    });

    group.MapPost("/", ([FromBody] ProprietarioDTO proprietarioDTO, IProprietarioService proprietarioService) =>
    {
      var proprietario = new Proprietario
      {
        Nome = proprietarioDTO.Nome,
        Telefone = proprietarioDTO.Telefone,
        Cpf = proprietarioDTO.Cpf
      };

      proprietarioService.Adicionar(proprietario);

      return Results.Created($"/{proprietario.Id}", proprietario);
    });

    group.MapPut("/{id}", ([FromRoute] int id, ProprietarioDTO proprietarioDTO, IProprietarioService proprietarioService) =>
    {
      var proprietario = proprietarioService.BuscaPorId(id);
      if (proprietario == null)
        return Results.NotFound();

      proprietario.Nome = proprietarioDTO.Nome;
      proprietario.Telefone = proprietarioDTO.Telefone;
      proprietario.Cpf = proprietarioDTO.Cpf;

      proprietarioService.Atualizar(proprietario);

      return Results.Ok(proprietario);
    });
  }
}