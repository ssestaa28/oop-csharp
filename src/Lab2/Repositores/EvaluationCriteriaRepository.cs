using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositores;

public class EvaluationCriteriaRepository : IRepository<IEvaluationCriteria>
{
    public Collection<IEvaluationCriteria> Criteria { get; } = new Collection<IEvaluationCriteria>();

    public void Add(IEvaluationCriteria entity)
    {
        Criteria.Add(entity);
    }

    public Collection<IEvaluationCriteria> GetAll()
    {
        return Criteria;
    }

    public IEvaluationCriteria GetById(int id)
    {
        IEvaluationCriteria? criteria = Criteria.FirstOrDefault(x => x.Id == id);
        if (criteria == null)
        {
            throw new InvalidOperationException($"Критерии оценивания под {id} не найдены");
        }

        return criteria;
    }
}
