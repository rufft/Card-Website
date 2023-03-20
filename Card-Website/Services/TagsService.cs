using Card_Website.Context;
using Card_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace Card_Website.Services;

public class TagsService
{
    private readonly DatabaseContext _database;
    
    public TagsService(DatabaseContext database)
    {
        _database = database;
    }
    
    public async Task<List<Tag>> GetTagsAsync()
    {
        return await _database.Tags.ToListAsync();
    }

    public async Task<Tag?> GetTagAsync(string tagId)
    {
        return await _database.Tags.SingleOrDefaultAsync(tag => tag.TagId == tagId);
    }
    
    public async Task<Tag> AddTagAsync(string tagName)
    {
        var tags = tagName.ToLower().Split('/');
        Tag? parentTag = null;
        foreach (var tag in tags)
        {
            var tagEntity = await GetTagFromStrAsync(tag);
            if (tagEntity == null)
            {
                var tagEntityEntry =  await _database.Tags.AddAsync(new Tag() { TagName = tag, ParentTag = parentTag});
                parentTag = tagEntityEntry.Entity;
            }
            else
            {
                parentTag = tagEntity;
            }

        }
        await _database.SaveChangesAsync();
        return parentTag!;
    }
    
    public async Task<List<Tag>> AddTagsAsync(List<string> tagNames)
    {
        var tags = new List<Tag>();
        foreach (var tagName in tagNames)
        {
            tags.Add(await AddTagAsync(tagName));
        }
        return tags;
    }

    private async Task<Tag?> GetTagFromStrAsync(string tagStr)
    {
        var tagName = tagStr.ToLower().Split('/').Last();
        List<Tag>? tags = _database.Tags.ToList();
        return await _database.Tags.SingleOrDefaultAsync(tag => tag.TagName == tagName);
    }
    
    public async Task UpdateTagAsync(Tag tag)
    {
        _database.Tags.Update(tag);
        await _database.SaveChangesAsync();
    }
    
    public async Task DeleteTagAsync(string tagId)
    {
        var tag = await GetTagAsync(tagId);
        
        if (tag == null) throw new NullReferenceException("DeleteTag ERROR: Tag not found");
        
        var children = await _database.Tags.Where(t => t.ParentTag == tag).ToListAsync();
        foreach (var child in children)
        {
            await DeleteTagAsync(child.TagId);
        }
        _database.Tags.Remove(tag);
        await _database.SaveChangesAsync();
    }
}