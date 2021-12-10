using BlazingBlog.Shared;

namespace BlazingBlog.Client.Services;

public interface IBlogService
{
    Task<List<BlogPost>> GetAllBlogPosts();
    Task<BlogPost> GetBlogPostByUrl(string url);
    Task<BlogPost> CreateBlogPost(BlogPost blogPost);
}
