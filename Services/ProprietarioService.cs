using DesafioPOO.Db;
using DesafioPOO.Interfaces;
using DesafioPOO.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPOO.Services;

public class ProprietarioService : IProprietarioService
{
  private readonly DbContexto _contexto;

  public ProprietarioService(DbContexto contexto)
  {
    _contexto = contexto;
  }

  public List<Proprietario> Todos()
  {
    return _contexto.Proprietarios.ToList();
  }

  public void Adicionar(Proprietario proprietario)
  {
    _contexto.Proprietarios.Add(proprietario);
    _contexto.SaveChanges();
  }
}