using Microsoft.EntityFrameworkCore;
using WebApplication_Server.Data;
using WebApplication_Server.Models;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<User>> GetAllAsync()
    {
        var users = await _dbContext.Users.ToListAsync();

        return users;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

        return user;
    }

    public async Task<int> AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        var result = await _dbContext.SaveChangesAsync();

        return result;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        var result = 0;
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            result = await _dbContext.SaveChangesAsync();
        }

        return result;
    }

    public async Task<int> UpdateAsync(User user)
    {
        var existingUser = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == user.Id);

        var result = 0;
        if (existingUser != null)
        {
            existingUser.Account = user.Account;
            existingUser.Name = user.Name;
            existingUser.Age = user.Age;
            existingUser.Salary = user.Salary;
            existingUser.Enabled = user.Enabled;
            existingUser.Birthday = user.Birthday;
            existingUser.LastLogin = user.LastLogin;
            
            result = await _dbContext.SaveChangesAsync();
        }

        return result;
    }
}