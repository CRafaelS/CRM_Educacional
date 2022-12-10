using Microsoft.EntityFrameworkCore;
using educacional.Models;

public class CrmEducacionalContext : DbContext
{
    public DbSet<Candidato> Candidatos { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Matricula> Matriculas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"
                Server=127.0.0.1;
                Database=crm_educacional_db;
                User=SA;
                Password=Password12!;
                TrustServerCertificate=true
            ");
        }
    }

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
    }
}