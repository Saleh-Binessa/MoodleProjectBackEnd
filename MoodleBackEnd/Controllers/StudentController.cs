using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleBackEnd.Models.Entites;
using MoodleBackEnd.Models.Entites.Users;
using MoodleBackEnd.Models.Requests;
using MoodleBackEnd.Models.Responses;

namespace MoodleBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly MoodleContext _context;
        public StudentController(MoodleContext context) 
        {
            _context = context;
        }

        [Authorize(Roles = "admin,Instructor")]
        [HttpGet]
        public ActionResult<List<StudentResponse>> GetAllStudents()
        {
            var students = _context.Students.Select(e => new StudentResponse
            {
                Id = e.StudentId,
                Name = e.Name,
                Email = e.Email
            }).ToList();
            return Ok(students);
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<StudentResponse> GetStudentDetails(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            var response = new StudentResponse
            {
                Id = id,
                Name = student.Name,
                Email = student.Email,
            };
            return Ok(response);

        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddStudent(StudentRequest request)
        {
            var student = new StudentEntity()
            {
                Name = request.Name,
                Email = request.Email
            };
            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok(new { Message = "Student Added" });
        }

    }
}
