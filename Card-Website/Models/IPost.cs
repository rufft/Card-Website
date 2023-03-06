using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Card_Website.Models;

public interface IPost
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; init; }
    
    public string PostName { get; }

    public DateTime CreationTime { get; }
    
    public string PostContent { get; set; }
    
    public IEnumerable<string> ImageLinks { get; set; }

    public IEnumerable<string> Tags { get; set; }
    
}























