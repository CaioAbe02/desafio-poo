using DesafioPOO.Models;

namespace DesafioPOO.Interfaces;

public interface IImovelService
{

  List<Casa> TodasCasas();
  Casa? BuscaCasaPorId(int id);
  void AdicionarCasa(Casa casa);

  Apartamento? BuscaApartamentoPorId(int id);
  void AdicionarApartamento(Apartamento apartamento);

  void ApagarImovel(Imovel imovel);
  void AlugarImovel(Imovel imovel);
  void LiberarImovel(Imovel imovel);
}