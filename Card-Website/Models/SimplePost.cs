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
    public List<ImageLink>? ImageLinks { get; set; }
    
    [Column("tags")]
    public List<Tag>? Tags { get; set; }

    public SimplePost(string postName, string postContent, List<Tag>? tags = null)
    {
        PostName = postName;
        PostContent = postContent;
        Tags = tags;
        CreationTime = DateTime.Now;
    }
    
    public SimplePost() {}
}