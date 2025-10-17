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
  public string Endereco { get; protected set; } = default!;

  [Required]
  public int Numero { get; protected set; } = default!;

  [Required]
  public bool Alugado { get; protected set; } = default!;

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
