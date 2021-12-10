using BlazingBlog.Shared;
using System.Net;
using System.Net.Http.Json;

namespace BlazingBlog.Client.Services;

public class BlogService : IBlogService
{
    private readonly HttpClient _http;

    public BlogService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<BlogPost>> GetAllBlogPosts()
    {
        return await _http.GetFromJsonAsync<List<BlogPost>>("api/blog");
    }

    public async Task<BlogPost> GetBlogPostByUrl(string url)
    {
        var result = await _http.GetAsync($"api/blog/{url}");
        if (result.StatusCode != HttpStatusCode.OK)
        {
            var message = await result.Content.ReadAsStringAsync();
            Console.WriteLine(message);
            return new BlogPost { Title = message };
        }
        else
        {
            return await result.Content.ReadFromJsonAsync<BlogPost>();
        }
    }

    public async Task<BlogPost> CreateBlogPost(BlogPost blogPost)
    {
        var result = await _http.PostAsJsonAsync("api/blog", blogPost);
        return await result.Content.ReadFromJsonAsync<BlogPost>();
    }
}
