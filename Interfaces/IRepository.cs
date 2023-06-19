using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TestMaster2.Models;

namespace TestMaster2.Interfaces;

public interface IRepository<T>
{
    public void Inserir(T entity);
    public void Atualizar(int id, T newEntity);
    public void Excluir(int? id);
    public T ObterPorId(int? id);
    public List<T> ObterTodos();
    public T ExisteNaBaseDeDados(string tabela, string coluna, string dado);

}

public class Repository<T> : IRepository<T> where T : class
{
    public ProvasContext provasContext = new ProvasContext();

    public void Inserir(T entity)
    {
        provasContext.Set<T>().Add(entity);
        provasContext.SaveChanges();
    }

    public void Atualizar(int id, T newEntity)
    {
        provasContext.Entry(provasContext.Set<T>().Find(id)).CurrentValues.SetValues(newEntity);
        provasContext.SaveChanges();
    }

    public void Excluir(int? id)
    {
        provasContext.Set<T>().Remove(provasContext.Set<T>().Find(id));
        provasContext.SaveChanges();
    }

    public T ObterPorId(int? id)
    {
        return provasContext.Set<T>().Find(id);
    }

    public List<T> ObterTodos()
    {
        return provasContext.Set<T>().ToList();
    }
    public T ExisteNaBaseDeDados(string tabela, string coluna, string dado)
    {
        var a = provasContext.Set<T>()
            .FromSqlRaw($"SELECT * FROM {tabela} Where {coluna} =  '{dado}'")
            .ToList().FirstOrDefault();

        return a;
    }
}