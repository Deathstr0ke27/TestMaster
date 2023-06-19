using System.Reflection;
using TestMaster2.Interfaces;
using TestMaster2.Models;

namespace TestMaster2.Controller;

public class AlternativaRepositoryMySQL : Repository<Alternativa>
{
    public ProvasContext context = new ProvasContext();

    public List<Alternativa> ObterPorQuestao(Questao questao)
    {
        return context.Set<Alternativa>().Where(u => u.QuestaoId == questao.Id).ToList();
        //return new List<Alternativa> { Context.Set<Alternativa>().Find(questao) };
    }
}