using Card_Website.Context;
using Card_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace Card_Website.Services;

public class ImageManagerService
{
    private DatabaseContext _database;
    private const string ImageRootFolderPath = "Posts";

    public ImageManagerService(DatabaseContext database)
    {
        _database = database;
    }

    public async Task<string?> LoadImageAsync(IFormFile file, string postId)
    {
        var extension = Path.GetExtension(file.FileName);
        
        if (extension != ".jpg" && extension != ".png" && extension != ".jpeg") return null;
        
        var directory = Path.Combine(ImageRootFolderPath, postId);
        Directory.CreateDirectory(directory);
        
        var filePath = Path.Combine(directory, file.FileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        try
        {
            await file.CopyToAsync(stream);
        }
        catch (Exception e)
        {
            return null;
        }
        return filePath;
    } 
    
    public async Task<List<ImageLink>> LoadImagesAsync(IEnumerable<IFormFile> files, SimplePost post)
    {
        var filePaths = new List<ImageLink>();
        foreach (var file in files)
        {
            var filePath = await LoadImageAsync(file, post.PostId);
            if (filePath != null) filePaths.Add(new(filePath, post));
        }
        return filePaths;
    }

    public void DeletePostDirectoryAsync(string postId)
    {
        var directory = Path.Combine(ImageRootFolderPath, postId);
        Directory.Delete(directory, true);
    }
}