using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Abstaction;

public interface IEducationProgram
{
    string? Name { get; set; }

    int Id { get; set; }

    Collection<ISubject>? Subjects { get; }

    IUser? Supervisor { get; set; }

    IEducationProgram CreateNewVersion(IUser newSepervisor);
}
