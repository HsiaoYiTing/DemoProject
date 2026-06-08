using WebApplication_Server.Models;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<int> AddAsync(User user);
    Task<int> UpdateAsync(User user);
    Task<int> DeleteAsync(int id);
}