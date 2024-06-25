using ElasticsearchBlog.Models;
using ElasticsearchBlog.Repositories;
using ElasticsearchBlog.ViewModels;

namespace ElasticsearchBlog.Services;

public class BlogService
{
    private readonly BlogRepository blogRepository;

    public BlogService(BlogRepository blogRepository)
    {
        this.blogRepository = blogRepository;
    }

    public async Task<bool> SaveAsync(BlogCreateViewModel model)
    {
        
        
        Blog newBlog = new Blog();
        newBlog.Title = model.Title;
        newBlog.UserId = Guid.NewGuid();
        newBlog.Content = model.Content;
        newBlog.Tags = model.Tags.ToArray();

        var isCreated  = await blogRepository.SaveAsync(newBlog);

        return isCreated != null;



    }
}
