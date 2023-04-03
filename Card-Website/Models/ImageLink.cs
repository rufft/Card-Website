using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Card_Website.Models;

public class ImageLink
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("image_link_id")]
    [Key]
    public string ImageLinkId { get; init; }
    
    [Column("image_link")]
    [Required]
    public string Link { get; set; }
    
    public SimplePost Post { get; set; }

    public ImageLink(string link, SimplePost post)
    {
        Link = link;
        Post = post;
    }
    
    private ImageLink()
    {
        
    }
}