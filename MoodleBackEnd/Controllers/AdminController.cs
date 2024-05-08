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
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly MoodleContext _context;
        public AdminController(MoodleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<AdminResponse>> GetAllAdmins()
        {
            var admins = _context.Admins.Select(e => new AdminResponse
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                UserAccountId = e.UserAccountId,
                Username = e.Account.Username
            }).ToList();
            return Ok(admins);
        }

        //[Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        //[Authorize]
        public ActionResult<AdminResponse> GetAdminDetails(int id)
        {
            var admin = _context.Admins.Find(id);
            if (admin == null)
            {
                return NotFound();
            }
            var response = new AdminResponse
            {
                Id = id,
                Name = admin.Name,
                Email = admin.Email,
                UserAccountId = admin.UserAccountId,
                AccountType = admin.AccountType,
            };
            return Ok(response);

        }
        [HttpPost]
        //[Authorize(Roles = "admin")]
        public IActionResult AddAdmin(AdminRequest request)
        {
            var instructor = new InstructorEntity()
            {
                Name = request.Name,
                Email = request.Email,

                UserAccountId = request.UserAccountId,
                AccountType = request.AccountType,
            };
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
            return Ok(new { Message = "Instructor Added" });
        }
    }
}
