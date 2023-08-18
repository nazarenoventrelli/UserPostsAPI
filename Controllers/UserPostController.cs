using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserPostsAPI.Entities;

namespace UserPostsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPostController : ControllerBase
    {
        private readonly PostService _postService;

        public UserPostController(PostService postService)
        {
            _postService = postService;
        }

        // Get all posts with Author and # of comments
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postService.GetAllPosts();
            return Ok(posts);
        }

        //  View post and comments
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostAndComments(int postId)
        {
            var comments = await _postService.GetCommentsByPostId(postId);
            if (comments == null)
                return NotFound();

            return Ok(comments);
        }

        //  Add a comment
        [HttpPost("{postId}/comments")]
        public async Task<IActionResult> AddComment(int postId, Comment comment)
        {
            await _postService.AddCommentToPost(postId, comment);
            return CreatedAtAction(nameof(GetPostAndComments), new { postId = postId }, comment);
        }

        // . Delete a comment
        [HttpDelete("comments/{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            await _postService.DeleteCommentByPostId(commentId);
            return NoContent();
        }

        //  Delete a post
        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            var result = await _postService.DeletePost(postId);
            if (!result)
                return NotFound();

            return NoContent();
        }

   
        [HttpPost("{postId}/favorite")]
        public IActionResult MarkPostAsFavorite(int postId)
        {
            return NoContent();
        }

  
        [HttpPost("{postId}/unfavorite")]
        public IActionResult UnmarkPostAsFavorite(int postId)
        {
            return NoContent();
        }

        [HttpPost("refresh")]
        public IActionResult RefreshData()
        {



            return NoContent();
        }
    }
}
