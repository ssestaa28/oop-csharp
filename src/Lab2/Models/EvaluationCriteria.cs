using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class EvaluationCriteria : IEvaluationCriteria
{
    public int Id { get; private set; }

    public string Description { get; private set; }

    public int MaxPoints { get; private set; }

    public EvaluationCriteria(int id, string description, int maxPoints)
    {
        Id = id;
        Description = description;
        MaxPoints = maxPoints;
    }

    public IEvaluationCriteria CreateNewVersion(int newMaxPoints)
    {
        if (newMaxPoints <= 0)
        {
            throw new ArgumentException("Макс баллов должно быть больше нуля");
        }

        return new EvaluationCriteria(Id, Description, newMaxPoints);
    }
}
