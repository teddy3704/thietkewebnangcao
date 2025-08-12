using Microsoft.EntityFrameworkCore;

namespace Q2_Q4_DbFirst_Scaffold_NET9;

public partial class BloggingDbContext : DbContext
{
    public BloggingDbContext() { }
    public BloggingDbContext(DbContextOptions<BloggingDbContext> options) : base(options) { }


    public virtual DbSet<Blog> Blogs { get; set; } = null!;
    public virtual DbSet<Post> Posts { get; set; } = null!;
    public virtual DbSet<Student> Students { get; set; } = null!;

    // ✅ Dự phòng khi tạo bằng ctor rỗng
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=BloggingDb9_Scaffold;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(e =>
        {
            e.ToTable("Blogs");
            e.HasKey(x => x.BlogId);
            e.Property(x => x.Name).HasMaxLength(255).IsRequired();
        });

        modelBuilder.Entity<Post>(e =>
        {
            e.ToTable("Posts");
            e.HasKey(x => x.PostId);
            e.Property(x => x.Title);
            e.Property(x => x.Content);
            e.HasOne(x => x.Blog).WithMany(b => b.Posts)
              .HasForeignKey(x => x.BlogId)
              .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Student>(e =>
        {
            e.ToTable("Student");
            e.HasKey(x => x.StudentId);
            e.Property(x => x.StudentName).HasMaxLength(50).IsRequired();
            e.Property(x => x.StudentAddress).HasMaxLength(50);
        });
    }
}

public partial class Blog
{
    public int BlogId { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
public partial class Post
{
    public int PostId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int BlogId { get; set; }
    public virtual Blog Blog { get; set; } = null!;
}
public partial class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = null!;
    public string? StudentAddress { get; set; }
}
