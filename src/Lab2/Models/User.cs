using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class User : IUser
{
    public string? Name { get; set; }

    public int Id { get; set; }

    public User(string name, int id)
    {
        Id = id;
        Name = name;
    }
}