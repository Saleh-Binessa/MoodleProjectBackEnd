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
            //var newAccount =  UserAccount.Create();
            //var service = new TokenService(null,new BankContext("Data Source=db.app"))
            var response = service.GenerateToken(loginDetails.Username, loginDetails.Password);
            if (response.IsValid)
            {
                return Ok(new UserLoginResponse { Token = response.Token });
            }
            return BadRequest("Username and/or Password is wrong");
        }

        [HttpPost("Register")]
        public IActionResult Register(SignupRequest request)
        {
            //var isAdmin = false;
            //if (context.UserAccounts.Count() == 0)
            //{
            //    isAdmin = true;
            //}
            var newUser = UserAccountEntity.Create(request.Username, request.Password, request.AccountType);
            newUser.Name = request.Name;
            newUser.Email = request.Email;
            _context.UserAccounts.Add(newUser);
            _context.SaveChanges();

            return Ok(new { Message = "User Created" });

        }
    }
}
