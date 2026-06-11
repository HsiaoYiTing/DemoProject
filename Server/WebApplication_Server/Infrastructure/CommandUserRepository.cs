using Dapper;
using Npgsql;
using WebApplication_Server.Models;

public class CommandUserRepository: IUserRepository
{
     private readonly IConfiguration _configuration;

    public CommandUserRepository(IConfiguration configuration)
    {
        _configuration = configuration;

    }

    public async Task<List<User>> GetAllAsync()
    {
          const string sql = """
            SELECT 

                id AS Id,
                account AS Account,
                name AS Name,
                age AS Age,
                salary AS Salary,
                enabled AS Enabled,
                birthday AS Birthday,
                last_login AS LastLogin,
                create_time AS CreateTime

            FROM demo_user
            ORDER BY id;
        """;

        using var connection = CreateConnection();

        var users = await connection.QueryAsync<User>(sql);

        return users.ToList();
    }

    // Dapper 轉物件的方式
    public async Task<User?> GetByIdAsync(int id)
    {
        using var connection = CreateConnection();

        const string sql = @"
            SELECT *
            FROM demo_user
            WHERE id = @Id
        ";

        return await connection.QueryFirstOrDefaultAsync<User>(
            sql,
            new { Id = id }
        );
    }

    public async Task<int> AddAsync(User user)
    {
        const string sql = """
            INSERT INTO demo_user (account, name, age, salary, enabled, birthday, last_login, create_time)
            VALUES (@account, @name, @age, @salary, @enabled, @birthday, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)
            RETURNING id;
        """;

        using var connection = CreateConnection();
        await connection.OpenAsync();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@account", user.Account);
        command.Parameters.AddWithValue("@name", user.Name);
        command.Parameters.AddWithValue("@age", user.Age);
        command.Parameters.AddWithValue("@salary", user.Salary);
        command.Parameters.AddWithValue("@enabled", user.Enabled);
        command.Parameters.AddWithValue("@birthday", user.Birthday);

        var rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected;
    }

    public async Task<int> UpdateAsync(User user)
    {
        const string sql = """
            UPDATE demo_user
            SET account = @account,
                name = @name,
                age = @age,
                salary = @salary,
                enabled = @enabled,
                birthday = @birthday,
                last_login = CURRENT_TIMESTAMP
            WHERE id = @id;
        """;

        using var connection = CreateConnection();
        await connection.OpenAsync();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", user.Id);
        command.Parameters.AddWithValue("@account", user.Account);
        command.Parameters.AddWithValue("@name", user.Name);
        command.Parameters.AddWithValue("@age", user.Age);
        command.Parameters.AddWithValue("@salary", user.Salary);
        command.Parameters.AddWithValue("@enabled", user.Enabled);
        command.Parameters.AddWithValue("@birthday", user.Birthday);

        var rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected;
    }

    public async Task<int> DeleteAsync(int id)
    {
        const string sql = "DELETE FROM demo_user WHERE id = @id;";

        using var connection = CreateConnection();
        await connection.OpenAsync();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", id);

        var rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected;
    }
    

    private NpgsqlConnection CreateConnection()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        return new NpgsqlConnection(connectionString);
    }
}