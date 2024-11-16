using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositores;

public class EducationProgramRepositoty : IRepository<IEducationProgram>
{
    public Collection<IEducationProgram> EducationPrograms { get; } = new Collection<IEducationProgram>();

    public void Add(IEducationProgram entity)
    {
        EducationPrograms.Add(entity);
    }

    public Collection<IEducationProgram> GetAll()
    {
        return EducationPrograms;
    }

    public IEducationProgram GetById(int id)
    {
        IEducationProgram? educationProgram = EducationPrograms.FirstOrDefault(x => x.Id == id);
        if (educationProgram == null)
        {
            throw new InvalidOperationException($"Образовательные программы с {id} не найдены");
        }

        return educationProgram;
    }
}
