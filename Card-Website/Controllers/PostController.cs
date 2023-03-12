using Card_Website.Context;
using Card_Website.Models;
using Card_Website.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Card_Website.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private PostService _postService;
    
    public PostController(PostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SimplePost>>> GetPosts() => await _postService.GetPostsAsync();
    
    [HttpGet("{postId}")]
    public async Task<ActionResult<SimplePost?>> GetPost(string postId) => await _postService.GetPostAsync(postId);
    
    [HttpPost]
    //[Authorize(Roles = "admin")]
    [ActionName("add")]
    public async Task<ActionResult> AddPost(PostResponse response)
    {
        try
        {
            await _postService.AddPostAsync(response.Post, response.Images);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    [HttpPut]
    //[Authorize(Roles = "admin")]
    [ActionName("update")]
    public async Task<ActionResult> UpdatePost(SimplePost post)
    {
        try
        {
            await _postService.UpdatePostAsync(post);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    [HttpDelete("{postId}")]
   //[Authorize(Roles = "admin")]
    [ActionName("delete")]
    public async Task DeletePost(string postId) => await _postService.DeletePostAsync(postId);
}