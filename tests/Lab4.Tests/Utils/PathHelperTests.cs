using Itmo.ObjectOrientedProgramming.Lab4.Utils;
using Xunit;

namespace Lab4.Tests.Utils;

public class PathHelperTests
{
    [Theory]
    [InlineData("file.txt", true)]
    [InlineData("C:\\folder\\file.txt", false)]
    public void IsRelativePath_ShouldReturnCorrectResult(string path, bool expected)
    {
        var pathHelper = new PathHelper();
        bool result = pathHelper.IsRelativePath(path);

        Assert.Equal(expected, result);
    }
}
