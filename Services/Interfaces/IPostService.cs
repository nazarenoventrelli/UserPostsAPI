using System.Collections.Generic;
using System.Threading.Tasks;
using UserPostsAPI.Entities;

public interface IPostService
{
    Task<IEnumerable<Post>> GetAllPosts();
    Task<IEnumerable<Comment>> GetAllComments();
    Task<IEnumerable<Comment>> GetCommentsByPostId(int postId);
    Task<bool> DeletePost(int postId);
    Task DeleteCommentByPostId(int postId);
    Task AddCommentToPost(int postId, Comment comment);
}
