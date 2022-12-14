using educacional.Models;

namespace educacional.Repository;

public class CursoRepository
{
    protected readonly CrmEducacionalContext _context;

    public CursoRepository(CrmEducacionalContext context)
    {
        _context = context;
    }

    public Curso criarCurso(Curso curso)
    {
        _context.Cursos.Add(curso);
        _context.SaveChanges();

        return new Curso
        {
            CursoId = curso.CursoId,
            Nome = curso.Nome,
            Descricao = curso.Descricao,
            Preco = curso.Preco,
        };
    }

    public List<Curso> pegarCursos()
    {
        return _context.Cursos.ToList();
    }
}