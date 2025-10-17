namespace DesafioPOO.DTOs;

public record ImovelDTO
{
  public string Endereco { get; set; } = default!;
  public int Numero { get; set; } = default!;
  public bool Alugado { get; set; } = default!;
  public int ProprietarioId { get; set; } = default!;
}