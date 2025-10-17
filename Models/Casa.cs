namespace DesafioPOO.Models;

public class Casa : Imovel
{
  public override string EstaAlugado()
  {
    if (ObterStatusAluguel())
    {
      return "A casa esta alugada";
    }
    return "A casa está disponível";
  }
}