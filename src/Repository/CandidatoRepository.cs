using educacional.Models;
using educacional.Validacao;

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
        var candidatoExistente = _context.Candidatos.FirstOrDefault(c => c.CPF == candidato.CPF);

        if (candidatoExistente != null)
        {
            throw new Exception("CPF já cadastrado");
        }
        
        bool isValidCPF = Validacao.ValidarCPF.ValidaCPF(candidato.CPF);

        if (!isValidCPF)
        {
            throw new Exception("CPF inválido");
        }

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