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
        User user = new User
        {
            Account = request.Account,
            Name = request.Name,
            Age = request.Age,
            Salary = request.Salary,
            Enabled = request.Enabled,
            Birthday = request.Birthday,
        };

        _logger.LogInformation("Adding user: {@User}", JsonSerializer.Serialize(user));
    
        await _userService.AddUserAsync(user);

        return Ok(new { message = "User added successfully" });
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UserRequest request)
    {
        User user = new User
        {
            Id = request.Id,
            Account = request.Account,
            Name = request.Name,
            Age = request.Age,
            Salary = request.Salary,
            Enabled = request.Enabled,
            Birthday = request.Birthday,
        };
    
        await _userService.UpdateUserAsync(user);

        return Ok(new { message = "User updated successfully" });
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] int id)
    {
        await _userService.DeleteUserAsync(id);

        return Ok(new { message = "User deleted successfully" });
    }
}