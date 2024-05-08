using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleBackEnd.Models.Entites.Users;
using MoodleBackEnd.Models.Entites;
using MoodleBackEnd.Models.Requests;
using MoodleBackEnd.Models.Responses;
using Microsoft.AspNetCore.Authorization;

namespace MoodleBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly MoodleContext _context;
        public InstructorController(MoodleContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "admin")]
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
