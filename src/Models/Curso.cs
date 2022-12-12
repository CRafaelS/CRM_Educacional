using System.ComponentModel.DataAnnotations;

namespace educacional.Models;

public class Curso
{
    [Key]
    public int CursoId { get; set; }
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "A descrição é obrigatória")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "O preço é obrigatório")]
    public decimal Preco { get; set; }
    [Required(ErrorMessage = "A categoria é obrigatória")]
    public string Categoria { get; set; }
    public ICollection<Matricula>? Matriculas { get; set; }
}