namespace Card_Website.Models;

public class SimplePost : IPost
{
    public string Id { get; init; }
    public string PostName { get; }
    public DateTime CreationTime { get; }
    public string PostContent { get; set; }
    public IEnumerable<string> ImageLinks { get; set; }
    public IEnumerable<string> Tags { get; set; }
}