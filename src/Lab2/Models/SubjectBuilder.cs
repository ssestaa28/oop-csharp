using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class SubjectBuilder : ISubjectBuilder
{
    private int _id;
    private string? _name;
    private int _examPoints;
    private IUser? _author;
    private Collection<ILaboratoryWork>? _laboratoryWorks;
    private Collection<ILection>? _lections;

    public ISubjectBuilder SetId(int id)
    {
        _id = id;
        return this;
    }

    public ISubjectBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public ISubjectBuilder SetExamPoints(int examPoints)
    {
        if (examPoints != 100)
        {
            throw new ArgumentException("ExamPoints должно равняться 100");
        }

        _examPoints = examPoints;
        return this;
    }

    public ISubjectBuilder SetAuthor(IUser author)
    {
        _author = author;
        return this;
    }

    public ISubjectBuilder SetLaboratoryWorks(Collection<ILaboratoryWork> labWorks)
    {
        _laboratoryWorks = labWorks;
        return this;
    }

    public ISubjectBuilder SetLections(Collection<ILection> lections)
    {
        _lections = lections;
        return this;
    }

    public Subject Build()
    {
        if (_author == null)
        {
            throw new InvalidOperationException("Автор должен быть указан");
        }

        return new Subject(_id, _name, _examPoints, _author, _laboratoryWorks, _lections);
    }
}