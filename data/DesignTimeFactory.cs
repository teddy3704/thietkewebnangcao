using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Q3_ModelFirst_NET9;

public class DesignTimeFactory : IDesignTimeDbContextFactory<BloggingContext>
{
    public BloggingContext CreateDbContext(string[] args)
    {
        var cfg = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())   // rất quan trọng khi chạy dotnet-ef
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var opts = new DbContextOptionsBuilder<BloggingContext>()
            .UseSqlServer(cfg.GetConnectionString("BloggingDb"))
            .Options;

        return new BloggingContext(opts);
    }
}
