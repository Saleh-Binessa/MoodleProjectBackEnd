using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleBackEnd.Models.Entites;
using MoodleBackEnd.Models.Requests;
using MoodleBackEnd.Models.Responses;
using System.Threading.Tasks;

namespace MoodleBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly MoodleContext _context;
        public TasksController(MoodleContext context)
        {
            _context = context;
        }

       // [Authorize(Roles = "Admin,Instructor,Student")]
        [HttpGet]
        public ActionResult<List<TaskResponse>> GetAllTasks()
        {
            var tasks = _context.Tasks.Select(e => new TaskResponse
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,

            }).ToList();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Instructor,Student")]
        public ActionResult<TaskResponse> GetTaskDetails(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            var response = new TaskEntity
            {
                Id = task.Id = id,
                Name = task.Name,
                Description = task.Description,
                MaterialId = task.MaterialId,
            };
            return Ok(response);
        }
        [HttpPost]
       // [Authorize(Roles = "Admin,Instructor")]
        public IActionResult AddTask(TaskRequest request)
        {
            var task = new TaskEntity()
            {

                Name = request.Name,
                Description = request.Description,
                MaterialId = request.MaterialId,
                
            };
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Ok(new { Message = "Task Added" });
        }
    }
}