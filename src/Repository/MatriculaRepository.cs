using educacional.Models;

namespace educacional.Repository;

public class MatriculaRepository
{
    protected readonly CrmEducacionalContext _context;

    public MatriculaRepository(CrmEducacionalContext context)
    {
        _context = context;
    }

    public MatriculaDTO criarMatricula(MatriculaDTO matricula)
    {
        var encontraCurso = _context.Cursos.Find(matricula.CursoId);
        var encontraCandidato = _context.Candidatos.Find(matricula.CandidatoId);

        if (encontraCurso == null || encontraCandidato == null)
        {
            throw new Exception("Curso ou candidato não encontrado");
        }

        var novaMatricula = new Matricula
        {
            Candidato = encontraCandidato!,
            CandidatoId = matricula.CandidatoId,
            Curso = encontraCurso!,
            CursoId = matricula.CursoId,
        };

        _context.Matriculas.Add(novaMatricula);
        _context.SaveChanges();

        return new MatriculaDTO
        {
            CandidatoId = novaMatricula.CandidatoId,
            CursoId = novaMatricula.CursoId
        };
    }

    public List<Matricula> pegarMatriculas()
    {
        return _context.Matriculas.ToList();
    }
}