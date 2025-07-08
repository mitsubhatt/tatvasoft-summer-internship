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
        private readonly IWebHostEnvironment _hostEnvironment;
        public LoginController(ILoginService loginService, IWebHostEnvironment hostEnvironment)
        {
            _loginService = loginService;
            _hostEnvironment = hostEnvironment;
        }
        [HttpPost]
        [Route("LoginUser")]
        public ResponseResult Login(LoginUserRequestModel model)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _loginService.login(model);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;

            //if (user == null) {
            //    return NotFound("please check your email and password");
            //}
            //return Ok("login successfully");
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterUserModel model)
        {
            try
            {
                var res = _loginService.Register(model);
                return Ok(new ResponseResult() { Data = "User added!", Result = ResponseStatus.Success, Message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult() { Data = ex, Result = ResponseStatus.Success, Message = "Failed to add user" });
            }
        }

        [HttpGet]
        [Route("LoginUserDetailById/{id}")]
        public ResponseResult LoginUserDetailById(int id)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _loginService.loginUserDetailsById(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Result = ResponseStatus.Error;
            }
            return result;
        }

        [HttpPost]
        [Route("UpdateUser")]
        public ResponseResult UpdateUser(UserDetails model)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _loginService.updateUser(model, _hostEnvironment.WebRootPath);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Result = ResponseStatus.Error;
            }
            return result;
        }
    }
}