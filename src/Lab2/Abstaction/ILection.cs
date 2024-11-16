namespace Itmo.ObjectOrientedProgramming.Lab2.Abstaction;

public interface ILection
{
    int Id { get; set; }

    string? Name { get; set; }

    string? Description { get; set; }

    string? Content { get; set; }

    IUser? Author { get; set; }

    ILection CreateNewVersion(IUser newAuthor);

    void UpdateLection(string newName, string? newDescription, string? newContent, IUser author);
}
