using DesafioPOO.DTOs;
using DesafioPOO.Interfaces;
using DesafioPOO.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPOO.Endpoints;

public static class CasaEndpoints
{
  public static void MapCasaEndpoints(this IEndpointRouteBuilder app)
  {
    var group = app.MapGroup("/casas").WithTags("Casa");

    group.MapGet("/", (IImovelService imovelService) =>
    {
      var casas = imovelService.TodasCasas();

      return Results.Ok(casas);
    });

    group.MapGet("/{id}", ([FromRoute] int id, IImovelService imovelService) =>
    {
      var casa = imovelService.BuscaCasaPorId(id);
      if (casa == null)
        return Results.NotFound();
      return Results.Ok(casa);
    });

    group.MapPost("/", ([FromBody] ImovelDTO imovelDTO, IImovelService imovelService) =>
    {
      var casa = new Casa();
      casa.AlterarEndereco(imovelDTO.Endereco);
      casa.AlterarNumero(imovelDTO.Numero);
      casa.AlterarProprietarioId(imovelDTO.ProprietarioId);

      imovelService.AdicionarCasa(casa);

      return Results.Created($"/{casa.Id}", casa);
    });

    // group.MapPut("/{id}", ([FromRoute] int id, ImovelDTO imovelDTO, IImovelService imovelService) =>
    // {
    //   var casa = imovelService.BuscaCasaPorId(id);
    //   if (casa == null)
    //     return Results.NotFound();

    //   casa.AlterarEndereco(imovelDTO.Endereco);
    //   casa.AlterarNumero(imovelDTO.Numero);
    //   casa.AlterarProprietarioId(imovelDTO.ProprietarioId);

    //   imovelService.Atualizar(proprietario);

    //   return Results.Ok(casa);
    // });
  }
}