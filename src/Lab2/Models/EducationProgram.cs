using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

internal class EducationProgram : IEducationProgram
{
    public string? Name { get; set; }

    public int Id { get; set; }

    public Collection<ISubject>? Subjects { get; private set; }

    public IUser? Supervisor { get; set; }

    public EducationProgram(int id, string? name, Collection<ISubject>? subjects, IUser? supervisor)
    {
        Id = id;
        Name = name;
        Subjects = subjects;
        Supervisor = supervisor;
    }

    public IEducationProgram CreateNewVersion(IUser newSupervisor)
    {
        ArgumentNullException.ThrowIfNull(newSupervisor);

        return new EducationProgram(Id, Name, Subjects, newSupervisor);
    }
}
