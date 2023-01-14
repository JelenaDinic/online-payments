
using Microsoft.AspNetCore.Mvc;
using PaymentBackend.DTO;
using PaymentBackend.Models;
using PaymentBackend.Services.Interfaces;
using System.Security.Claims;

namespace PaymentBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {

                return Ok(_userService.GetById(id));
            }
            catch
            {
                return Problem("Something went wrong while getting user id", null, 500);
            }
        }
        [HttpPost("login")]
        public IActionResult Login(LoginCredentials loginCredentials)
        {
            User user = _userService.CheckUserLoginCredentials(loginCredentials.Email, loginCredentials.Password);

            if (user != null)
            {
                var token = _userService.GenerateJwt(user);
                return Ok(new { token });
            }
            else
            {
                throw new Exception();
            }

        }
        [HttpPost]
        public IActionResult Create(UserRegistrationDTO user)
        {
            User u = new User();
            u.PhoneNumber = user.PhoneNumber;
            u.Lastname = user.Lastname;
            u.Name = user.Name;
            u.Email = user.Email;
            u.Password = user.Password;
            u.Budget = 0;
            u.IsVerified = true;
            try
            {
                _userService.Create(u);
                return Ok(u);
            } catch
            {
                throw new Exception();
            }
            

        }
        [HttpGet("logged")]
        public ActionResult GetLoggedPatient()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                int userId = Int32.Parse(identity.FindFirst("UserId").Value);
                User user = _userService.GetById(userId);
                return Ok(user);
            }
            return BadRequest();

        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                _userService.Update(user);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(user);
        }

    }
}
