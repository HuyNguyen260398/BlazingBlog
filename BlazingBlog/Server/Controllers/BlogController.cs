using BlazingBlog.Server.Data;
using BlazingBlog.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazingBlog.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly DataContext _db;

    public static List<BlogPost> posts { get; set; } = new()
    {
        new BlogPost { Url = "Url-1", Title = "Blog 1", Description = "Desc 1", Content = "There were two things that were important to Tracey. The first was her dog. Anyone that had ever met Tracey knew how much she loved her dog. Most would say that she treated it as her child. The dog went everywhere with her and it had been her best friend for the past five years. The second thing that was important to Tracey, however, would be a lot more surprising to most people." },
        new BlogPost { Url = "Url-2", Title = "Blog 2", Description = "Desc 2", Content = "The red glint of paint sparkled under the sun. He had dreamed of owning this car since he was ten, and that dream had become a reality less than a year ago. It was his baby and he spent hours caring for it, pampering it, and fondling over it. She knew this all too well, and that's exactly why she had taken a sludge hammer to it." }
    };

    public BlogController(DataContext db)
    {
        _db = db;
    }

    [HttpGet]
    public ActionResult<List<BlogPost>> GetAllBlogPosts()
    {
        //return Ok(posts);
        return Ok(_db.BlogPosts.OrderByDescending(p => p.DateCreated));
    }

    [HttpGet("{url}")]
    public ActionResult<BlogPost> GetBlogPostByUrl(string url)
    {
        //var post = posts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
        var post = _db.BlogPosts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }


    [HttpPost]
    public async Task<ActionResult<BlogPost>> CreateBlogPost(BlogPost newPost)
    {
        _db.Add(newPost);
        await _db.SaveChangesAsync();
        return newPost;
    }
}
