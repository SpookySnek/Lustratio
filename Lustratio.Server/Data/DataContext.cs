﻿using Lustratio.Server.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lustratio.Server.Data;

public class DataContext : DbContext
{
    public DbSet<Gallery> Galleries { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<User> Users { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
}