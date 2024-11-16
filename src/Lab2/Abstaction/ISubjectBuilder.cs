using Itmo.ObjectOrientedProgramming.Lab2.Models;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Abstaction;

public interface ISubjectBuilder
{
    ISubjectBuilder SetId(int id);

    ISubjectBuilder SetName(string name);

    ISubjectBuilder SetExamPoints(int examPoints);

    ISubjectBuilder SetAuthor(IUser author);

    ISubjectBuilder SetLaboratoryWorks(Collection<ILaboratoryWork> labWorks);

    ISubjectBuilder SetLections(Collection<ILection> lections);

    Subject Build();
}
