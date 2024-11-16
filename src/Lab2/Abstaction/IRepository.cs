using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Abstaction;

public interface IRepository<T>
{
    void Add(T entity);

    T GetById(int id);

    Collection<T> GetAll();
}