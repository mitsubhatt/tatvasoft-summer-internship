using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mission.Entities.Models;
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
        public ResponseResult Login(LoginUserRequestModel model)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result = _loginService.login(model);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;

            //if (user == null) {
            //    return NotFound("please check your email and password");
            //}
            //return Ok("login successfully");
        }
        [HttpGet]
        [Route("Registeration")]
        [Authorize(Roles ="admin")]
        public string registeration()
        {
            return "registeration api";
        }
        [HttpGet]
        [Route("getUser")]
        [Authorize(Roles = "user")]
        public string getUser()
        {
            return "getUser api";
        }
    }
}