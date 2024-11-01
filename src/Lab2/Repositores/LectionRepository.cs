using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositores;

public class LectionRepository : IRepository<ILection>
{
    public Collection<ILection> Lections { get; } = new Collection<ILection>();

    public void Add(ILection entity)
    {
        Lections.Add(entity);
    }

    public Collection<ILection> GetAll()
    {
        return Lections;
    }

    public ILection GetById(int id)
    {
        ILection? lection = Lections.FirstOrDefault(x => x.Id == id);
        if (lection == null)
        {
            throw new InvalidOperationException($"Лекции с {id} не найдены");
        }

        return lection;
    }
}
