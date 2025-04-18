using FinanceTrackerAPI.DTO;
using FinanceTrackerAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> register([FromBody] UserDTO userDTO)
    {
        var success = await _userService.registerUserAsync(userDTO);
        return success ? Ok("User Registered") : BadRequest("User Already Exist");
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> login(UserDTO userDTO)
    {
        var token = _userService.loginAsync(userDTO);
        if(token == null)
            return Unauthorized("Invalid Credentials");
        return Ok(new {token});
    }

}