using System.Collections.Generic;
using System.Threading.Tasks;
using UserPostsAPI.Cache;
using UserPostsAPI.Entities;
using UserPostsAPI.Repositories;

public class PostService
{
    private readonly IPostRepository _postRepository;
    private readonly ICacheService _cacheService;

    public PostService(IPostRepository postRepository, ICacheService cacheService)
    {
        _postRepository = postRepository;
        _cacheService = cacheService;
    }

    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        var posts = _cacheService.GetPosts();
        if (posts == null || posts.Count == 0)
        {
            posts = (List<Post>)await _postRepository.GetAllPosts();
            _cacheService.SavePosts(posts);
        }
        return posts;
    }

    public async Task<IEnumerable<Comment>> GetAllComments()
    {
        var comments = _cacheService.GetComments();
        if (comments == null || comments.Count == 0)
        {
            comments = (List<Comment>)await _postRepository.GetAllPosts();
            _cacheService.SaveComments(comments);
        }
        return comments;
    }

    public async Task<IEnumerable<Comment>> GetCommentsByPostId(int postId)
    {
        var comments = _cacheService.GetComments();
        comments = comments.FindAll(c => c.PostId == postId);
        if (comments == null || comments.Count == 0)
        {
            comments = (List<Comment>)await _postRepository.GetCommentsByPostId(postId);
            _cacheService.SaveComments(comments);
        }
        return comments;
    }

    public async Task<bool> DeletePost(int postId)
    {
        var result = await _postRepository.DeletePost(postId);
     
        return result;
    }

    public async Task DeleteCommentByPostId(int postId)
    {
       
    }

    public async Task AddCommentToPost(int postId, Comment comment)
    {
     
    }
}
