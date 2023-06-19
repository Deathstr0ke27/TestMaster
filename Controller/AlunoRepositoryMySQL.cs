using System.Reflection;
using TestMaster2.Interfaces;
using TestMaster2.Models;

namespace TestMaster2.Controller;

public class AlunoRepositoryMySQL : Repository<Aluno>
{
    public void inscreverClasse(Materia materia, Aluno aluno)
    {
        if (ObterPorId(Convert.ToInt32(aluno.Id)).Materia == null)
        {
            ObterPorId(Convert.ToInt32(aluno.Id)).Materia = materia;
        }
        else
        {
            Console.WriteLine("Você já está inscrito em uma matéria, para entrar em outra você deve desistir da atual.");
        }
        provasContext.SaveChanges();
    }

    public void trocarClasse(Materia materia, Aluno aluno)
    {
        if (ObterPorId(Convert.ToInt32(aluno.Id)).Materia != null)
        {
            if (ObterPorId(Convert.ToInt32(aluno.Id)).Materia == materia)
            {
                Console.WriteLine("Você já está inscrito nessa matéria.");
            }
            else
            {
                ObterPorId(Convert.ToInt32(aluno.Id)).Materia = materia;
            }
        }
        else
        {
            Console.WriteLine("Você ainda não está inscrito em uma matéria, para trocar de matéria você deve estar inscrito em uma matéria.");
        }
        provasContext.SaveChanges();
    }
    
    
}