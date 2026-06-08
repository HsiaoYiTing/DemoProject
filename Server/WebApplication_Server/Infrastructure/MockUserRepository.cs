using WebApplication_Server.Models;

public class MockUserRepository : IUserRepository
{
    private List<User> _users;
    private int SuccessCode = 1;
    private int ErrorCode = 0;


    public MockUserRepository()
    {
        _users = new List<User>();
        _users.Add(createMockUser(1));
        _users.Add(createMockUser(2));
        _users.Add(createMockUser(3));
        _users.Add(createMockUser(4));
        _users.Add(createMockUser(5));
    }

    public async Task<int> AddAsync(User user)
    {
        user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
        user.LastLogin = DateTime.Now;
        user.CreateTime = DateTime.Now;

        _users.Add(user);

        return SuccessCode;
    }

    public async Task<int> DeleteAsync(int id)
    {
        _users.RemoveAll(u => u.Id == id);

        return SuccessCode;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return _users;
    }

    public async Task<int> UpdateAsync(User user)
    {
        var oldUser = _users.FirstOrDefault(u => u.Id == user.Id);
        if (oldUser != null) {
            user.LastLogin = oldUser.LastLogin;
            user.CreateTime = oldUser.CreateTime;
            _users.RemoveAll(u => u.Id == user.Id);
            _users.Add(user);

            return SuccessCode;
        } else {
            return ErrorCode;
        }
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    private User createMockUser(int id)
    {
        return new User{
            Id = id,
            Account = $"mockuser{id}",
            Name = $"Mock User {id}",
            Age = 25 + id,
            Salary = 50000 + (id * 1000),
            Enabled = true,
            Birthday = DateOnly.FromDateTime(new DateTime(1995, 5, 15).AddYears(id)),
            LastLogin = DateTime.Now.AddDays(-7 * id),
            CreateTime = DateTime.Now.AddMonths(-6 * id)
        };
    }
}