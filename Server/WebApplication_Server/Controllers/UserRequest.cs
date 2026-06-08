using System.ComponentModel.DataAnnotations;

public class UserRequest
{
    public int Id { get; set; }
    [Required]
    public string Account { get; set; } = "";
    [Required]
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public bool Enabled { get; set; }
    public DateOnly Birthday { get; set; }
}