using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class LaboratoryWork : ILaboratoryWork
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public IEvaluationCriteria? EvaluationCriteria { get; set; }

    public int MaxPoints { get; set; }

    public IUser? Author { get; set; }

    public LaboratoryWork(int id, string? name, string? description, IEvaluationCriteria? evaluationCriteria, int maxPoints, IUser? author)
    {
        Id = id;
        Name = name;
        Description = description;
        EvaluationCriteria = evaluationCriteria;
        MaxPoints = maxPoints;
        Author = author;
    }

    public ILaboratoryWork CreateNewVersion(IUser newAuthor)
    {
        return new LaboratoryWork(Id, Name, Description, EvaluationCriteria, MaxPoints, newAuthor);
    }

    public void UpdateLaboratoryWork(string newName, string? newDescription, IUser? author)
    {
        if (author == null || Author == null || author.Id != Author.Id)
        {
            throw new UnauthorizedAccessException("Только автор может изменять лабу");
        }

        Name = newName;
        Description = newDescription;
    }
}
