using Card_Website.Context;
using Card_Website.Models;
using Card_Website.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Card_Website.Controllers;

[ApiController]
[Route("api/tags")]
public class TagController : ControllerBase
{
    private TagsService _tagsService;
    
    public TagController(TagsService tagsService)
    {
        _tagsService = tagsService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tag>>> GetTags() => await _tagsService.GetTagsAsync();
    
    [HttpGet("{tagId}")]
    public async Task<ActionResult<Tag?>> GetTag(string tagId) => _tagsService.GetTag(tagId);
    
    [HttpPost]
    [Authorize(Roles = "admin")]
    [ActionName("add")]
    public async Task AddTag([FromForm] string tagName) => await _tagsService.AddTagAsync(tagName);
    
    [HttpDelete]
    [Authorize(Roles = "admin")]
    [ActionName("delete")]
    public async Task DeleteTag(string tagId) => await _tagsService.DeleteTagAsync(tagId);
    
    

}