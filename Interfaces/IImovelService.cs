using DesafioPOO.Models;

namespace DesafioPOO.Interfaces;

public interface IImovelService
{

  List<Casa> TodasCasas();
  Casa? BuscaCasaPorId(int id);
  void AdicionarCasa(Casa casa);
  void AtualizarCasa(Casa casa);
  void ApagarCasa(Casa casa);

  List<Apartamento> TodosApartamentos();
  Apartamento? BuscaApartamentoPorId(int id);
  void AdicionarApartamento(Apartamento apartamento);
  void AtualizarApartamento(Apartamento apartamento);
  void ApagarApartamento(Apartamento apartamento);

  void AlugarImovel(Imovel imovel);
  void LiberarImovel(Imovel imovel);
}