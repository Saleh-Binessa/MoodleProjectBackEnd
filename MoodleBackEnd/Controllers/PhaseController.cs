using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleBackEnd.Models.Entites;
using MoodleBackEnd.Models.Requests;
using MoodleBackEnd.Models.Responses;

namespace MoodleBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhaseController : ControllerBase
    {
        private readonly MoodleContext _context;
        public PhaseController(MoodleContext context)
        {
            _context = context;
        }

        // [Authorize]
        [HttpGet]
        public ActionResult<List<PhaseResponse>> GetAllPhases()
        {
            var phases = _context.Phases.Select(e => new PhaseResponse
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
            }).ToList();
            return Ok(phases);
        }

        [HttpGet("{id}")]
        //[Authorize]
        public ActionResult<PhaseResponse> GetPhaseDetails(int id)
        {
            var phase = _context.Phases.Find(id);
            if (phase == null)
            {
                return NotFound();
            }
            var response = new PhaseEntity
            {
                Id = phase.Id = id,
                Name = phase.Name,
                Description = phase.Description,
            };
            return Ok(response);

        }

        [HttpPost("addPhase")]
        public IActionResult AddPhase(PhaseRequest request)
        {
            // Validate input
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Description))
            {
                return BadRequest("Phase name and description are required.");
            }

            // Create and save the course
            var phase = new PhaseEntity
            {
                Name = request.Name,
                Description = request.Description,
                CourseId = request.CourseId,
            };

            try
            {
                _context.Phases.Add(phase);
                _context.SaveChanges();



                return Ok(new { Message = "Phase Added" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error saving the phase: {ex.Message}");
            }

        }

    }
}
