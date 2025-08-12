using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Q1_CodeFirst_NET9.Data;

public class DesignTimeFactory : IDesignTimeDbContextFactory<BloggingContext>
{
    public BloggingContext CreateDbContext(string[] args)
    {
        // dotnet-ef chạy ở thư mục project => dùng CurrentDirectory
        var cfg = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

        var opts = new DbContextOptionsBuilder<BloggingContext>()
            .UseSqlServer(cfg.GetConnectionString("BloggingDb"))
            .Options;

        return new BloggingContext(opts);
    }
}
