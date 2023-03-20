using Card_Website.Context;
using Card_Website.Models;
using Card_Website.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

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
    
    [Fact]
    public async Task AddTagAsyncTest()
    {
        // arrange
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        await using var database = new DatabaseContext(options);

        var tagService = new TagsService(database);
        // act
        var result = await tagService.AddTagAsync("parent2/parent1/test");
        // assert
        Assert.Equal("test", result.TagName);
    }
}