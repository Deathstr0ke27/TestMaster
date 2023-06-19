using Microsoft.EntityFrameworkCore;
using TestMaster2.Controller;
using TestMaster2.Models;

namespace TestMaster2.Services;

public class GerenciamentoDeAlunos
{
    private AlunoRepositoryMySQL _alunoRepositoryMySql = new AlunoRepositoryMySQL();
    private MateriaRepositoryMySQL _materiaRepositoryMySql = new MateriaRepositoryMySQL();
    private ProvaRepositoryMySQL _provaRepositoryMySql = new ProvaRepositoryMySQL();
    private AlternativaRepositoryMySQL _alternativaRepositoryMySql = new AlternativaRepositoryMySQL();
    private QuestaoRepositoryMySQL _questaoRepositoryMySql = new QuestaoRepositoryMySQL();

    private GerenciamentoDeMaterias gerDeMaterias = new GerenciamentoDeMaterias();
    private GerenciamentoDeProvas gerDeProvas = new GerenciamentoDeProvas();
    //private Aluno aluno = new Aluno();

    public Aluno registerNewAluno(ProvasContext context)
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
            if (_alunoRepositoryMySql.ExisteNaBaseDeDados("tb_aluno", "Nome", nome) != null)
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
            if (_alunoRepositoryMySql.ExisteNaBaseDeDados("tb_aluno", "Login", login) != null)
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
            Console.WriteLine("Digite sua senha novamente");
            senha2 = Console.ReadLine();
            if (senha1 != senha2)
                Console.WriteLine("As senhas não são iguais, digite a segunda senha novamente:");
            else
                break;
        }


        try
        {
            Aluno aluno = new Aluno(null, nome, login, senha1, null);
            _alunoRepositoryMySql.Inserir(aluno);
            return aluno;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Aluno ValidarAluno(ProvasContext context)
    {
        string login, senha;
        Aluno databaseAluno;

        Console.WriteLine("Possui um perfil? [s/n]");
        if (Console.ReadKey().KeyChar.ToString() == "n")
        {
            Console.WriteLine();
            return registerNewAluno(context);
        }

        Console.WriteLine();


        while (true)
        {
            Console.WriteLine("Digite seu Login");
            login = Console.ReadLine();
            if (login == "sair")
                return null;

            databaseAluno = _alunoRepositoryMySql.ExisteNaBaseDeDados("tb_aluno", "Login", login);
            if (databaseAluno == null)
                Console.WriteLine("Login não cadastrado no banco de dados! Digite novamente ou digite [sair]");
            else
                break;
        }

        while (true)
        {
            Console.WriteLine("Digite sua senha");
            senha = Console.ReadLine();
            if (senha != databaseAluno.Senha)
                Console.WriteLine("Senha incorreta!");
            else
                break;
        }

        return databaseAluno;
    }

    //Ingressar em matéria
    public void Ingressar(Aluno aluno)
    {
        Console.WriteLine("--== MATERIAS ==--");
        gerDeMaterias.ObterTodos();

        Console.WriteLine("Id da Materia: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o Id da Materia: ");
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
        
        string nome = null;

        while (nome != materia.Nome)
        {
            Console.WriteLine("Nome da matéria (Se não souber o nome digite VOLTAR para voltar para o menu): ");
            nome = Console.ReadLine();

            if (nome == "VOLTAR")
            {
                break;
            }

            if (nome == materia.Nome)
            {
                _alunoRepositoryMySql.inscreverClasse(materia, aluno);
            }
            else
            {
                Console.WriteLine("Nome errado.");
            }
        }
    }
    
    //Trocar de matéria
    public void Trocar(Aluno aluno)
    {
        Console.WriteLine("--== MATERIAS ==--");
        gerDeMaterias.ObterTodos();
        
        Console.WriteLine("Id da Materia para a qual você quer trocar: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o Id da Materia: ");
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
        
        string nome = null;

        while (nome != materia.Nome)
        {
            Console.WriteLine("Nome da matéria (Se não souber o nome digite VOLTAR para voltar para o menu): ");
            nome = Console.ReadLine();

            if (nome == "VOLTAR")
            {
                break;
            }

            if (nome == materia.Nome)
            {
                _alunoRepositoryMySql.trocarClasse(materia, aluno);
            }
            else
            {
                Console.WriteLine("Nome errado.");
            }
        }
    }

    public void ObterProvasAluno(Aluno aluno)
    {
        Materia materia = _materiaRepositoryMySql.ObterPorId(aluno.MateriaId);
        gerDeProvas.ObterPorMaterias(materia);
       
    }
    
    public void FazerProva(Aluno aluno)
    {
        int acertos = 0;

        Console.WriteLine("--== PROVAS ==--");
        ObterProvasAluno(aluno);

        Console.WriteLine("Id da Prova: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o Id da Prova: ");
        }

        Prova prova = _provaRepositoryMySql.ObterPorId(id);

        List<Questao> questoes = _questaoRepositoryMySql.ObterPorProva(prova);

        foreach (var questao in questoes)
        {
            List<Alternativa> alternativas = _alternativaRepositoryMySql.ObterPorQuestao(questao);
            Console.WriteLine(questao.Nome);

            Alternativa certo = null;

            foreach (var alternativa in alternativas)
            {
                Console.WriteLine(alternativa.Id + " - " + alternativa.Texto);
                if (alternativa.Certo)
                {
                    certo = alternativa;
                }
            }

            Console.WriteLine("Resposta: ");
            int resposta;
            while (!int.TryParse(Console.ReadLine(), out resposta))
            {
                Console.WriteLine("Entrada inválida. Digite um número válido para a Resposta: ");
            }

            if (certo.Id == resposta)
            {
                acertos++;
            }
        }

        Console.WriteLine(acertos + " / " + questoes.Count);
        Console.WriteLine("Nota: " + Convert.ToDouble(acertos) * 100 / questoes.Count);
    }

    public Materia ObterMateriaAluno(Aluno aluno)
    {
        Materia materia = _materiaRepositoryMySql.ObterPorId(aluno.MateriaId);
        return materia;
    }



    public void ImprimirMateria(Aluno aluno)
    {
        Materia materia = ObterMateriaAluno(aluno);
        Console.WriteLine(materia);
    }
    
}