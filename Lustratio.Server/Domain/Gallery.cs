using System.ComponentModel.DataAnnotations;

namespace Lustratio.Server.Domain;

public class Gallery
{
    public int Id { get; set; }
    
    public DateTime CreationDate { get; set; }
    
    public DateTime? UpdateDate { get; set; }

    [MaxLength(2048)]
    public string? Description { get; set; }
    
    [MaxLength(256)]
    public string? Location { get; set; }
    
    public required User User { get; set; }
    
    public ICollection<Photo>? Photos { get; set; } = new List<Photo>();
}