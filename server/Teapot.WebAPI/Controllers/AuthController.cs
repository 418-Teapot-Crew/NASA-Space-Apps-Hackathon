using Microsoft.AspNetCore.Mvc;
using Teapot.Business.Concrete.Auths;
using Teapot.Business.Concrete.Auths.Dto;

namespace Teapot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _authService.Register(registerDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authService.Login(loginDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        //[HttpPost("github-login")]
        //public async Task<IActionResult> GitHubLogin([FromBody] LoginDto loginDto)
        //{
        //    var result = await _authService.GithubLogin(loginDto);
        //    if (!result.Success)
        //        return BadRequest(result);
        //    return Ok(result);
        //}
    }
}
