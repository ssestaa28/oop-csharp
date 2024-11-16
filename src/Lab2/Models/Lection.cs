using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Lection : ILection
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Content { get; set; }

    public IUser? Author { get; set; }

    public int? BasedOnId { get; private set; }

    public Lection(int id, string? name, string? description, string? content, IUser? author, int? basedOnId = null)
    {
        Id = id;
        Name = name;
        Description = description;
        Content = content;
        Author = author;
        BasedOnId = basedOnId;
    }

    public ILection CreateNewVersion(IUser newAuthor)
    {
        return new Lection(Id, Name, Description, Content, newAuthor, Id);
    }

    public void UpdateLection(string newName, string? newDescription, string? newContent, IUser author)
    {
        if (author == null || Author == null || author.Id != Author.Id)
        {
            throw new UnauthorizedAccessException("Только автор может изменять лекции");
        }

        Name = newName;
        Description = newDescription;
        Content = newContent;
    }
}
