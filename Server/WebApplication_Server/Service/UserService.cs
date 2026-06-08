using Microsoft.Extensions.FileProviders;
using WebApplication_Server.Models;


public class UserService
{
    private readonly IUserRepository _userRepository;


    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResponseBase<User>> GetUserByIdAsync(int id)
    {
        User user = await _userRepository.GetByIdAsync(id);

        if (user == null)
        {
            return ResponseFactory.CreateErrorResponse<User>(null, $"User with ID {id} not found.");
        } else
        {
            return ResponseFactory.CreateSuccessResponse<User>(user, $"User with ID {id} retrieved successfully.");
        }
    }

    public async Task<ResponseBase<List<User>>> GetAllUsersAsync()
    {
        var userList = await _userRepository.GetAllAsync();

        return ResponseFactory.CreateSuccessResponse<List<User>>(userList, "Users retrieved successfully.");
    }

    public async Task<ResponseBase> AddUserAsync(User user)
    {
        var result = await _userRepository.AddAsync(user);
        
        return ResponseFactory.CreateSuccessResponse(result > 0 ? "User added successfully." : "Failed to add user.");
    }

    public async Task<ResponseBase> UpdateUserAsync(User user)
    {
        var result = await _userRepository.UpdateAsync(user);

        return ResponseFactory.CreateSuccessResponse(result > 0 ? "User updated successfully." : "Failed to update user.");
    }

    public async Task<ResponseBase> DeleteUserAsync(int id)
    {
        var result = await _userRepository.DeleteAsync(id);

        return ResponseFactory.CreateSuccessResponse(result > 0 ? "User deleted successfully." : "Failed to delete user.");
    }
}