using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Subject : ISubject
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int ExamPoints { get; set; }

    public IUser? Author { get; private set; }

    public Collection<ILaboratoryWork>? LaboratoryWorks { get; private set; }

    public Collection<ILection>? Lections { get; private set; }

    public Subject(int id, string? name, int examPoints, IUser? author, Collection<ILaboratoryWork>? laboratoryWorks, Collection<ILection>? lections)
    {
        if (examPoints != 100)
        {
            throw new ArgumentException("Баллы за экз должны быть равны 100", nameof(examPoints));
        }

        Id = id;
        Name = name;
        ExamPoints = examPoints;
        Author = author;
        LaboratoryWorks = laboratoryWorks;
        Lections = lections;
    }

    public ISubject? CreateNewVersion(IUser author)
    {
        return new Subject(Id, Name, ExamPoints, author, LaboratoryWorks, Lections);
    }

    public void UpdateExamPoints(int newExamPoints, string newName)
    {
        if (Author == null)
        {
            throw new UnauthorizedAccessException("НЕ ПОНЯТНО какой нужен автор для изменения баллов за экзамен");
        }

        ExamPoints = newExamPoints;
        Name = newName;
    }
}
