using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using TestMaster2.Models;
using TestMaster2;
using TestMaster2.Services;

namespace TestMaster2;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        using (var context = new ProvasContext())
        {
            GerenciamentoDeAlunos gerDeAlunos = new GerenciamentoDeAlunos();
            GerenciamentoDeProfessores gerDeProfessores = new GerenciamentoDeProfessores();
            GerenciamentoDeMaterias gerDeMaterias = new GerenciamentoDeMaterias();
            GerenciamentoDeProvas gerDeProvas = new GerenciamentoDeProvas();
            GerenciamentoDeQuestoes gerDeQuestoes = new GerenciamentoDeQuestoes();
            GerenciamentoDeAlternativas gerDeAlternativas = new GerenciamentoDeAlternativas();
            Aluno aluno = null;
            Professor professor = null;
            int sair = 0;
            bool logado = false;

            //Console.Clear();

            while (sair != 1)
            {
                if (!logado)
                {
                    switch(MenuFuncao())
                    {
                        case 1: //Login Aluno
                            aluno = gerDeAlunos.ValidarAluno(context);
                            logado = true;
                            break;
                        case 2: //Login Professor
                            professor = gerDeProfessores.ValidarProfessor(context);
                            logado = true;
                            break;
                        default:
                            sair = 1;
                            break;
                    }
                }
                else
                {
                    int fim = 0;
                    if (professor !=null)
                    {
                        while (fim != 1)
                        {
                            int voltar = 0;

                            switch(MenuProfessor())
                            {
                                case 1: //Manter materias
                                    while (voltar != 1)
                                    {
                                        switch(MenuProfessorMateria())
                                        {
                                            case 1:
                                                Console.Clear();
                                                gerDeMaterias.Criar(professor);
                                                break;
                                            case 2:
                                                Console.Clear();
                                                Console.WriteLine("DIGITE O ID DA MATERIA A SER EDITADA: ");
                                                int idm;
                                                while (!int.TryParse(Console.ReadLine(), out idm))
                                                {
                                                    Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
                                                }

                                                Materia m = gerDeMaterias.ObterPorId(idm);
                                                gerDeMaterias.Atualizar(m);
                                                break;
                                            case 3:
                                                Console.Clear();
                                                gerDeMaterias.Deletar();
                                                break;
                                            case 4:
                                                Console.Clear();
                                                Console.WriteLine("DIGITE O ID DA MATERIA A SER IMPRESSA: ");
                                                int idmat;
                                                while (!int.TryParse(Console.ReadLine(), out idmat))
                                                {
                                                    Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
                                                }

                                                Materia materia = gerDeMaterias.ObterPorId(idmat);
                                                Console.WriteLine(materia);
                                                break;
                                            case 5:
                                                Console.Clear();
                                                gerDeMaterias.ObterTodos();
                                                break;
                                            default:
                                                voltar = 1;
                                                break;
                                        }
                                    }
                                    
                                    break;
                                case 2: //Manter provas
                                    while (voltar != 1)
                                    {
                                        switch(MenuProfessorProva())
                                        {
                                            case 1:
                                                Console.Clear();
                                                gerDeProvas.Criar();
                                                break;
                                            case 2:
                                                Console.Clear();
                                                Console.WriteLine("DIGITE O ID DA PROVA A SER ALTERADA: ");
                                                int idp;
                                                while (!int.TryParse(Console.ReadLine(), out idp))
                                                {
                                                    Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Prova: ");
                                                }

                                                Prova prova = gerDeProvas.ObterPorId(idp);
                                                gerDeProvas.Atualizar(prova);
                                                break;
                                            case 3:
                                                Console.Clear();
                                                gerDeProvas.Deletar();
                                                break;
                                            case 4:
                                                Console.Clear();
                                                Console.WriteLine("DIGITE O ID DA PROVA A SER IMPRESSA: ");
                                                int idpro;
                                                while (!int.TryParse(Console.ReadLine(), out idpro))
                                                {
                                                    Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Prova: ");
                                                }

                                                Prova p = gerDeProvas.ObterPorId(idpro);
                                                Console.WriteLine(p);
                                                break;
                                            case 5:
                                                Console.Clear();
                                                gerDeProvas.ObterTodos();
                                                break;
                                            default:
                                                voltar = 1;
                                                break;
                                        }
                                    }
                                    break;
                                case 3: // Manter questões
                                    while (voltar != 1)
                                    {
                                        switch(MenuProfessorQuestao())
                                        {
                                            case 1:
                                                Console.Clear();
                                                gerDeQuestoes.Criar();
                                                break;
                                            case 2:
                                                Console.Clear();
                                                Console.WriteLine("DIGITE O ID DA QUESTÃO A SER ALTERADA: ");
                                                int idq;
                                                while (!int.TryParse(Console.ReadLine(), out idq))
                                                {
                                                    Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Questão: ");
                                                }

                                                Questao questao = gerDeQuestoes.ObterPorId(idq);
                                                gerDeQuestoes.Atualizar(questao);
                                                break;
                                            case 3:
                                                Console.Clear();
                                                gerDeQuestoes.Deletar();
                                                break;
                                            case 4:
                                                Console.Clear();
                                                Console.WriteLine("DIGITE O ID DA PROVA A SER IMPRESSA: ");
                                                int idque;
                                                while (!int.TryParse(Console.ReadLine(), out idque))
                                                {
                                                    Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Prova: ");
                                                }

                                                Questao q = gerDeQuestoes.ObterPorId(idque);
                                                Console.WriteLine(q);
                                                break;
                                            case 5:
                                                Console.Clear();
                                                gerDeQuestoes.ObterTodos();
                                                break;
                                            default:
                                                voltar = 1;
                                                break;
                                        }
                                    }
                                    break;
                                case 4: // Manter alternativas
                                    while (voltar != 1)
                                    {
                                        switch(MenuProfessorAlternativa())
                                        {
                                            case 1:
                                                Console.Clear();
                                                gerDeAlternativas.Criar();
                                                break;
                                            case 2:
                                                Console.Clear();
                                                Console.WriteLine("DIGITE O ID DA ALTERNATIVA A SER ALTERADA: ");
                                                int ida;
                                                while (!int.TryParse(Console.ReadLine(), out ida))
                                                {
                                                    Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Alternativa: ");
                                                }

                                                Alternativa alternativa = gerDeAlternativas.ObterPorId(ida);
                                                gerDeAlternativas.Atualizar(alternativa);
                                                break;
                                            case 3:
                                                Console.Clear();
                                                gerDeAlternativas.Deletar();
                                                break;
                                            case 4:
                                                Console.Clear();
                                                Console.WriteLine("DIGITE O ID DA ALTERNATIVA A SER ALTERADA:");
                                                int idalt = 0;
                                                bool idValido = false;
                                                while (!idValido)
                                                {
                                                    string idValidar = Console.ReadLine();
                                                    if (int.TryParse(idValidar, out idalt))
                                                    {
                                                        idValido = true;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Entrada inválida! Digite um número inteiro.");
                                                    }
                                                }
                                                gerDeAlternativas.ObterPorId(idalt);
                                                break;
                                            case 5:
                                                Console.Clear();
                                                gerDeAlternativas.ObterTodos();
                                                break;
                                            default:
                                                voltar = 1;
                                                break;
                                        }
                                    }
                                    break;
                                default:
                                    logado = false;
                                    professor = null;
                                    fim = 1;
                                    break;
                            }
                        }
                    }
                    else if (aluno != null)
                    {
                        while (fim != 1)
                        {
                            int voltar = 0;

                            switch(MenuAluno())
                            {
                                case 1: // Manter matéria
                                    while (voltar != 1)
                                    {
                                        switch(MenuAlunoMateria())
                                        {
                                            case 1: // Ingressar na matéria
                                                Console.Clear();
                                                gerDeAlunos.Ingressar(aluno);
                                                break;
                                            // Trocar de matéria
                                            case 2:
                                                Console.Clear();
                                                gerDeAlunos.Trocar(aluno);
                                                break;
                                            case 3: // Repensar isso tal vez, vou fazer um ver minha matéria
                                                Console.Clear();
                                                gerDeAlunos.ImprimirMateria(aluno);
                                                break;
                                            case 4: // Repensar isso tal vez
                                                Console.Clear();
                                                gerDeMaterias.ObterTodos();
                                                break;
                                            default:
                                                voltar = 1;
                                                break;
                                        }
                                    }
                                    break;
                                case 2: // Manter provas
                                    while (voltar != 1)
                                    {
                                        switch(MenuAlunoProva())
                                        {
                                            case 1: // Fazer a prova
                                                Console.Clear();
                                                gerDeAlunos.FazerProva(aluno);
                                                break;
                                            case 2: // Obter por ID
                                                Console.Clear();
                                                Console.WriteLine("DIGITE O ID DA PROVA A SER IMPRESSA: ");
                                                int idprova;
                                                while (!int.TryParse(Console.ReadLine(), out idprova))
                                                {
                                                    Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Prova: ");
                                                }

                                                Prova prova = gerDeProvas.ObterPorId(idprova);
                                                Console.WriteLine(prova);
                                                break;
                                            case 3: // Obter todos
                                                Console.Clear();
                                                gerDeProvas.ObterTodos();
                                                break;
                                            default:
                                                voltar = 1;
                                                break;
                                        }
                                    }
                                    break;
                                default:
                                    logado = false;
                                    aluno = null;
                                    fim = 1;
                                    break;
                            }
                        }
                    }

                }
            } 

        }
    }

    public static int MenuFuncao()
    {
        int op = 0;
        bool avancar = false;

        while (!avancar)
        {
            Console.WriteLine(
                "A ferramenta TestMaster é direcionada a 2 tipos diferentes de usuários, selecione a opção que melhor se encaixa para você:");
            Console.WriteLine("1 - Sou um aluno, quero ter acesso a minha matéria e minhas provas.");
            Console.WriteLine("2 - Sou um professor, quero editar provas.");
            Console.WriteLine("0 - Quero sair da ferramenta.");
            Console.WriteLine("Opção: ");

            if (int.TryParse(Console.ReadLine(), out op))
            {
                if (op >= 0 && op <= 2)
                {
                    avancar = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida, insira uma opção válida!");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção inválida, insira uma opção válida!");
            }
        }

        return op;
    }
    public static int MenuProfessor()
    {
        int op = 0;
        bool avancar = false;
        
        while (!avancar)
        {
            Console.Clear();
            Console.WriteLine("Olá Professor aqui estão as suas opções ao usar o TestMaster:");
            Console.WriteLine("1 - Manter matérias (Criar, editar e entrar).");
            Console.WriteLine("2 - Manter provas (Criar, editar e enviar).");
            Console.WriteLine("3 - Manter questões (Criar, editar e enviar).");
            Console.WriteLine("4 - Manter alternativas (Criar, editar e enviar).");
            Console.WriteLine("0 - Quero sair da ferramenta.");
            Console.WriteLine("Opção: ");

            if (int.TryParse(Console.ReadLine(), out op))
            {
                if (op >=0 && op <=4)
                {
                    avancar = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida, insira uma opção válida!");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção inválida, insira uma opção válida!");
            }
        }
        return op;
    }

    public static int MenuAluno()
    {
        int op = 0;
        bool avancar = false;
        
        while (!avancar)
        {
            Console.Clear();
            Console.WriteLine("Olá Aluno aqui estão as suas opções ao usar o TestMaster:");
            Console.WriteLine("1 - Manter matérias (Ingressar, sair e ver matéria).");
            Console.WriteLine("2 - Manter provas (Selecionar, fazer e desistir).");
            Console.WriteLine("0 - Quero sair da ferramenta.");
            Console.WriteLine("Opção: ");

            if (int.TryParse(Console.ReadLine(), out op))
            {
                if (op >=0 && op <=2)
                {
                    avancar = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida, insira uma opção válida!");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção inválida, insira uma opção válida!");
            }
        }
        return op;
    }
    public static int MenuProfessorMateria()
    {
        int op = 0;
        bool avancar = false;
        
        while (!avancar)
        {
            Console.WriteLine("Olá Professor aqui estão as suas opções de mantenimento de matérias:");
            Console.WriteLine("1 - Criar.");
            Console.WriteLine("2 - Atualizar.");
            Console.WriteLine("3 - Deletar.");
            Console.WriteLine("4 - Obter por ID.");
            Console.WriteLine("5 - Obter todos.");
            Console.WriteLine("0 - Quero voltar para a opção anterior.");
            Console.WriteLine("Opção: ");

            if (int.TryParse(Console.ReadLine(), out op))
            {
                if (op >=0 && op <=5)
                {
                    avancar = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida, insira uma opção válida!");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção inválida, insira uma opção válida!");
            }
        }
        return op;
    }

    public static int MenuAlunoMateria()
    {
        int op = 0;
        bool avancar = false;
        
        while (!avancar)
        {
            Console.WriteLine("Olá Aluno aqui estão as suas opções de mantenimento de matérias:");
            Console.WriteLine("1 - Ingressar.");
            Console.WriteLine("2 - Trocar/Mudar");
            Console.WriteLine("3 - Ver matéria atual.");
            Console.WriteLine("4 - Obter todos.");
            Console.WriteLine("0 - Quero voltar para a opção anterior.");
            Console.WriteLine("Opção: ");

            if (int.TryParse(Console.ReadLine(), out op))
            {
                if (op >=0 && op <=4)
                {
                    avancar = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida, insira uma opção válida!");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção inválida, insira uma opção válida!");
            }
        }
        return op;
    }

    public static int MenuProfessorProva()
    {
        int op = 0;
        bool avancar = false;
        
        while (!avancar)
        {
            Console.WriteLine("Olá Professor aqui estão as suas opções de mantenimento de provas:");
            Console.WriteLine("1 - Criar.");
            Console.WriteLine("2 - Atualizar.");
            Console.WriteLine("3 - Deletar.");
            Console.WriteLine("4 - Obter por ID.");
            Console.WriteLine("5 - Obter todos.");
            Console.WriteLine("0 - Quero voltar para a opção anterior.");
            Console.WriteLine("Opção: ");

            if (int.TryParse(Console.ReadLine(), out op))
            {
                if (op >=0 && op <=5)
                {
                    avancar = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida, insira uma opção válida!");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção inválida, insira uma opção válida!");
            }
        }
        return op;
    }

    public static int MenuAlunoProva()
    {
        int op = 0;
        bool avancar = false;
        
        while (!avancar)
        {
            Console.WriteLine("Olá Aluno aqui estão as suas opções de mantenimento de provas:");
            Console.WriteLine("1 - Fazer prova.");
            Console.WriteLine("2 - Obter por ID.");
            Console.WriteLine("3 - Obter todos.");
            Console.WriteLine("0 - Quero voltar para a opção anterior.");
            Console.WriteLine("Opção: ");

            if (int.TryParse(Console.ReadLine(), out op))
            {
                if (op >=0 && op <=3)
                {
                    avancar = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida, insira uma opção válida!");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção inválida, insira uma opção válida!");
            }
        }
        return op;
    }

    public static int MenuProfessorQuestao()
    {
        int op = 0;
        bool avancar = false;
        
        while (!avancar)
        {
            Console.WriteLine("Olá Professor aqui estão as suas opções de mantenimento de questão:");
            Console.WriteLine("1 - Criar.");
            Console.WriteLine("2 - Atualizar.");
            Console.WriteLine("3 - Deletar.");
            Console.WriteLine("4 - Obter por ID.");
            Console.WriteLine("5 - Obter todos.");
            Console.WriteLine("0 - Quero voltar para a opção anterior.");
            Console.WriteLine("Opção: ");

            if (int.TryParse(Console.ReadLine(), out op))
            {
                if (op >=0 && op <=5)
                {
                    avancar = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida, insira uma opção válida!");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção inválida, insira uma opção válida!");
            }
        }
        return op;
    }
    
    public static int MenuProfessorAlternativa()
    {
        int op = 0;
        bool avancar = false;
        
        while (!avancar)
        {
            Console.WriteLine("Olá Professor aqui estão as suas opções de mantenimento de alternativa:");
            Console.WriteLine("1 - Criar.");
            Console.WriteLine("2 - Atualizar.");
            Console.WriteLine("3 - Deletar.");
            Console.WriteLine("4 - Obter por ID.");
            Console.WriteLine("5 - Obter todos.");
            Console.WriteLine("0 - Quero voltar para a opção anterior.");
            Console.WriteLine("Opção: ");

            if (int.TryParse(Console.ReadLine(), out op))
            {
                if (op >=0 && op <=5)
                {
                    avancar = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida, insira uma opção válida!");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção inválida, insira uma opção válida!");
            }
        }
        return op;
    }
}