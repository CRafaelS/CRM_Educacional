using educacional.Models;

namespace educacional.Repository;

public class CandidatoRepository
{
    protected readonly CrmEducacionalContext _context;

    public CandidatoRepository(CrmEducacionalContext context)
    {
        _context = context;
    }

    public Candidato criarCandidato(Candidato candidato)
    {
        _context.Candidatos.Add(candidato);
        _context.SaveChanges();

        return new Candidato
        {
            CandidatoId = candidato.CandidatoId,
            Nome = candidato.Nome,
            Email = candidato.Email,
            CPF = candidato.CPF,
        };
    }

    public IEnumerable<Candidato> pegarCandidatos()
    {
        return _context.Candidatos.ToList();
    }
}