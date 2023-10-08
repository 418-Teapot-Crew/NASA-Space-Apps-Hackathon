using Microsoft.AspNetCore.Mvc;
using Teapot.Business.Concrete.Users.Dto;
using Teapot.Business.Concrete.Users;
using Teapot.Entities.Concrete;
using Teapot.Business.Concrete.Projects;
using Teapot.Business.Concrete.Projects.Dto;
using Teapot.Business.Concrete.ProjectContributors;

namespace Teapot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IProjectContributorService _projectContributorService;

        public ProjectsController(IProjectService projectService, IProjectContributorService projectContributorService)
        {
            _projectService = projectService;
            _projectContributorService = projectContributorService;
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

        [HttpGet("getprojectsbyuserid")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var result = await _projectService.GetProjectsByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcontributesbyuserid")]
        public async Task<IActionResult> GetContributeByUserId(int userId)
        {
            var result = await _projectContributorService.GetProjectsByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
