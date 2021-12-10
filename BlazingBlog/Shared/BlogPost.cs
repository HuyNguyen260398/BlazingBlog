using System.ComponentModel.DataAnnotations;

namespace BlazingBlog.Shared;

public class BlogPost
{
    public int Id { get; set; }
    [Required, StringLength(20)]
    public string Url { get; set; }
    [Required]
    public string Image { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }= string.Empty;
    public string Description { get; set; }
    public string Author { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public bool IsPublished { get; set; } = true;
    public bool IsDelete { get; set; } = false;
}
