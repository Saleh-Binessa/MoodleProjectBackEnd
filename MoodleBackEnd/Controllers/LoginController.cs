using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleBackEnd.Models.Entites;
using MoodleBackEnd.Models.Entites.Users;
using MoodleBackEnd.Models.Requests;
using MoodleBackEnd.Models.Responses;
using MoodleBackEnd.Models.Services;

namespace MoodleBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TokenService service;
        private readonly MoodleContext _context;

        public LoginController(TokenService service, MoodleContext context)
        {
            this.service = service;
            _context = context;
        }
        [HttpPost]
        public IActionResult Login(UserLoginRequest loginDetails)
        {

            var response = service.GenerateToken(loginDetails.Username, loginDetails.Password);
            if (response.IsValid)
            {
                return Ok(new UserLoginResponse { Token = response.Token });
            }
            return BadRequest("Username and/or Password is wrong");
        }

        [HttpPost("Register")]
        public IActionResult CreateUserAndAssignRole(SignupRequest request)
        {
            // Create the user account first
            var userAccount = UserAccountEntity.Create(request.Username, request.Password, request.AccountType);
            userAccount.Name = request.Name;
            userAccount.Email = request.Email;
            _context.UserAccounts.Add(userAccount);
            _context.SaveChanges();  // Ensure the UserAccount ID is generated before using it

            // Assign the role based on the account type
            switch (request.AccountType)
            {
                case Role.Admin: // Admin
                    var adminEntity = new AdminEntity
                    {
                        Name = userAccount.Name,
                        Email = userAccount.Email,
                        UserAccountId = userAccount.Id,
                        Account = userAccount
                    };
                    _context.Admins.Add(adminEntity);
                    break;

                case Role.Instructor: // Instructor
                    var instructorEntity = new InstructorEntity
                    {
                        Name = userAccount.Name,
                        Email = userAccount.Email,
                        UserAccountId = userAccount.Id,
                        Account = userAccount
                    };
                    _context.Instructors.Add(instructorEntity);
                    break;

                case Role.Student: // Student
                    var studentEntity = new StudentEntity
                    {
                        Name = userAccount.Name,
                        Email = userAccount.Email,
                        UserAccountId = userAccount.Id,
                        Account = userAccount
                    };
                    _context.Students.Add(studentEntity);
                    break;

                default:
                    return BadRequest("Invalid account type specified.");
            }

            _context.SaveChanges();  // Save all changes to the database

            return Ok(new { Message = "User and role created successfully." });
        }

    }
}
