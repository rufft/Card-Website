using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Card_Website.Models;

public class SimplePost
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("post_id")]
    [Key]
    public string PostId { get; init; }
    
    [Column("post_name")]
    public string PostName { get; }

    [Column("creation_time")]
    public DateTime CreationTime { get; }
    
    [Column("post_content")]
    public string PostContent { get; set; }
    
    [Column("image_links")]
    public List<string>? ImageLinks { get; set; }
    
    [Column("tags")]
    public List<Tag> Tags { get; set; }

    public SimplePost(string postName, string postContent, List<string>? imageLinks, List<Tag> tags)
    {
        PostName = postName;
        PostContent = postContent;
        ImageLinks = imageLinks;
        Tags = tags;
        CreationTime = DateTime.Now;
    }
    
    private SimplePost() {}
}