using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleBackEnd.Models.Entites.Users;
using MoodleBackEnd.Models.Entites;
using MoodleBackEnd.Models.Requests;
using MoodleBackEnd.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace MoodleBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
            private readonly MoodleContext _context;
            public CourseController(MoodleContext context)
            {
                _context = context;
            }

            // [Authorize]
            [HttpGet]
            public ActionResult<List<CourseResponse>> GetAllInstructors()
            {
                var courses = _context.Courses.Select(e => new CourseResponse
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Phases = e.Phases.Select(vv=> new PhaseResponse
                    {
                       Description = vv.Description,
                       Name = vv.Name,
                       Id = vv.Id,
                    }).ToList(),
                  //  Students = e.Students,
                }).ToList();
                return Ok(courses);
            }

            [HttpGet("{id}")]
            //[Authorize]
            public ActionResult<CourseResponse> GetCourseDetails(int id)
            {
                var course = _context.Courses.Include(v=> v.Phases).SingleOrDefault(r=> r.Id == id);
                if (course == null)
                {
                    return NotFound();
                }
                var response = new CourseResponse
                {
                    Id = course.Id = id,
                    Name = course.Name,
                    Description = course.Description,
                    Phases = course.Phases.Select(vv => new PhaseResponse
                    {
                        Description = vv.Description,
                        Name = vv.Name,
                        Id = vv.Id,
                        CourseId = course.Id,
                    }).ToList(),
                };
            return Ok(response);

        }

        [HttpPost("addCourse")]
        public IActionResult AddCourse(CourseRequest request)
        {
            // Validate input
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Description))
            {
                return BadRequest("Course name and description are required.");
            }

            // Create and save the course
            var course = new CourseEntity
            {
                Name = request.Name,
                Description = request.Description
            };

            try
            {
                _context.Courses.Add(course);
                _context.SaveChanges();



                return Ok(new { Message = "Course Added" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error saving the course: {ex.Message}");
            }

        }


    }
    }
