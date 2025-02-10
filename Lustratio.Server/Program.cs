using Lustratio.Server.Data;
using Lustratio.Server.RepositoryManager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbPath = Path.Join(path, "database.db");

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite($"Data Source={dbPath}");
});


// Add services to the container.
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline & Seed the database with data
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    using var scope = app.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    new DbSeeder().SeedData(dataContext);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();