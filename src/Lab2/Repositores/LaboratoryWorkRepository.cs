using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositores;

public class LaboratoryWorkRepository : IRepository<ILaboratoryWork>
{
    public Collection<ILaboratoryWork> LabWorks { get; } = new Collection<ILaboratoryWork>();

    public void Add(ILaboratoryWork entity)
    {
        LabWorks.Add(entity);
    }

    public Collection<ILaboratoryWork> GetAll()
    {
        return LabWorks;
    }

    public ILaboratoryWork GetById(int id)
    {
        ILaboratoryWork? labWork = LabWorks.FirstOrDefault(x => x.Id == id);
        if (labWork == null)
        {
            throw new InvalidOperationException($"Лабораторная работа с {id} не найдены");
        }

        return labWork;
    }
}
