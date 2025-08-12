using Microsoft.EntityFrameworkCore;
using Q1_CodeFirst_NET9.Models;

namespace Q1_CodeFirst_NET9.Data;

public class BloggingContext : DbContext
{
    public BloggingContext(DbContextOptions<BloggingContext> options) : base(options) { }

    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Post> Posts => Set<Post>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(e =>
        {
            e.HasKey(x => x.BlogId);
            e.Property(x => x.Name).HasMaxLength(255).IsRequired();
        });

        modelBuilder.Entity<Post>(e =>
        {
            e.HasKey(x => x.PostId);
            e.Property(x => x.Title);
            e.Property(x => x.Content);
            e.HasOne(x => x.Blog)
              .WithMany(b => b.Posts)
              .HasForeignKey(x => x.BlogId)
              .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
