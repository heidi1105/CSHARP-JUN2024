using System.ComponentModel.DataAnnotations;

namespace ApiPractice.Models;
public class Student
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

}