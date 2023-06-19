using Microsoft.EntityFrameworkCore;
using TestMaster2.Controller;
using TestMaster2.Models;
using TestMaster2.Interfaces;

namespace TestMaster2.Services;

public class GerenciamentoDeMaterias
{
    private MateriaRepositoryMySQL _materiaRepositoryMySql = new MateriaRepositoryMySQL();
    private ProfessorRepositoryMySQL _professorRepositoryMySql = new ProfessorRepositoryMySQL();
    //private Materia materia = new Materia();

    public void Criar(Professor professor)
    {
        Console.WriteLine("--== DIGITE OS DADOS DO MATERIA: ==--");
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();
        while (string.IsNullOrEmpty(nome))
        {
            Console.WriteLine("Nome não pode estar vázio! Digite novamente:");
            nome = Console.ReadLine();
        }

        Materia materia = new Materia(null, nome, Convert.ToInt32(professor.Id), null);
        _materiaRepositoryMySql.Inserir(materia);
    }

    public void Atualizar(Materia m)
    {
        if (m == null)
        {
            Console.WriteLine("Essa matéria não existe");
        }
        else
        {
            Console.WriteLine("--== DIGITE OS NOVOS DADOS DO MATERIA: ==--");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            while (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Nome não pode estar vázio! Digite novamente:");
                nome = Console.ReadLine();
            }

            Materia materia = new Materia(m.Id, nome, m.ProfessorId, m.AlunosId);
            
            _materiaRepositoryMySql.Atualizar(Convert.ToInt32(m.Id), materia);
        }
        
    }

    public void Deletar()
    {
        Console.WriteLine("DIGITE O ID DA MATERIA A SER DELETADA: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
        }

        _materiaRepositoryMySql.Excluir(id);
    }

    public Materia ObterPorId(int id)
    {
        Materia materia = _materiaRepositoryMySql.ObterPorId(id);
        
        return materia;
    }

    public void ObterTodos()
    {
        List<Materia> materias = _materiaRepositoryMySql.ObterTodos();

        foreach (var materia in materias)
        {
            Console.WriteLine(materia.ToString());
        }
    }
}