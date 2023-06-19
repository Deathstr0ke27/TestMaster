using Microsoft.EntityFrameworkCore;
using TestMaster2.Controller;
using TestMaster2.Models;
using TestMaster2.Interfaces;

namespace TestMaster2.Services;

public class GerenciamentoDeQuestoes
{
    private QuestaoRepositoryMySQL _questaoRepositoryMySql = new QuestaoRepositoryMySQL();
    private ProvaRepositoryMySQL _provaRepositoryMySql = new ProvaRepositoryMySQL();
    //private Materia materia = new Materia();

    public void Criar()
    {
        Console.WriteLine("--== DIGITE OS DADOS DA QUESTAO: ==--");
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();
        while (string.IsNullOrEmpty(nome))
        {
            Console.WriteLine("Nome não pode estar vázio! Digite novamente:");
            nome = Console.ReadLine();
        }

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

        Console.WriteLine("Id da Prova: ");
        int idp;
        while (!int.TryParse(Console.ReadLine(), out idp))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
        }

        Prova prova = _provaRepositoryMySql.ObterPorId(idp);

        if (prova.Id == null)
        {
            Console.WriteLine("Esse ID não existe no banco de dados, insira um que exista: ");
            while (!int.TryParse(Console.ReadLine(), out idp))
            {
                Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
            }
        }
        
        Questao questao = new Questao(null, nome, peso, Convert.ToInt32(prova.Id));
        _questaoRepositoryMySql.Inserir(questao);
    }

    public void Atualizar(Questao q)
    {
        // Console.WriteLine("DIGITE O ID DA QUESTÃO A SER ALTERADA: ");
        // int id;
        // while (!int.TryParse(Console.ReadLine(), out id))
        // {
        //     Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Questão: ");
        // }

        Console.WriteLine("--== DIGITE OS NOVOS DADOS DA QUESTÃO: ==--");
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();
        while (string.IsNullOrEmpty(nome))
        {
            Console.WriteLine("Nome não pode estar vázio! Digite novamente:");
            nome = Console.ReadLine();
        }

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

        Console.WriteLine("Id da Prova: ");
        int idp;
        while (!int.TryParse(Console.ReadLine(), out idp))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
        }

        Prova prova = _provaRepositoryMySql.ObterPorId(idp);
    
        if (prova.Id == null)
        {
            Console.WriteLine("Esse ID não existe no banco de dados, insira um que exista: ");
            while (!int.TryParse(Console.ReadLine(), out idp))
            {
                Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
            }
        }
        
        Questao questao = new Questao(q.Id, nome, peso, Convert.ToInt32(prova.Id));

        _questaoRepositoryMySql.Atualizar(Convert.ToInt32(q.Id), questao);
    }

    public void Deletar()
    {
        Console.WriteLine("DIGITE O ID DA QUESTÃO A SER DELETADA: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
        }

        _questaoRepositoryMySql.Excluir(id);
    }

    public Questao ObterPorId(int id)
    {
        Questao questao = _questaoRepositoryMySql.ObterPorId(id);

        return questao;
    }

    public void ObterTodos()
    {
        List<Questao> questoes = _questaoRepositoryMySql.ObterTodos();

        foreach (var questao in questoes)
        {
            Console.WriteLine(questao.ToString());
        }
    }
}