using BenchmarkDotNet.Attributes;
using Card_Website.Context;
using Card_Website.Models;
using Card_Website.Services;
using Microsoft.EntityFrameworkCore;

namespace Card_Website.Benchmark;

[MemoryDiagnoser]
public class TagBenchmarks
{
    // create benchmark for tag service GetTagAsync and GetTag using BenchmarkDotNet
    [Benchmark]
    public async Task<Tag?> GetTagAsyncBenchmark()
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        await using var database = new DatabaseContext(options);
        var tagService = new TagsService(database);
        await tagService.AddTagAsync("parent2/parent1/test");
        return await tagService.GetTagAsync("test");
    }

    [Benchmark]
    public Tag? GetTagBenchmark()
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        using var database = new DatabaseContext(options);
        var tagService = new TagsService(database);
        tagService.AddTagAsync("parent2/parent1/test").Wait();
        return tagService.GetTag("test");
    }
    
}