namespace Card_Website.Models;

public interface IPostResponse
{
    public string PostName { get; }
    public string PostContent { get; set; }
    public List<string>? TagNames { get; set; }
}