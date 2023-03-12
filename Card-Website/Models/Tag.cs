using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Card_Website.Models;

public class Tag
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("tag_id")]
    [Key]
    public string TagId { get; init; }
    
    [Column("parent_tag")]
    public Tag? ParentTag { get; set; }
    
    [Column("tag_name")]
    public string TagName { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new();
        var current = this;
        while (current != null)
        {
            sb.Insert(0, current.TagName);
            if (current.ParentTag != null)
                sb.Insert(0, "/");
            current = current.ParentTag;
        }
        return sb.ToString();
    }
}