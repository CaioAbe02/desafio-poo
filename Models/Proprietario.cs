using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioPOO.Models;

public class Proprietario
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; } = default!;

  [Required]
  [StringLength(100)]
  public string Nome { get; set; } = default!;

  [Required]
  [StringLength(20)]
  public string Telefone { get; set; } = default!;

  [Required]
  [StringLength(11, MinimumLength = 11)]
  public string Cpf { get; set; } = default!;

  public string Contato() => "Nome - Telefone";
}