using Elastic.Clients.Elasticsearch;
using ElasticsearchBlog.Models;

namespace ElasticsearchBlog.Repositories;

public class BlogRepository
{
    private readonly ElasticsearchClient elasticsearchClient;

    private const string IndexName = "blog";

    public BlogRepository(ElasticsearchClient elasticsearchClient)
    {
        this.elasticsearchClient = elasticsearchClient;
    }

    public async Task<Blog?> SaveAsync(Blog newBlog)
    {
        newBlog.Created = DateTime.Now;

        var response = await elasticsearchClient.IndexAsync(newBlog, x => x.Index(IndexName));

        if (!response.IsValidResponse) return null;

        newBlog.Id = response.Id;

        return newBlog;

    }
}
