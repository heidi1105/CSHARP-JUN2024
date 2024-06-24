using Microsoft.EntityFrameworkCore;

namespace ApiPractice.Models;
public class ApiContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; } = null!;
}