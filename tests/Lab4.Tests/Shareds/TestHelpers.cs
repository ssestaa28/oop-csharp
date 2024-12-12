using Itmo.ObjectOrientedProgramming.Lab4.Iёnterfaces;
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
