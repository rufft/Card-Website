using Card_Website.Context;
using Card_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace Card_Website.Services;

public class PostService
{
    private readonly DatabaseContext _database;

    private readonly ImageManagerService _imageManager;
    private TagsService _tagsService;

    public string Name { get; set; }

    public PostService(DatabaseContext database, ImageManagerService imageManager, TagsService tagsService)
    {
        _database = database;
        _imageManager = imageManager;
        _tagsService = tagsService;
    }
    
    public async Task<List<SimplePost>> GetPostsAsync()
    {
        return await _database.SimplePosts.Include(post => post.Tags).ToListAsync();
    }
    
    public async Task<SimplePost?> GetPostAsync(string postId)
    {
        return await _database.SimplePosts.Include(post => post.Tags).SingleOrDefaultAsync(post => post.PostId == postId);
    }
    
    public async Task AddPostAsync(PostResponse postResponse)
    {
        SimplePost post = postResponse;
        
        if (postResponse.TagNames != null) post.Tags = await _tagsService.AddTagsAsync(postResponse.TagNames);
        var postEntity = await _database.SimplePosts.AddAsync(post);
        
        if (postResponse.Images != null)
        {
            var paths = await _imageManager.LoadImagesAsync(postResponse.Images, postEntity.Entity);
            postEntity.Entity.ImageLinks = paths;
        }
            
        await _database.SaveChangesAsync();
    }
    
    public async Task UpdatePostAsync(SimplePost post)
    {
        _database.SimplePosts.Update(post);
        await _database.SaveChangesAsync();
    }
    

    public async Task DeletePostAsync(string postId)
    {
        var post = await GetPostAsync(postId);
        
        if (post == null) throw new NullReferenceException("DeletePost ERROR: Post not found");
        
        _imageManager.DeletePostDirectoryAsync(postId);
        
        _database.SimplePosts.Remove(post);
        await _database.SaveChangesAsync();
    }
}