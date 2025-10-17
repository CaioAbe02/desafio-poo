using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioPOO.Models;

public abstract class Imovel
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  [Required]
  [StringLength(150)]
  protected string Endereco { get; set; } = default!;

  [Required]
  protected int Numero { get; set; } = default!;

  [Required]
  protected bool Alugado { get; set; } = default!;

  [ForeignKey(nameof(Proprietario))]
  public int ProprietarioId { get; set; }

  [Required]
  public Proprietario Proprietario { get; set; } = default!;

  public abstract string EstaAlugado();
  public string ContatoProprietario() => Proprietario.Contato();
  public int CalcularAluguel(int valorBase) => valorBase;

  public string ObterEndereco() => Endereco;
  public int ObterNumero() => Numero;
  public bool ObterStatusAluguel() => Alugado;

  public void AlterarEndereco(string endereco) => Endereco = endereco;
  public void AlterarNumero(int numero) => Numero = numero;
  public void AlterarProprietarioId(int id) => ProprietarioId = id;
  public void Alugar() => Alugado = true;
  public void Liberar() => Alugado = false;
}
