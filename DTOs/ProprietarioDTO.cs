namespace DesafioPOO.DTOs;

public record ProprietarioDTO
{
  public string Nome { get; set; } = default!;
  public string Telefone { get; set; } = default!;
  public string Cpf { get; set; } = default!;
}