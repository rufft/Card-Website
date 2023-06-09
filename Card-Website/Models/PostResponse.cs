﻿using System.ComponentModel.DataAnnotations;

namespace Card_Website.Models;

public class PostResponse : IPostResponse
{
    public List<IFormFile>? Images { get; set; }

    [Required]
    public string PostName { get; init; }
    
    [Required]
    public string PostContent { get; set; }
    
    public List<string>? TagNames { get; set; }
    public static implicit operator SimplePost(PostResponse response) => response.ToPost();

    private SimplePost ToPost() => new SimplePost(PostName, PostContent);
}