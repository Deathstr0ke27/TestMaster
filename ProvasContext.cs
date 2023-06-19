using System;
using TestMaster2.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestMaster2;

public partial class ProvasContext : DbContext
{
    public DbSet<Alternativa> Alternativas { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Materia> Materias { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Prova> Provas { get; set; }
    public DbSet<Questao> Questoes { get; set; }
    public DbSet<AlunoProva> AlunoMaterias { get; set; }
    public ProvasContext()
    {
        Alternativas = Set<Alternativa>();
        Alunos = Set<Aluno>();
        Materias = Set<Materia>();
        Professores = Set<Professor>();
        Provas = Set<Prova>();
        Questoes = Set<Questao>();
        AlunoMaterias = Set<AlunoProva>();
    }

    public ProvasContext(DbContextOptions<ProvasContext> options)
        : base(options)
    {
        Alternativas = Set<Alternativa>();
        Alunos = Set<Aluno>();
        Materias = Set<Materia>();
        Professores = Set<Professor>();
        Provas = Set<Prova>();
        Questoes = Set<Questao>();
        AlunoMaterias = Set<AlunoProva>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=Provas", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        try
        {
            modelBuilder.Entity<Alternativa>().ToTable("tb_alternativa");
            modelBuilder.Entity<Aluno>().ToTable("tb_aluno");
            modelBuilder.Entity<Materia>().ToTable("tb_materia");
            modelBuilder.Entity<Professor>().ToTable("tb_professor");
            modelBuilder.Entity<Prova>().ToTable("tb_prova");
            modelBuilder.Entity<Questao>().ToTable("tb_questao");
            modelBuilder.Entity<AlunoProva>().ToTable("tb_aluno_prova");

            modelBuilder.Entity<Alternativa>().HasKey(a => a.Id);
            modelBuilder.Entity<Aluno>().HasKey(l => l.Id);
            modelBuilder.Entity<Materia>().HasKey(m => m.Id);
            modelBuilder.Entity<Professor>().HasKey(p => p.Id);
            modelBuilder.Entity<Prova>().HasKey(v => v.Id);
            modelBuilder.Entity<Questao>().HasKey(q => q.Id);
            modelBuilder.Entity<AlunoProva>().HasKey(c => new { c.AlunoId, c.ProvaId });

            //modelBuilder.Entity<AlunoMateria>()
              //  .HasOne(m => m.Aluno)
                //.WithMany(d => d.Materia)
                //.HasForeignKey(m => m.IdAluno);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
