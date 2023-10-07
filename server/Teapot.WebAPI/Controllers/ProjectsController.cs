using Microsoft.AspNetCore.Mvc;
using Teapot.Business.Concrete.Users.Dto;
using Teapot.Business.Concrete.Users;
using Teapot.Entities.Concrete;
using Teapot.Business.Concrete.Projects;
using Teapot.Business.Concrete.Projects.Dto;

namespace Teapot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddProjectDto addProjectDto)
        {
            var result = await _projectService.Add(addProjectDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _projectService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _projectService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _projectService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, UpdateProjectDto updateProjectDto)
        {
            var result = await _projectService.Update(id, updateProjectDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
