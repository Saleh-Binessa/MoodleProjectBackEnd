using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoodleBackEnd.Models.Entites;
using MoodleBackEnd.Models.Entites.Users;
using MoodleBackEnd.Models.Requests;
using MoodleBackEnd.Models.Responses;

namespace MoodleBackEnd.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : ControllerBase
    {

        private readonly MoodleContext _context;
        public AdminController(MoodleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<InstructorResponse>> GetAllInstructors()
        {
            var instructors = _context.Instructors.Select(e => new InstructorResponse
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email
            }).ToList();
            return Ok(instructors);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        //[Authorize]
        public ActionResult<InstructorResponse> GetInstructorDetails(int id)
        {
            var instructor = _context.Instructors.Find(id);
            if (instructor == null)
            {
                return NotFound();
            }
            var response = new InstructorResponse
            {
                Id = id,
                Name = instructor.Name,
                Email = instructor.Email,
            };
            return Ok(response);

        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddInstructor(InstructorRequest request)
        {
            var instructor = new InstructorEntity()
            {
                Name = request.Name,
                Email = request.Email
            };
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
            return Ok(new { Message = "Instructor Added" });
        }
    }
}
