using System.ComponentModel.DataAnnotations;

namespace educacional.Models;

public class Candidato
{
    [Key]
    public int CandidatoId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public ICollection<Matricula>? Matriculas { get; set; }
}