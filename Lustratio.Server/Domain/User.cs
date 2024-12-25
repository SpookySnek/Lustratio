using System.ComponentModel.DataAnnotations;

namespace Lustratio.Server.Domain;

public class User
{
    public int Id { get; set; }

    [MaxLength(32)] public required string Username { get; set; }

    [MaxLength(64)] public required string Email { get; set; }

    [MaxLength(40)] public required string Password { get; set; }

    [MaxLength(32)] public string? FirstName { get; set; }

    [MaxLength(32)] public string? LastName { get; set; }

    [MaxLength(32)] public string? City { get; set; }

    [MaxLength(32)] public string? Country { get; set; }

    [MaxLength(256)]
    public string? ProfilePictureUri { get; set; }
    
    [MaxLength(2048)] public string? Bio { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime LastLogin { get; set; }

    public bool IsDeactivated { get; set; }

    public DateTime? DeactivatedAt { get; set; }
    
    public ICollection<Gallery> Galleries { get; set; } = new List<Gallery>();

    // public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}