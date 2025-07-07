using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mission.Services.IServices;
using System.ComponentModel.DataAnnotations;

namespace Mission.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string EmailAddress, string Password)
        {
            var user = _loginService.login(EmailAddress, Password);
            if (user == null) {
                return NotFound("please check your email and password");
            }
            return Ok("login successfully");
        }
    }
}