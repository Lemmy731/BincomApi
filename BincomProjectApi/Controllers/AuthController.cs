using BincomProjectApi.Model.DTOs;
using BincomProjectApi.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BincomProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly ILoginService _loginService;
        public AuthController(ILoginService loginService, IRegisterService registerService)
        {
            _loginService = loginService;
            _registerService = registerService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> UserLogin([FromBody]LoginDto loginDto)
        {
            try
            {
                var response = await _loginService.Login(loginDto);
                if(response.StatusCode == StatusCodes.Status200OK)
                 {
                    return Ok(response);
                 }
                return BadRequest(response);    
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);  
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> UserRegister([FromBody]RegisterDto registerDto)
        {
            try
            {
                var response = await _registerService.Register(registerDto);
                if (response.StatusCode == StatusCodes.Status200OK) 
                {
                    return Ok(response);
                }
                return BadRequest(response);    
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
