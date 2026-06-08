namespace WebApplication_Server.Models;

public class User
{
    public int Id { get; set; }
    public string Account { get; set; } = "";
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public bool Enabled { get; set; }
    public DateOnly Birthday { get; set; }
    public DateTime LastLogin { get; set; }
    public DateTime CreateTime { get; set; }
}
