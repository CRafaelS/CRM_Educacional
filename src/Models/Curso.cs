using System.ComponentModel.DataAnnotations;

namespace educacional.Models;

public class Curso
{
    [Key]
    public int CursoId { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string CargaHoraria { get; set; }
    public decimal Preco { get; set; }
    public string Categoria { get; set; }
    public ICollection<Matricula>? Matriculas { get; set; }
}