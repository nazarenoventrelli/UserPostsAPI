using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Xml.Linq;
using UserPostsAPI.Entities;

namespace UserPostsAPI.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPosts();
        Task<IEnumerable<Comment>> GetCommentsByPostId(int postId);
        Task<bool> DeletePost(int postId);
        Task DeleteCommentByPostId(int postId);
        Task AddCommentToPost(int postId, Comment comment);
        Task<IEnumerable<Comment>> GetAllComments();
    }
}
