using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositores;

public class UserRepository : IRepository<IUser>
{
    public Collection<IUser> Users { get; } = new Collection<IUser>();

    public void Add(IUser entity)
    {
        Users.Add(entity);
    }

    public Collection<IUser> GetAll()
    {
        return Users;
    }

    public IUser GetById(int id)
    {
        IUser? user = Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            throw new InvalidOperationException($"Пользователи с {id} не найдены");
        }

        return user;
    }
}
