namespace Teapot.Business.Concrete.Auths.Dto
{
    public class GithubLoginDto
    {
        public string Code { get; set; }
    }
    public class GithubEmailsDto
    {
        public string Email { get; set; }
        public bool Primary { get; set; }
    }

    public class GithubUserResponseDto
    {
        public string Name { get; set; }
    }
}
