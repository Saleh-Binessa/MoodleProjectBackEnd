using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleBackEnd.Models.Entites;
using MoodleBackEnd.Models.Requests;
using MoodleBackEnd.Models.Responses;

namespace MoodleBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly MoodleContext _context;
        public SubmissionController(MoodleContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,Instructor")]
        [HttpGet]
        public ActionResult<List<SubmissionResponse>> GetAllSubmissions()
        {
            var submissions = _context.Submissions.Select(e => new SubmissionResponse
            {
                SubmissionLink = e.SubmissionLink,
                Date = DateTime.Now,

            }).ToList();
            return Ok(submissions);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Instructor,Student")]
        public ActionResult<SubmissionResponse> GetSubmissionDetails(int id)
        {
            var submission = _context.Submissions.Find(id);
            if (submission == null)
            {
                return NotFound();
            }
            var response = new SubmissionEntity
            {
                Id = submission.Id = id,
                SubmissionLink = submission.SubmissionLink,
                CreatedDate = submission.CreatedDate,
                TaskEntityId = submission.TaskEntityId,

            };
            return Ok(response);
        }
        [HttpPost("AddSubmission")]
        [Authorize(Roles = "Admin,Instructor,Student")]
        public IActionResult AddSubmission(SubmissionRequest request)
        {
            var submission = new SubmissionEntity()
            {

                SubmissionLink = request.SubmissionLink,
                CreatedDate = request.Date,
            };
            _context.Submissions.Add(submission);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSubmissionDetails), new { id = submission.Id });
        }

        [HttpPost("PostGrade")]
        [Authorize(Roles = "Admin,Instructor")]
        [HttpPost]
        public IActionResult PostGrade(GradeRequest request)
        {
            var grade = new GradeEntity()
            {
                Score = request.Score,
            };
            _context.Grades.Add(grade);
            _context.SaveChanges();
            return Ok(new { Message = "Submited" });
        }
    }
}
