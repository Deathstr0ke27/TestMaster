using System.ComponentModel.DataAnnotations.Schema;

namespace TestMaster2.Models;

[Table("tb_materia")]
public class Materia
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public string Nome { get; set; }
    [ForeignKey("ProfessorId")]
    public Professor Professor {get; set;}
    [ForeignKey("AlunosId")]
    public List<Aluno> Alunos { get; set; }

    public int? ProfessorId {get; set;} 
    public int? AlunosId {get; set;}
    public Materia(int? id, string nome, int? professorId, int? alunosId)
    {
        Id = id;
        Nome = nome;
        ProfessorId = professorId;
        AlunosId = alunosId;
    }

    public override string ToString()
    {
        return $"Materia: Id={Id}, Nome={Nome}, ProfessorId={ProfessorId}";
    }
}