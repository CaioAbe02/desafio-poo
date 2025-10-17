using DesafioPOO.DTOs;
using DesafioPOO.Interfaces;
using DesafioPOO.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPOO.Endpoints;

public static class ApartamentoEndpoints
{
  public static void MapApartamentoEndpoints(this IEndpointRouteBuilder app)
  {
    var group = app.MapGroup("/apartamentos").WithTags("Apartamento");

    group.MapGet("/", (IImovelService imovelService) =>
    {
      var apartamentos = imovelService.TodosApartamentos();

      return Results.Ok(apartamentos);
    });

    group.MapGet("/{id}", ([FromRoute] int id, IImovelService imovelService) =>
    {
      var apartamento = imovelService.BuscaCasaPorId(id);
      if (apartamento == null)
        return Results.NotFound();
      return Results.Ok(apartamento);
    });

    group.MapPost("/", ([FromBody] ImovelDTO imovelDTO, IImovelService imovelService) =>
    {
      var apartamento = new Apartamento();
      apartamento.AlterarEndereco(imovelDTO.Endereco);
      apartamento.AlterarNumero(imovelDTO.Numero);
      apartamento.AlterarProprietarioId(imovelDTO.ProprietarioId);

      imovelService.AdicionarApartamento(apartamento);

      return Results.Created($"/{apartamento.Id}", apartamento);
    });

    group.MapPut("/{id}", ([FromRoute] int id, ImovelDTO imovelDTO, IImovelService imovelService) =>
    {
      var apartamento = imovelService.BuscaApartamentoPorId(id);
      if (apartamento == null)
        return Results.NotFound();

      apartamento.AlterarEndereco(imovelDTO.Endereco);
      apartamento.AlterarNumero(imovelDTO.Numero);
      apartamento.AlterarProprietarioId(imovelDTO.ProprietarioId);

      imovelService.AdicionarApartamento(apartamento);

      return Results.Ok(apartamento);
    });

    group.MapDelete("/{id}", ([FromRoute] int id, IImovelService imovelService) =>
    {
      var apartamento = imovelService.BuscaApartamentoPorId(id);
      if (apartamento == null)
        return Results.NotFound();

      imovelService.ApagarApartamento(apartamento);

      return Results.NoContent();
    });
  }
}