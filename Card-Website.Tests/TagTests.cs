using Card_Website.Models;

namespace Card_Website.Tests;

public class TagTests
{
    [Fact]
    public void ToStingReturnValidDataTest()
    {
        // arrange
        var tag = new Tag();
        tag.TagName = "test";
        tag.ParentTag = new Tag();
        tag.ParentTag.TagName = "parent1";
        tag.ParentTag.ParentTag = new Tag();
        tag.ParentTag.ParentTag.TagName = "parent2";
        // act
        string result = tag.ToString();
        // assert
        Assert.Equal("parent2/parent1/test", result);
    }
}