using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Moq;

namespace Lab4.Tests.Shareds;

public class TestHelpers
{
    public Mock<IFileSystem> CreateMockFileSystem()
    {
        var mock = new Mock<IFileSystem>();

        return mock;
    }
}
