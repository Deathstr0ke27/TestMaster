using Microsoft.EntityFrameworkCore;
using TestMaster2.Controller;
using TestMaster2.Models;

namespace TestMaster2.Services;

public class GerenciamentoDeAlunoProvas
{
    private AlunoRepositoryMySQL _alunoRepositoryMySql = new AlunoRepositoryMySQL();
    private ProvaRepositoryMySQL _provaRepositoryMySql = new ProvaRepositoryMySQL();
    private AlunoProvaRepositoryMySQL _alunoProvaRepositoryMySql = new AlunoProvaRepositoryMySQL();

    public void Adicionar(Aluno a, Prova p, Double n)
    {
        AlunoProva alunoProva = new AlunoProva(a.Id, p.Id, true, n);
        _alunoProvaRepositoryMySql.Inserir(alunoProva);
    }

    public AlunoProva ObterPorId(Aluno a, Prova p)
    {
        List<AlunoProva> alunoProvas = _alunoProvaRepositoryMySql.ObterTodosPorIdAluno(Convert.ToInt32(a.Id));

        foreach (var alunoProva in alunoProvas)
        {
            if (alunoProva.ProvaId == p.Id)
            {
                Console.WriteLine("Você já fez essa prova, tente fazer outra!");
                return alunoProva;
            }
        }
        Console.WriteLine("Você ainda não fez essa prova.");
        return null;
    }
}