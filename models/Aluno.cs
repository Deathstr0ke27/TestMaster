using System.ComponentModel.DataAnnotations.Schema;

namespace TestMaster2.Models;
[Table("tb_aluno")]
public class Aluno
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    [ForeignKey("MateriaId")]
    public Materia? Materia { get; set; }
    public int? MateriaId {get; set;}

    public Aluno(int? id, string nome, string login, string senha, int? materiaId)
    {
        Id = id;
        Nome = nome;
        Login = login;
        Senha = senha;
        MateriaId = materiaId;
    }

    public override string ToString()
    {
        return $"Aluno: Id={Id}, Nome={Nome}, Login={Login}, Senha={Senha}, Materia={MateriaId}";
    }
}