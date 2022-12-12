using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace educacional.Models;

public class Candidato
{
    [Key]
    public int CandidatoId { get; set; }
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O email é obrigatório")]
    public string Email { get; set; }
    [Required(ErrorMessage = "O CPF é obrigatório")]
    public string CPF { get; set; }
    public ICollection<Matricula>? Matriculas { get; set; }
}