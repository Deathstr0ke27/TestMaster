using System.Reflection;
using TestMaster2.Interfaces;
using TestMaster2.Models;

namespace TestMaster2.Controller;
public class QuestaoRepositoryMySQL : Repository<Questao>
{
    public ProvasContext context = new ProvasContext();

    public List<Questao> ObterPorProva(Prova prova)
    {
        return context.Set<Questao>().Where(u => u.ProvaId == prova.Id).ToList();
        //return new List<Questao> { context.Set<Questao>().Find(prova) };
    }
}