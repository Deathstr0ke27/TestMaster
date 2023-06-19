using Microsoft.EntityFrameworkCore;
using TestMaster2.Controller;
using TestMaster2.Models;

namespace TestMaster2.Services;

public class GerenciamentoDeProfessores
{
    private ProfessorRepositoryMySQL _professorRepositoryMySql = new ProfessorRepositoryMySQL();
    //private Professor professor = new Professor();

    public Professor registerNewProfessor(ProvasContext context)
    {
        string nome;
        string login;
        string senha1;
        string senha2;

        while (true)
        {
            Console.WriteLine("Digite seu nome");
            nome = Console.ReadLine();
            while (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Nome não pode estar vázio! Digite novamente:");
                nome = Console.ReadLine();
            }
            if (_professorRepositoryMySql.ExisteNaBaseDeDados("tb_professor", "Nome", nome) != null)
                Console.WriteLine("Nome ja registrado");
            else
                break;
        }

        while (true)
        {
            Console.WriteLine("Digite seu Login");
            login = Console.ReadLine();
            while (string.IsNullOrEmpty(login))
            {
                Console.WriteLine("Login não pode estar vázio! Digite novamente:");
                login = Console.ReadLine();
            }
            if (_professorRepositoryMySql.ExisteNaBaseDeDados("tb_professor", "Login", login) != null)
                Console.WriteLine("Login ja registrado");
            else
                break;
        }

        Console.WriteLine("Digite sua senha"); //Inserir Senha 1
        senha1 = Console.ReadLine();

        while (string.IsNullOrEmpty(senha1))
        {
            Console.WriteLine("Senha inválida! Digite novamente:");
            senha1 = Console.ReadLine();
        }

        while (true)
        {
            Console.WriteLine("Digite seu senha novamente");
            senha2 = Console.ReadLine();
            if (senha1 != senha2)
                Console.WriteLine("As senhas não são iguais, digite a segunda senha novamente:");
            else
                break;
        }


        try
        {
            Professor professor = new Professor(null, nome, login, senha1);
            _professorRepositoryMySql.Inserir(professor);
            return professor;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Professor ValidarProfessor(ProvasContext context)
    {
        string login, senha;
        Professor databaseProfessor;

        Console.WriteLine("Possui um perfil? [s/n]");
        if (Console.ReadKey().KeyChar.ToString() == "n")
        {
            Console.WriteLine();
            return registerNewProfessor(context);
        }

        Console.WriteLine();


        while (true)
        {
            Console.WriteLine("Digite seu Login");
            login = Console.ReadLine();
            if (login == "sair")
                return null;

            databaseProfessor = _professorRepositoryMySql.ExisteNaBaseDeDados("tb_professor", "Login", login);
            if (databaseProfessor == null)
                Console.WriteLine("Login não cadastrado no banco de dados! Digite novamente ou digite [sair]");
            else
                break;
        }

        while (true)
        {
            Console.WriteLine("Digite sua senha");
            senha = Console.ReadLine();
            if (senha != databaseProfessor.Senha)
                Console.WriteLine("Senha incorreta!");
            else
                break;
        }

        return databaseProfessor;
    }
}