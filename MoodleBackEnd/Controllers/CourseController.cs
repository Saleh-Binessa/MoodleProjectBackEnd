using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleBackEnd.Models.Entites.Users;
using MoodleBackEnd.Models.Entites;
using MoodleBackEnd.Models.Requests;
using MoodleBackEnd.Models.Responses;

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
                  //  Phases = e.Phases,
                  //  Students = e.Students,
                }).ToList();
                return Ok(courses);
            }

            [HttpGet("{id}")]
            //[Authorize]
            public ActionResult<CourseResponse> GetCourseDetails(int id)
            {
                var course = _context.Courses.Find(id);
                if (course == null)
                {
                    return NotFound();
                }
                var response = new CourseEntity
                {
                    Id = course.Id = id,
                    Name = course.Name,
                    Description = course.Description,
                   // Phases = course.Phases,
                   // Students = course.Students,
                };
            return Ok(response);

        }
        [HttpPost]
            // [Authorize(Roles = "admin")]
            public IActionResult AddCourse(CourseRequest request)
            {
                var course = new CourseEntity()
                {

                    Name = request.Name,
                    Description = request.Description,
                   // Phases = request.Phases,
                  //  Students = request.Students,
                };
                _context.Courses.Add(course);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetCourseDetails), new { id = course.Id });
            }


        }
    }
