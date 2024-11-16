using Itmo.ObjectOrientedProgramming.Lab2.Abstaction;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Moq;
using Xunit;

namespace Lab2.Tests.Models;

public class LaboratoryWorkTest
{
    [Fact]
    public void NotAuthor_Update_LaboratoryWork_IsNotCreative()
    {
        var mockAuthor = new Mock<IUser>();
        mockAuthor.SetupGet(a => a.Id).Returns(1);

        var otherAuthor = new Mock<IUser>();
        otherAuthor.SetupGet(a => a.Id).Returns(2);

        var criteria = new EvaluationCriteria(1, "Критерии", 100);
        var labWork = new LaboratoryWork(1, "Lab-1", "Описание", criteria, 50, mockAuthor.Object);

        Assert.Throws<UnauthorizedAccessException>(() => labWork.UpdateLaboratoryWork("Новое название", "Новое описание", otherAuthor.Object));
    }

    [Fact]
    public void CreateNewVersion_ShouldContainOriginalId()
    {
        var mockAuthor = new Mock<IUser>();
        var criteria = new EvaluationCriteria(1, "Критерии", 100);
        var labWork = new LaboratoryWork(1, "Lab-1", "Описание", criteria, 50, mockAuthor.Object);

        ILaboratoryWork cloneLabWork = labWork.CreateNewVersion(mockAuthor.Object);

        Assert.Equal(labWork.Id, cloneLabWork.Id);
    }
}
