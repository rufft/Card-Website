using Card_Website.Context;
using Card_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace Card_Website.Services;

public class PostService
{
    private DatabaseContext _database;

    private ImageFileLoaderService _imageFileLoader;
    
    public PostService(DatabaseContext database, ImageFileLoaderService imageFileLoader)
    {
        _database = database;
        _imageFileLoader = imageFileLoader;
    }
    
    public async Task<List<SimplePost>> GetPostsAsync()
    {
        return await _database.SimplePosts.Include(post => post.Tags).ToListAsync();
    }
    
    public async Task<SimplePost?> GetPostAsync(string postId)
    {
        return await _database.SimplePosts.Include(post => post.Tags).SingleOrDefaultAsync(post => post.PostId == postId);
    }
    
    public async Task AddPostAsync(SimplePost post, IEnumerable<IFormFile>? images)
    {
        var postEntity = await _database.SimplePosts.AddAsync(post);
        
        if (images != null)
        {
            var paths = await _imageFileLoader.LoadImagesAsync(images, postEntity.Entity.PostId);
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
        
        _database.SimplePosts.Remove(post);
        await _database.SaveChangesAsync();
    }
}