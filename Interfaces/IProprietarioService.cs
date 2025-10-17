using DesafioPOO.Models;

namespace DesafioPOO.Interfaces;

public interface IProprietarioService
{
  List<Proprietario> Todos();
  Proprietario? BuscaPorId(int id);
  void Adicionar(Proprietario proprietario);
  void Atualizar(Proprietario proprietario);
  void Apagar(Proprietario proprietario);
}