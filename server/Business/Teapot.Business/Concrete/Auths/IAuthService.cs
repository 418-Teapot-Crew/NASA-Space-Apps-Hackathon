using Teapot.Business.Concrete.Auths.Dto;
using Teapot.Core.Utilities.Results;
using Teapot.Core.Utilities.Security.JWT;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.Auths
{
    public interface IAuthService
    {
        Task<IDataResult<LoggedInDto>> Login(LoginDto loginDto);
        Task<IDataResult<LoggedInDto>> Register(RegisterDto registerDto);
        IResult UserExists(string email);
        Task<IDataResult<AccessToken>> CreateAccessToken(AppUser user);
    }
}
