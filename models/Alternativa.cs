using System.ComponentModel.DataAnnotations.Schema;

namespace TestMaster2.Models;

[Table("tb_alternativa")]
public class Alternativa
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public string Texto { get; set; }
    public bool Certo { get; set; }
    [ForeignKey("QuestaoId")]
    public Questao Questao { get; set; }

    public int? QuestaoId {get; set;}

    public Alternativa(int? id, string texto, bool certo, int? questaoId)
    {
        Id = id;
        Texto = texto;
        Certo = certo;
        QuestaoId = questaoId;
    }

    public override string ToString()
    {
        return $"Questão: Id={Id}, Texto={Texto}, Certo={Certo}, QuestaoId={QuestaoId}";
    }
}