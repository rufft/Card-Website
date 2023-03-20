using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Card_Website.Models;

public class ImageLink
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("image_link_id")]
    public string ImageLinkId { get; init; }
    
    [Column("image_link")]
    [Required]
    public string Link { get; set; }
    
    public SimplePost Post { get; set; }

    public ImageLink(string link)
    {
        Link = link;
    }
}