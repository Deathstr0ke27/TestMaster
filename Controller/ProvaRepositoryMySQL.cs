using System.Reflection;
using TestMaster2.Interfaces;
using TestMaster2.Models;

namespace TestMaster2.Controller;
public class ProvaRepositoryMySQL : Repository<Prova>
{
    public ProvasContext context = new ProvasContext();
    public List<Prova> ObterPorMateria(Materia materia)
    {
        return context.Set<Prova>().Where(u => u.MateriaId == materia.Id).ToList();
    }
}