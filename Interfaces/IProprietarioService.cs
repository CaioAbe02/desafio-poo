using DesafioPOO.Models;

namespace DesafioPOO.Interfaces;

public interface IProprietarioService
{
  List<Proprietario> Todos();

  void Adicionar(Proprietario proprietario);
}