using Core.Utilities.Results;
using Teapot.Business.Concrete.Auths.Dto;

namespace Teapot.Business.Concrete.Auths
{
    public interface IAuthService
    {
        Task<IDataResult<LoggedInDto>> Login(LoginDto loginDto);
        Task<IDataResult<LoggedInDto>> Register(RegisterDto registerDto);
    }
}
