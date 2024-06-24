using Microsoft.AspNetCore.Mvc;
using ApiPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPractice.Controllers;
[Route("api/students")]
[ApiController]
public class StudentController(ApiContext context) : ControllerBase
{
    private readonly ApiContext _context = context;

    [HttpGet]
    public async Task<ActionResult<Student[]>> GetAllStudents()
    {
        return await _context.Students.ToArrayAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(long id)
    {
        Student? student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        return student;
    }

    [HttpPost]
    public async Task<ActionResult<Student>> CreateStudent([FromBody] Student student)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return student;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> DeleteStudent(long id)
    {
        Student? student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return "success";
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<string>> UpdateStudent(long id, [FromBody] Student student)
    {
        Student? existingStudent = await _context.Students.FindAsync(id);
        if (existingStudent == null) return NotFound();
        if (!ModelState.IsValid) return BadRequest(ModelState);
        existingStudent.Name = student.Name;
        existingStudent.Email = student.Email;
        await _context.SaveChangesAsync();
        return "success";
    }
}