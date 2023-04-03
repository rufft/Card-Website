using Card_Website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Card_Website.Context;

public class DatabaseContext : IdentityDbContext<IdentityUser>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    { }

    public DbSet<SimplePost> SimplePosts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    
    public DbSet<ImageLink> ImageLinks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SimplePost>()
            .HasMany(post => post.ImageLinks)
            .WithOne(imageLink => imageLink.Post)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SimplePost>().HasKey(e => e.PostId);
        modelBuilder.Entity<Tag>().HasKey(e => e.TagId);
        modelBuilder.Entity<ImageLink>().HasKey(e => e.ImageLinkId);
    }
}