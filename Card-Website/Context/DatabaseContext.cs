using Card_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace Card_Website.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    { }

    public DbSet<SimplePost> SimplePosts { get; set; }
}