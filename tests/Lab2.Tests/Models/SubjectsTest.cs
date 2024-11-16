using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Moq;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab2.Tests.Models;

public class SubjectsTest
{
    [Fact]
    public void CreateSubject_ExamPointsNot100()
    {
        var mockAuthor = new Mock<IUser>();
        var labWorks = new Collection<ILaboratoryWork>();
        var lections = new Collection<ILection>();

        Assert.Throws<ArgumentException>(() => new Subject(1, "Программирование", 90, mockAuthor.Object, labWorks, lections));
    }
}
