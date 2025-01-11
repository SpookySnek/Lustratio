using Lustratio.Server.Domain;

namespace Lustratio.Server.Data;

public class DbSeeder
{
    public void SeedData(DataContext context)
    {
        // Seed users
        context.Users.Add(new User
        {
            Id = 1,
            Username = "MrTestUser",
            Email = "MrTest@test.com",
            Password = "VerySecurePassword",
            FirstName = "Mister",
            LastName = "Test",
            City = "TestCity",
            Country = "TestCountry",
            ProfilePictureUri = "https://picsum.photos/200",
            Bio = "This is a test user",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            LastLogin = DateTime.Now,
            IsDeactivated = false,
        });
        
        // Seed galleries
        context.Galleries.Add(new Gallery
        {
            Id = 10,
            CreationDate = DateTime.Now,
            UpdateDate = DateTime.Now,
            Description = "This is a test gallery",
            Location = "TestLocation",
            User = context.Users.First(u => u.Id == 1)
        });
        
        // Seed photos
        context.Photos.Add(new Photo
        {
            Id = 1,
            PhotoUri = "https://picsum.photos/200",
            UploadDate = DateTime.Now,
            PhotoDate = DateTime.Now,
            Description = "This is a test photo",
            Location = "TestLocation",
            Gallery = context.Galleries.First(g => g.Id == 10),
            User = context.Users.First(u => u.Id == 1)
        });
        
        context.SaveChanges();
    }
}