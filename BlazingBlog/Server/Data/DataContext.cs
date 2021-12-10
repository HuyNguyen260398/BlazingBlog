using BlazingBlog.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazingBlog.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<BlogPost> BlogPosts { get; set; }
}
