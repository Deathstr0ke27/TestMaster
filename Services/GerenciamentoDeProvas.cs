using Microsoft.EntityFrameworkCore;
using TestMaster2.Controller;
using TestMaster2.Models;
using TestMaster2.Interfaces;

namespace TestMaster2.Services;
public class GerenciamentoDeProvas
{
    private ProvaRepositoryMySQL _provaRepositoryMySql = new ProvaRepositoryMySQL();
    private MateriaRepositoryMySQL _materiaRepositoryMySql = new MateriaRepositoryMySQL();

    public void Criar()
    {
        Console.WriteLine("--== DIGITE OS DADOS DO PROVA: ==--");
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Peso:");
        float peso;
        while (!float.TryParse(Console.ReadLine(), out peso))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o peso: ");
        }
        if (peso <= 0)
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o peso maior que zero: ");
        }

        Console.WriteLine("Prazo:");
        DateTime prazo;
        while (!DateTime.TryParse(Console.ReadLine(), out prazo))
        {
            Console.WriteLine("Entrada inválida. Digite uma data válida para o prazo: ");
        }

        Console.WriteLine("Id da Materia: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
        }

        Materia materia = _materiaRepositoryMySql.ObterPorId(id);

        if (materia.Id == null)
        {
            Console.WriteLine("Esse ID não existe no banco de dados, insira um que exista: ");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
            }
        }
        
        Prova prova = new Prova(null, prazo, peso, nome, Convert.ToInt32(materia.Id));

        _provaRepositoryMySql.Inserir(prova);
    }

    public void Atualizar(Prova p)
    {
        // Console.WriteLine("DIGITE O ID DA PROVA A SER ALTERADA: ");
        // int id;
        // while (!int.TryParse(Console.ReadLine(), out id))
        // {
        //     Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Prova: ");
        // }

        Console.WriteLine("--== DIGITE OS NOVOS DADOS DA PROVA: ==--");
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();
        while (string.IsNullOrEmpty(nome))
        {
            Console.WriteLine("Nome não pode estar vázio! Digite novamente:");
            nome = Console.ReadLine();
        }

        Console.WriteLine("Peso: ");
        float peso;
        while (!float.TryParse(Console.ReadLine(), out peso))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o peso: ");
        }
        if (peso <= 0)
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o peso maior que zero: ");
        }

        Console.WriteLine("Prazo:");
        DateTime prazo;
        while (!DateTime.TryParse(Console.ReadLine(), out prazo))
        {
            Console.WriteLine("Entrada inválida. Digite uma data válida para o prazo: ");
        }

        Console.WriteLine("Id da Materia: ");
        int idm;
        while (!int.TryParse(Console.ReadLine(), out idm))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
        }

        Materia materia = _materiaRepositoryMySql.ObterPorId(idm);

        if (materia.Id == null)
        {
            Console.WriteLine("Esse ID não existe no banco de dados, insira um que exista: ");
            while (!int.TryParse(Console.ReadLine(), out idm))
            {
                Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
            }
        }

        Prova prova = new Prova(p.Id, prazo, peso, nome, Convert.ToInt32(materia.Id));

        _provaRepositoryMySql.Atualizar(Convert.ToInt32(p.Id), prova);
    }

    public void Deletar()
    {
        Console.WriteLine("DIGITE O ID DA PROVA A SER DELETADA: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Prova: ");
        }

        _provaRepositoryMySql.Excluir(id);
    }

    public Prova ObterPorId(int id)
    {
        Prova prova = _provaRepositoryMySql.ObterPorId(id);

        return prova;
    }

    public void ObterTodos()
    {
        List<Prova> provas = _provaRepositoryMySql.ObterTodos();

        foreach (var prova in provas)
        {
            Console.WriteLine(prova.ToString());
        }
    }
    public void ObterPorMaterias(Materia materia)
    {
        List<Prova> provas = _provaRepositoryMySql.ObterPorMateria(materia);

        foreach (var prova in provas)
        {
            Console.WriteLine(prova.ToString());
        }
    }
}
