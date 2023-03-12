namespace Card_Website.Models;

public class PostResponse
{
    public SimplePost Post { get; init; }
    public IEnumerable<IFormFile>? Images { get; init; }

    public PostResponse(SimplePost post, IEnumerable<IFormFile>? images)
    {
        Post = post;
        Images = images;
    }
}