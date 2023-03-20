using Card_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace Card_Website.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    { }

    public DbSet<SimplePost> SimplePosts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    
    public DbSet<ImageLink> ImageLinks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SimplePost>()
            .HasMany(post => post.ImageLinks)
            .WithOne(imageLink => imageLink.Post)
            .OnDelete(DeleteBehavior.Cascade);
    }
}