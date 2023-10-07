using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using Teapot.Business.Concrete.Auths.Dto;
using Teapot.Business.Concrete.Users;
using Teapot.Core.Entities.Concrete;
using Teapot.Core.Utilities.Results;
using Teapot.Core.Utilities.Security.Hashing;
using Teapot.Core.Utilities.Security.JWT;
using Teapot.Entities.Concrete;
using AccessToken = Teapot.Core.Utilities.Security.JWT.AccessToken;

namespace Teapot.Business.Concrete.Auths
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly GithubSettings? _githubSettings;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IConfiguration configuration)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _githubSettings = configuration.GetSection("GithubSettings").Get<GithubSettings>();
        }

        public async Task<IDataResult<AppUser>> Register(RegisterDto userForRegisterDto)
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
                Status = true,
                RegisterTypeId = RegisterType.Direct
            };
            var createdUser = await _userService.Add(user);
            return new SuccessDataResult<AppUser>(createdUser.Data, "User successfully registered!");
        }

        public async Task<IDataResult<AppUser>> Login(LoginDto userForLoginDto)
        {
            var userToCheck = await _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<AppUser>("User not found!");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<AppUser>("Wrong password!");
            }

            return new SuccessDataResult<AppUser>(userToCheck, "Successfully login!");
        }

        public async Task<IResult> UserExists(string email)
        {
            if (await _userService.GetByMail(email) != null)
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

        public async Task<IDataResult<AppUser>> GithubLogin(GithubLoginDto githubLoginDto)
        {
            if (_githubSettings == null)
                return new ErrorDataResult<AppUser>();

            string? responseContent;
            using (var client = new HttpClient())
            {
                var parameters = new Dictionary<string, string>
                {
                    {"client_id",  _githubSettings.ClientId},
                    {"client_secret",  _githubSettings.ClientSecret},
                    {"redirect_uri",  _githubSettings.RedirectUri},
                    {"code",  githubLoginDto.Code},
                };
                var content = new FormUrlEncodedContent(parameters);
                var response = await client.PostAsync("https://github.com/login/oauth/access_token", content);
                responseContent = await response.Content.ReadAsStringAsync();
            }

            var values = HttpUtility.ParseQueryString(responseContent);
            var access_token = values["access_token"];

            if (values == null || string.IsNullOrWhiteSpace(access_token))
                return new ErrorDataResult<AppUser>(null, "Error while connecting GitHub services!");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"token {access_token}");
                client.DefaultRequestHeaders.Add("User-Agent", "Awesome-Octocat-App");
                var response = await client.GetAsync("https://api.github.com/user/emails");
                responseContent = await response.Content.ReadAsStringAsync();
            }

            var emails = JsonConvert.DeserializeObject<List<GithubEmailsDto>>(responseContent);
            if (emails == null || !emails.Any())
                return new ErrorDataResult<AppUser>(null, "Error while getting emails!");

            var primaryEmail = emails.FirstOrDefault(p => p.Primary);
            if (primaryEmail == default)
                return new ErrorDataResult<AppUser>(null, "User not have primary email!");

            var user = await _userService.GetByMail(primaryEmail.Email);
            if (user != null)
                return new SuccessDataResult<AppUser>(user, "");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"token {access_token}");
                client.DefaultRequestHeaders.Add("User-Agent", "Awesome-Octocat-App");
                var response = await client.GetAsync("https://api.github.com/user");
                responseContent = await response.Content.ReadAsStringAsync();
            }

            var userInfo = JsonConvert.DeserializeObject<GithubUserResponseDto>(responseContent);
            var userSplittedName = userInfo.Name.Split(" ");
            user = new AppUser
            {
                Email = primaryEmail.Email,
                FirstName = userSplittedName[0],
                LastName = userSplittedName[^1],
                Status = true,
                RegisterTypeId = RegisterType.GitHub
            };
            var createdUser = await _userService.Add(user);

            return new SuccessDataResult<AppUser>(createdUser.Data, "Success");
        }

        //public async Task<IDataResult<AppUser>> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
        //{
        //    var settings = new GoogleJsonWebSignature.ValidationSettings()
        //    {
        //        Audience = new List<string> { _configuration["ExternalLoginSettings:Google:Client_ID"] }
        //    };

        //    var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

        //    var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");
        //    Domain.Entities.Identity.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

        //    return await CreateUserExternalAsync(user, payload.Email, payload.Name, info, accessTokenLifeTime);
        //}
    }
}
