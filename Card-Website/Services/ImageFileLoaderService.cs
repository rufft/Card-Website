namespace Card_Website.Services;

public class ImageFileLoaderService
{
    private const string ImageRootFolderPath = "/Posts";
    
    public async Task<string?> LoadImageAsync(IFormFile file, string postId)
    {
        var extension = Path.GetExtension(file.FileName);
        
        if (extension != ".jpg" && extension != ".png" && extension != ".jpeg") return null;
        
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", ImageRootFolderPath, postId);
        Directory.CreateDirectory(filePath);
        filePath = Path.Combine(filePath, file.FileName);

        
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
    
    public async Task<List<string>> LoadImagesAsync(IEnumerable<IFormFile> files, string postId)
    {
        var filePaths = new List<string>();
        foreach (var file in files)
        {
            var filePath = await LoadImageAsync(file, postId);
            if (filePath != null) filePaths.Add(filePath);
        }
        return filePaths;
    }
}