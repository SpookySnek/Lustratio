using System.ComponentModel.DataAnnotations;

namespace Lustratio.Server.Domain;

public class Photo
{
    public int Id { get; set; }
    
    [MaxLength(256)]
    public required string PhotoUri { get; set; }

    public DateTime UploadDate { get; set; }
    
    public DateTime? PhotoDate { get; set; }

    [MaxLength(2048)]
    public string? Description { get; set; }
    
    [MaxLength(256)]
    public string? Location { get; set; }
    
    public required Gallery Gallery { get; set; }
    
    public required User User { get; set; }
}