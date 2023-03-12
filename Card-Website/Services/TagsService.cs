using Card_Website.Context;
using Card_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace Card_Website.Services;

public class TagsService
{
    private DatabaseContext _database;
    
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
    
    public async Task AddTagAsync(Tag tag)
    {
        await _database.Tags.AddAsync(tag);
        await _database.SaveChangesAsync();
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
        
        _database.Tags.Remove(tag);
        await _database.SaveChangesAsync();
    }
}