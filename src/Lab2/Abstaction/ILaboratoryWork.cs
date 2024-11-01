namespace Itmo.ObjectOrientedProgramming.Lab2.Abstaction;

public interface ILaboratoryWork
{
    int Id { get; set; }

    string? Name { get; set; }

    string? Description { get; set; }

    IEvaluationCriteria? EvaluationCriteria { get; set; }

    int MaxPoints { get; set; }

    IUser? Author { get; set; }

    ILaboratoryWork? CreateNewVersion(IUser newAuthor);

    public void UpdateLaboratoryWork(string newName, string newDescription, IUser? author);
}
