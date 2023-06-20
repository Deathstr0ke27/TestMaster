using System.Reflection;
using TestMaster2.Interfaces;
using TestMaster2.Models;

namespace TestMaster2.Controller;

public class AlunoProvaRepositoryMySQL : Repository<AlunoProva>
{
    public ProvasContext context = new ProvasContext();

    public List<AlunoProva> ObterTodosPorIdAluno(int id)
    {
        return context.Set<AlunoProva>().Where(u => u.AlunoId == id).ToList();
    }
    public List<AlunoProva> ObterTodosPorIdProva(int id)
    {
        return context.Set<AlunoProva>().Where(u => u.ProvaId == id).ToList();
    }
}