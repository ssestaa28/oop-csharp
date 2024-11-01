using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Abstaction;

public interface ISubject
{
    int Id { get; set; }

    string? Name { get; set; }

    int ExamPoints { get; set; }

    Collection<ILaboratoryWork>? LaboratoryWorks { get; }

    Collection<ILection>? Lections { get; }

    IUser? Author { get; }

    ISubject? CreateNewVersion(IUser author);

    void UpdateExamPoints(int newExamPoints, string newName);
}
