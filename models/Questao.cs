using System.ComponentModel.DataAnnotations.Schema;

namespace TestMaster2.Models;

[Table("tb_questao")]
public class Questao
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public string Nome { get; set; }
    public double Peso { get; set; }
    [ForeignKey("ProvaId")]
    public Prova Prova { get; set; }

    public int? ProvaId {get; set;}

    public Questao(int? id, string nome, double peso, int? provaId)
    {
        Id = id;
        Nome = nome;
        Peso = peso;
        ProvaId = provaId;
    }

    public override string ToString()
    {
        return $"Questão: Id={Id}, Nome={Nome}, Peso={Peso}, ProvaId={ProvaId}";
    }
}