using Teapot.Business.Concrete.Auths.Dto;
using Teapot.Business.Concrete.Users;
using Teapot.Core.Entities.Concrete;
using Teapot.Core.Utilities.Results;
using Teapot.Core.Utilities.Security.Hashing;
using Teapot.Core.Utilities.Security.JWT;
using Teapot.DataAccess.Contexts;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.Auths
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public async Task<IDataResult<LoggedInDto>> Register(RegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new AppUser
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            await _userService.Add(user);
            return new SuccessDataResult<LoggedInDto>(new() { }, "User successfully registered!"); // TODO: object will be returned
        }

        public async Task<IDataResult<LoggedInDto>> Login(LoginDto userForLoginDto)
        {
            var userToCheck = await _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<LoggedInDto>("User not found!");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<LoggedInDto>("Wrong password!");
            }

            return new SuccessDataResult<LoggedInDto>(new LoggedInDto { }, "Successfully login!");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult("User already exists!");
            }
            return new SuccessResult();
        }

        public async Task<IDataResult<AccessToken>> CreateAccessToken(AppUser user)
        {
            var claims = await _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Access token successfully created!");
        }
    }
}
