using System.ComponentModel.DataAnnotations.Schema;

namespace TestMaster2.Models;
[Table("tb_professor")]
public class Professor
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }

    public Professor(int? id, string nome, string login, string senha)
    {
        Id = id;
        Nome = nome;
        Login = login;
        Senha = senha;
    }

    public override string ToString()
    {
        return $"Professor: Id={Id}, Nome={Nome}, Login={Login}, Senha={Senha}";
    }
}
