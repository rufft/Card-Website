using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Card_Website.Controllers;

[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AdminController(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    
    
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login([FromHeader] string password)
    {
        var result = await _signInManager.PasswordSignInAsync("admin", password, true, false);
        
        if (result.Succeeded)
            return Ok();
        
        return Unauthorized();
    }
    
    [HttpPost]
    [Authorize(Roles = "admin")]
    [Route("logout")]
    public async Task<ActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }
}