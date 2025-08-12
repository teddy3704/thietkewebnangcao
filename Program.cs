using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Q3_ModelFirst_NET9;

var cfg = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)                 // để lúc run/debug đọc được appsettings.json
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var opts = new DbContextOptionsBuilder<BloggingContext>()
    .UseSqlServer(cfg.GetConnectionString("BloggingDb"))
    .Options;

using var db = new BloggingContext(opts);

// Tạo DB từ model qua migrations
await db.Database.MigrateAsync();

// Seed nhẹ để kiểm tra
if (!await db.Blogs.AnyAsync())
{
    db.AddRange(
        new Blog { Name = "Văn hóa" },
        new Blog { Name = "Xã hội" }
    );
    await db.SaveChangesAsync();
}

Console.WriteLine("Q3 Model First — DB đã tạo & seed xong:");
foreach (var b in await db.Blogs.Include(b => b.Posts).ToListAsync())
{
    Console.WriteLine($"Blog {b.BlogId}: {b.Name} (Posts: {b.Posts.Count})");
}


