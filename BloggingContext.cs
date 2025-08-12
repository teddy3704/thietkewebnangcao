using Microsoft.EntityFrameworkCore;

namespace Q3_ModelFirst_NET9;

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
              .HasForeignKey(x => x.BlogId);
        });
    }
}

public class Blog
{
    public int BlogId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Post> Posts { get; set; } = new();
}

public class Post
{
    public int PostId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int BlogId { get; set; }
    public Blog? Blog { get; set; }
}
