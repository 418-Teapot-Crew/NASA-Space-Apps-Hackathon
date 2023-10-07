using Microsoft.AspNetCore.Mvc;
using Teapot.Business.Concrete.ProjectFiles.Dto;
using Teapot.Business.Concrete.ProjectImages;

namespace Teapot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectFilesController : ControllerBase
    {
        private readonly IProjectFileService _projectFileService;

        public ProjectFilesController(IProjectFileService projectFileService)
        {
            _projectFileService = projectFileService;
        }

        [HttpPost("upload/{projectId}")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromRoute] int projectId)
        {
            var result = await _projectFileService.Add(file, projectId);
            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProjectImageDto deleteProjectImageDto)
        {
            var res = await _projectFileService.Delete(deleteProjectImageDto);
            return Ok(res);
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetByProject([FromRoute] int projectId)
        {
            var res = await _projectFileService.GetByProject(projectId);
            return Ok(res);
        }
    }

    public class RemoveImageDto
    {
        public string Url { get; set; }
    }
}
