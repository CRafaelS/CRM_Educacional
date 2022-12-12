using Microsoft.EntityFrameworkCore;
using educacional.Models;

public class CrmEducacionalContext : DbContext
{
    public CrmEducacionalContext(DbContextOptions<CrmEducacionalContext> options) : base(options) { }

    public DbSet<Candidato> Candidatos { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Matricula> Matriculas { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {   
        mb.Entity<Matricula>()
            .HasOne(m => m.Candidato)
            .WithMany(c => c.Matriculas)
            .HasForeignKey(m => m.CandidatoId);
        
        mb.Entity<Matricula>()
            .HasOne(m => m.Curso)
            .WithMany(c => c.Matriculas)
            .HasForeignKey(m => m.CursoId);
        
        mb.Entity<Candidato>()
            .HasIndex(c => c.CPF)
            .IsUnique();
    }
}