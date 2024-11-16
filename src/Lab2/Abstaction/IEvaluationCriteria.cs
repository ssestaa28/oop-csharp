namespace Itmo.ObjectOrientedProgramming.Lab2.Abstaction;

public interface IEvaluationCriteria
{
    int Id { get; }

    string Description { get; }

    int MaxPoints { get; }

    IEvaluationCriteria CreateNewVersion(int newMaxPoints);
}
