namespace Q1_CodeFirst_NET9.Models;

public class Blog
{
    public int BlogId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Post> Posts { get; set; } = new();
}
