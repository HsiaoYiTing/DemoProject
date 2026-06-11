using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Server.Models;

namespace WebApplication_Server.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly UserService _userService;

    public UsersController(ILogger<UsersController> logger, UserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet("test")]
    public async Task<IActionResult> TestAsync()
    {
        return Ok(new
        {
            message = "API is working"
        });
    }

    [HttpGet("{id}", Name = "GetUserById")]
    public async Task<ResponseBase<User>> GetByIdAsync(int id)
    {
        var result = await _userService.GetUserByIdAsync(id);

        return result;
    }

    [HttpGet("all")]
    public async Task<ResponseBase<List<User>>> GetAllAsync()
    {
        var response = await _userService.GetAllUsersAsync();

        return response;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddAsync([FromBody] UserRequest request)
    {
        await _userService.AddUserAsync(request);

        return Ok(new { message = "User added successfully" });
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UserRequest request)
    {
        await _userService.UpdateUserAsync(request);

        return Ok(new { message = "User updated successfully" });
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] int id)
    {
        await _userService.DeleteUserAsync(id);

        return Ok(new { message = "User deleted successfully" });
    }
}