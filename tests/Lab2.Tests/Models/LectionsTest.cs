using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Moq;
using Xunit;

namespace Lab2.Tests.Models;

public class LectionsTest
{
    [Fact]
    public void NotAuthor_Update_Lections_IsNotCreative()
    {
        var mockAuthor = new Mock<IUser>();
        mockAuthor.SetupGet(a => a.Id).Returns(1);

        var otherAutor = new Mock<IUser>();
        otherAutor.SetupGet(a => a.Id).Returns(2);

        var lection = new Lection(1, "Название", "Опимание", "Содержаие", mockAuthor.Object);

        Assert.Throws<UnauthorizedAccessException>(() => lection.UpdateLection("New название", "New описание", "New содержание", otherAutor.Object));
    }

    [Fact]
    public void CreateNewVersion_ShouldContainOriginalId()
    {
        var mockAuthor = new Mock<IUser>();
        mockAuthor.SetupGet(a => a.Id).Returns(1);

        var lection = new Lection(1, "Название", "Описание", "Содержание", mockAuthor.Object);

        ILection cloneLection = lection.CreateNewVersion(mockAuthor.Object);

        Assert.NotNull(cloneLection);
        Assert.Equal(lection.Id, ((Lection)cloneLection).BasedOnId);
    }
}
