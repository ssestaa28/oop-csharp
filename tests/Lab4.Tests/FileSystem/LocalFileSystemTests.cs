using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Xunit;

namespace Lab4.Tests.FileSystem;

public class LocalFileSystemTests
{
    [Fact]
    public void Connect_ShouldSetCurrentPath_WhenPathIsValid()
    {
        var fileSystem = new LocalFileSystem();
        string validPath = Directory.GetCurrentDirectory();

        fileSystem.Connect(validPath);

        Assert.NotNull(validPath);
    }

    [Fact]
    public void Disconnect_ShouldClearCurrentPath()
    {
        var fileSystem = new LocalFileSystem();
        fileSystem.Connect(Directory.GetCurrentDirectory());

        fileSystem.Disconnect();

        Assert.Throws<InvalidOperationException>(() => fileSystem.GetDirectoryTree("."));
    }
}