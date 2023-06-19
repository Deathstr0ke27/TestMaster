using Microsoft.EntityFrameworkCore;
using TestMaster2.Controller;
using TestMaster2.Models;
using TestMaster2.Interfaces;

namespace TestMaster2.Services;

public class GerenciamentoDeAlternativas
{
    private AlternativaRepositoryMySQL _alternativaRepositoryMySql = new AlternativaRepositoryMySQL();
    private QuestaoRepositoryMySQL _questaoRepositoryMySql = new QuestaoRepositoryMySQL();
    //private Materia materia = new Materia();

    public void Criar()
    {
        Console.WriteLine("--== DIGITE OS DADOS DA ALTERNATIVA: ==--");
        Console.WriteLine("Texto:");
        string texto = Console.ReadLine();
        while (string.IsNullOrEmpty(texto))
        {
            Console.WriteLine("Nome não pode estar vázio! Digite novamente:");
            texto = Console.ReadLine();
        }

        bool certo = false;
        bool certoValida = false;
        while (!certoValida)
        {
            Console.WriteLine("Certo (true/false):");
            string correta = Console.ReadLine();
            
            if (bool.TryParse(correta, out certo))
            {
                certoValida = true;
            }
            else
            {
                Console.WriteLine("Entrada inválida! Digite 'true' ou 'false'.");
            }
        }

        Console.WriteLine("Id da Questão:");
        int idq = 0;
        while (!int.TryParse(Console.ReadLine(), out idq))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
        }
        Questao q = _questaoRepositoryMySql.ObterPorId(idq);
    
        if (q.Id == null)
        {
            Console.WriteLine("Esse ID não existe no banco de dados, insira um que exista: ");
            while (!int.TryParse(Console.ReadLine(), out idq))
            {
                Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
            }
        }
        
        Alternativa alternativa = new Alternativa(null, texto, certo, Convert.ToInt32(q.Id));
        _alternativaRepositoryMySql.Inserir(alternativa);
        
    }

    public void Atualizar(Alternativa a)
    {
        // Console.WriteLine("DIGITE O ID DA ALTERNATIVA A SER ALTERADA:");
        // int id = 0;
        // bool idValido = false;
        // while (!idValido)
        // {
        //     string idValidar = Console.ReadLine();
        //     if (int.TryParse(idValidar, out id))
        //     {
        //         idValido = true;
        //     }
        //     else
        //     {
        //         Console.WriteLine("Entrada inválida! Digite um número inteiro.");
        //     }
        // }

        Console.WriteLine("--== DIGITE OS NOVOS DADOS DO ALTERNATIVA: ==--");
        Console.WriteLine("Texto:");
        string texto = Console.ReadLine();
        while (string.IsNullOrEmpty(texto))
        {
            Console.WriteLine("Nome não pode estar vázio! Digite novamente:");
            texto = Console.ReadLine();
        }

        bool certo = false;
        bool certoValida = false;
        while (!certoValida)
        {
            Console.WriteLine("Certo (true/false):");
            string correta = Console.ReadLine();
            
            if (bool.TryParse(correta, out certo))
            {
                certoValida = true;
            }
            else
            {
                Console.WriteLine("Entrada inválida! Digite 'true' ou 'false'.");
            }
        }

        Console.WriteLine("Id da Questão:");
        int idq = 0;
        while (!int.TryParse(Console.ReadLine(), out idq))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
        }
        Questao q = _questaoRepositoryMySql.ObterPorId(idq);
    
        if (q.Id == null)
        {
            Console.WriteLine("Esse ID não existe no banco de dados, insira um que exista: ");
            while (!int.TryParse(Console.ReadLine(), out idq))
            {
                Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
            }
        }
        
        Alternativa alternativa = new Alternativa(a.Id, texto, certo, Convert.ToInt32(q.Id));

        _alternativaRepositoryMySql.Atualizar(Convert.ToInt32(a.Id), alternativa);
    }

    public void Deletar()
    {
        Console.WriteLine("DIGITE O ID DA ALTERNATIVA A SER ALTERADA:");
        int id = 0;
        bool idValido = false;
        while (!idValido)
        {
            string idValidar = Console.ReadLine();
            if (int.TryParse(idValidar, out id))
            {
                idValido = true;
            }
            else
            {
                Console.WriteLine("Entrada inválida! Digite um número inteiro.");
            }
        }

        Alternativa alternativa = _alternativaRepositoryMySql.ObterPorId(id);
        if (alternativa != null)
        {
            _alternativaRepositoryMySql.Excluir(id);
        }
        else
        {
            Console.WriteLine("Alternativa não encontrada!");
        }
    }

    public Alternativa ObterPorId(int id)
    {
        
        Alternativa alternativa = _alternativaRepositoryMySql.ObterPorId(id);
        if (alternativa != null)
        {
            Console.WriteLine(alternativa.ToString());
        }
        else
        {
            Console.WriteLine("Alternativa não encontrada!");
        }

        return alternativa;

    }

    public void ObterTodos()
    {
        List<Alternativa> alternativas = _alternativaRepositoryMySql.ObterTodos();

        foreach (var alternativa in alternativas)
        {
            Console.WriteLine(alternativa.ToString());
        }
    }
}