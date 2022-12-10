using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace educacional.Models;

public class Matricula
{
    [Key]
    public int Id { get; set; }
    public int CursoId { get; set; }
    public int CandidatoId { get; set; }

    [ForeignKey("CursoId")]
    public Curso Curso { get; set; }
    
    [ForeignKey("CandidatoId")]
    public Candidato Candidato { get; set; }
}