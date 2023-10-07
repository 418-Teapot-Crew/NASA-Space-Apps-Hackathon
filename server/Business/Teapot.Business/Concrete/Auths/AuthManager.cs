using Core.Utilities.Results;
using Teapot.Business.Concrete.Auths.Dto;

namespace Teapot.Business.Concrete.Auths
{
    public class AuthManager : IAuthService
    {
        public async Task<IDataResult<LoggedInDto>> Login(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<LoggedInDto>> Register(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }
    }
}
