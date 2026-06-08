using Microsoft.EntityFrameworkCore;
using WebApplication_Server.Models;

namespace WebApplication_Server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("demo_user");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.Account)
                .HasColumnName("account")
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Age)
                .HasColumnName("age");

            entity.Property(e => e.Salary)
                .HasColumnName("salary")
                .HasPrecision(10, 2);

            entity.Property(e => e.Enabled)
                .HasColumnName("enabled")
                .HasDefaultValue(true);

            entity.Property(e => e.Birthday)
                .HasColumnName("birthday")
                .HasColumnType("date");

            entity.Property(e => e.LastLogin)
                .HasColumnName("last_login")
                .HasColumnType("timestamp");

            entity.Property(e => e.CreateTime)
                .HasColumnName("create_time")
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

        });
    }
}