namespace DesafioPOO.Models;

public class Apartamento : Imovel
{
  public override string EstaAlugado()
  {
    if (ObterStatusAluguel())
    {
      return $"O apartamento de número {ObterNumero()} está alugado";
    }
    return $"O apartamento de número {ObterNumero()} está disponível";
  }
}