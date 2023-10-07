using Teapot.Business.Concrete.Auths.Dto;
using Teapot.Core.Utilities.Results;
using Teapot.Core.Utilities.Security.JWT;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.Auths
{
    public interface IAuthService
    {
        Task<IDataResult<AppUser>> Login(LoginDto loginDto);
        Task<IDataResult<AppUser>> Register(RegisterDto registerDto);
        Task<IResult> UserExists(string email);
        Task<IDataResult<AccessToken>> CreateAccessToken(AppUser user);
        Task<IDataResult<AppUser>> GithubLogin(GithubLoginDto githubLoginDto);
    }
}
