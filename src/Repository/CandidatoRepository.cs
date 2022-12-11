using educacional.Models;

namespace educacional.Repository;

public class CandidatoRepository
{
    protected readonly CrmEducacionalContext _context;

    public CandidatoRepository(CrmEducacionalContext context)
    {
        _context = context;
    }

    public Candidato addCandidato(Candidato candidato)
    {
        var novoCandidato = new Candidato
        {
            Nome = candidato.Nome,
            Email = candidato.Email,
            CPF = candidato.CPF,
            Telefone = candidato.Telefone,
        };
        _context.Candidatos.Add(candidato);
        _context.SaveChanges();

        return _context.Candidatos
                .Where(b => b.CandidatoId == novoCandidato.CandidatoId)
                .Select(x => new Candidato
                {
                    CandidatoId = x.CandidatoId,
                    Nome = x.Nome,
                    Email = x.Email,
                    CPF = x.CPF,
                    Telefone = x.Telefone,
                }).First();
    }

     public IEnumerable<Candidato> pegarCandidatos()
        {
            return _context.Candidatos
                .Select(x => new Candidato{
                     CandidatoId = x.CandidatoId,
                    Nome = x.Nome,
                    Email = x.Email,
                    CPF = x.CPF,
                    Telefone = x.Telefone,
                });
        }
}