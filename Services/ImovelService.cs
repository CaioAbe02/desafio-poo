// Services/ImovelService.cs

using DesafioPOO.Db;
using DesafioPOO.Interfaces;
using DesafioPOO.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPOO.Services;

public class ImovelService : IImovelService
{
  private readonly DbContexto _contexto;

  public ImovelService(DbContexto contexto)
  {
      _contexto = contexto;
  }

  public List<Casa> TodasCasas()
  {
    return _contexto.Casas.Include(i => i.Proprietario).ToList();
  }

  public Casa? BuscaCasaPorId(int id) => _contexto.Casas.Find(id);

  public void AdicionarCasa(Casa casa)
  {
    _contexto.Casas.Add(casa);
    _contexto.SaveChanges();
  }

  public void AtualizarCasa(Casa casa)
  {
    _contexto.Casas.Update(casa);
    _contexto.SaveChanges();
  }

  public void ApagarCasa(Casa casa)
  {
    _contexto.Casas.Remove(casa);
    _contexto.SaveChanges();
  }

  public List<Apartamento> TodosApartamentos()
  {
    return _contexto.Apartamentos.Include(i => i.Proprietario).ToList();
  }

  public Apartamento? BuscaApartamentoPorId(int id) => _contexto.Apartamentos.Find(id);

  public void AdicionarApartamento(Apartamento apartamento)
  {
    _contexto.Apartamentos.Add(apartamento);
    _contexto.SaveChanges();
  }

  public void AtualizarApartamento(Apartamento apartamento)
  {
    _contexto.Apartamentos.Update(apartamento);
    _contexto.SaveChanges();
  }

  public void ApagarApartamento(Apartamento apartamento)
  {
    _contexto.Apartamentos.Remove(apartamento);
    _contexto.SaveChanges();
  }

  public void AlugarImovel(Imovel imovel)
  {
      imovel.Alugar();
      _contexto.SaveChanges();
  }

  public void LiberarImovel(Imovel imovel)
  {
      imovel.Liberar();
      _contexto.SaveChanges();
  }
}