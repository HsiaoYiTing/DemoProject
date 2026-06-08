using Microsoft.EntityFrameworkCore;
using WebApplication_Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
// 加入 Controller 支援

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, CommandUserRepository>(); // SQL Command 方式的 Repository
// builder.Services.AddScoped<IUserRepository, UserRepository>(); // Entity Framework Core 方式的 Repository
// builder.Services.AddSingleton<IUserRepository, MockUserRepository>(); // Mock Repository，使用 In-Memory 的 List<User> 來模擬資料庫的行為
builder.Services.AddScoped<UserService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("VuePolicy", policy =>
    {
        policy
        .WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("VuePolicy");

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();