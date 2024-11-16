using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositores;

public class SubjectRepository : IRepository<ISubject>
{
    public Collection<ISubject> Subjects { get; } = new Collection<ISubject>();

    public void Add(ISubject entity)
    {
        Subjects.Add(entity);
    }

    public Collection<ISubject> GetAll()
    {
        return Subjects;
    }

    public ISubject GetById(int id)
    {
        ISubject? subject = Subjects.FirstOrDefault(x => x.Id == id);
        if (subject == null)
        {
            throw new InvalidOperationException($"Предметы с {id} не найдены");
        }

        return subject;
    }
}
