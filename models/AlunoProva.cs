using System.ComponentModel.DataAnnotations.Schema;

namespace TestMaster2.Models;
[Table("tb_aluno_prova")]
public class AlunoProva
{
    
    [ForeignKey("AlunoId")]
    public Aluno Aluno { get; set; }
    public int AlunoId { get; set; }
    [ForeignKey("ProvaId")]
    public Prova Prova { get; set; }
    public int ProvaId { get; set; }
    public bool Feito { get; set; }
    public double Nota { get; set; }

    public AlunoProva(int alunoId, int provaId, bool feito, double nota)
    {
        AlunoId = alunoId;
        ProvaId = provaId;
        Feito = feito;
        Nota = nota;
    }

    public override string ToString()
    {
        return $"Aluno={AlunoId}, Prova={ProvaId}, Já fez a prova={Feito}, Nota={Nota}";
    }
}