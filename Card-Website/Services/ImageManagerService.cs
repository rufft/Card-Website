using Card_Website.Models;

namespace Card_Website.Services;

public class ImageManagerService
{
    private const string ImageRootFolderPath = "Posts";
    
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
    
    public async Task<List<ImageLink>> LoadImagesAsync(IEnumerable<IFormFile> files, string postId)
    {
        var filePaths = new List<ImageLink>();
        foreach (var file in files)
        {
            var filePath = await LoadImageAsync(file, postId);
            if (filePath != null) filePaths.Add(new(filePath));
        }
        return filePaths;
    }

    public void DeleteDirectoryAsync(string postId)
    {
        // delete directorty with images, get folder path from Posts/{postId}
        var directory = Path.Combine(ImageRootFolderPath, postId);
        Directory.Delete(directory, true);
    }
}