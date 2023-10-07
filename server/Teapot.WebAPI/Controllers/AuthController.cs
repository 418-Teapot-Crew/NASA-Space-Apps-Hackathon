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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var userExists = await _authService.UserExists(registerDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = await _authService.Register(registerDto);
            var result = await _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var x = _httpContextAccessor;
            var userToLogin = await _authService.Login(loginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = await _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
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
