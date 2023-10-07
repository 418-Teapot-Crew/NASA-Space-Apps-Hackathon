namespace Teapot.Business.Concrete.ProjectFiles.Dto
{
    public class DeleteProjectImageDto
    {
        public int ProjectId { get; set; }
        public IEnumerable<string> Urls { get; set; }
    }
}
