using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace educacional.Models;

public class Matricula
{
    [Key]
    public int MatriculaId { get; set; }
    [ForeignKey("CursoId")]
    public int CursoId { get; set; }
    public Curso Curso { get; set; }

    [ForeignKey("CandidatoId")]
    public int CandidatoId { get; set; }
    public Candidato Candidato { get; set; }
}

public class MatriculaDTO
{
    public int Id { get; set; }
    public int CursoId { get; set; }
    public int CandidatoId { get; set; }
}