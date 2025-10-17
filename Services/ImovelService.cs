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

  public Apartamento? BuscaApartamentoPorId(int id) => _contexto.Apartamentos.Find(id);

  public void AdicionarCasa(Casa casa)
  {
      _contexto.Casas.Add(casa);
      _contexto.SaveChanges();
  }

  public void AdicionarApartamento(Apartamento apartamento)
  {
      _contexto.Apartamentos.Add(apartamento);
      _contexto.SaveChanges();
  }

  public void ApagarImovel(Imovel imovel)
  {
      _contexto.Set<Imovel>().Remove(imovel);
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