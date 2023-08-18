using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UserPostsAPI.Cache;
using UserPostsAPI.Entities;

public class CacheService : ICacheService
{
    private static readonly string CacheDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Cache");
    private const string PostsCacheFile = "posts.json";
    private const string CommentsCacheFile = "comments.json";

    static CacheService()
    {
        // Ensure the Cache directory exists
        if (!Directory.Exists(CacheDirectory))
        {
            Directory.CreateDirectory(CacheDirectory);
        }
    }

    public void RefreshCache(List<Post> freshPosts, List<Comment> freshComments)
    {
        // Update the cache with the fresh data
        SavePosts(freshPosts);
        SaveComments(freshComments);
    }

    public void SavePosts(List<Post> posts)
    {
        var json = JsonConvert.SerializeObject(posts);
        File.WriteAllText(Path.Combine(CacheDirectory, PostsCacheFile), json);
    }

    public List<Post> GetPosts()
    {
        var fullPath = Path.Combine(CacheDirectory, PostsCacheFile);
        if (File.Exists(fullPath))
        {
            var json = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<List<Post>>(json);
        }
        return new List<Post>();
    }

    public void SaveComments(List<Comment> comments)
    {
        var json = JsonConvert.SerializeObject(comments);
        File.WriteAllText(Path.Combine(CacheDirectory, CommentsCacheFile), json);
    }

    public List<Comment> GetComments()
    {
        var fullPath = Path.Combine(CacheDirectory, CommentsCacheFile);
        if (File.Exists(fullPath))
        {
            var json = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<List<Comment>>(json);
        }
        return new List<Comment>();
    }

}
