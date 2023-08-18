using System.Collections.Generic;
using UserPostsAPI.Entities;

namespace UserPostsAPI.Cache
{
    public interface ICacheService
    {
        void SavePosts(List<Post> posts);
        List<Post> GetPosts();
        void SaveComments(List<Comment> comments);
        List<Comment> GetComments();
        void RefreshCache(List<Post> freshPosts, List<Comment> freshComments);
    }
}