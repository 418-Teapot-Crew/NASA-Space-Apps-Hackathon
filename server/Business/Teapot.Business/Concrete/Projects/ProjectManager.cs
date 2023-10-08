using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Teapot.Business.Concrete.Projects.Dto;
using Teapot.Core.Utilities.Results;
using Teapot.DataAccess.Contexts;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.Projects
{
    public class ProjectManager : IProjectService
    {

        private readonly Teapot418DbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProjectManager(Teapot418DbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult<Project>> Add(AddProjectDto addProjectDto)
        {
            var projectToAdd = await _context.Projects.AddAsync(new Project() { Title = addProjectDto.Title, Description = addProjectDto.Description, OwnerId = addProjectDto.OwnerId });
            await _context.SaveChangesAsync();
            return new SuccessDataResult<Project>(projectToAdd.Entity, "project added");
        }

        public async Task<IResult> Delete(int id)
        {
            var projectToDelete = await _context.Projects.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (projectToDelete != null)
            {
                _context.Projects.Remove(projectToDelete);
                await _context.SaveChangesAsync();
                return new SuccessResult("project deleted");

            }
            return new ErrorResult("project cannot find");
        }

        public async Task<IDataResult<List<ProjectListDto>>> GetAll()
        {
            var projects = await _context.Projects.Select(p => new ProjectListDto
            {
                Description = p.Description,
                Owner = new ProjectListOwnerDto { Id = p.Owner.Id, Email = p.Owner.Email, FirstName = p.Owner.FirstName, LastName = p.Owner.LastName },
                Contributors = p.Contributors
                    .Select(c => new ProjectListContributorDto
                    {
                        Id = c.ContributorId,
                        Email = c.Contributor.Email,
                        FirstName = c.Contributor.FirstName,
                        LastName = c.Contributor.LastName,
                    }),
                Id = p.Id,
                OwnerId = p.OwnerId,
                Title = p.Title
            }).ToListAsync();
            if (projects != null)
            {
                return new SuccessDataResult<List<ProjectListDto>>(projects, "project listed");
            }
            return new ErrorDataResult<List<ProjectListDto>>("projects cannot listed");
        }

        public async Task<IDataResult<Project>> GetById(int id)
        {
            var user = await _context.Projects.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                return new SuccessDataResult<Project>(user, "project get");
            }
            return new ErrorDataResult<Project>("project cannot get");
        }

        public async Task<IDataResult<List<ChatMessageDto>>> GetMessages(int projectId)
        {
            var loggedUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var res = await _context
                .ChatHistories
                .Where(p => p.ProjectId == projectId)
                .Select(p => new ChatMessageDto
                {
                    Id = p.Id,
                    Message = p.Message,
                    Mine = p.SenderId == loggedUserId
                })
                .ToListAsync();
            return new SuccessDataResult<List<ChatMessageDto>>(res);
        }

        public async Task<int> GetOwnerIdByProject(int projectId)
        {
            var res = await _context
                .Projects
                .Where(p => p.Id == projectId)
                .Select(p => p.OwnerId)
                .FirstOrDefaultAsync();
            return res;
        }

        public async Task<IDataResult<Project>> Update(int id, UpdateProjectDto updateProjectDto)
        {
            var projectToUpdate = await _context.Projects.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (projectToUpdate != null)
            {
                projectToUpdate.Title = updateProjectDto.Title;
                projectToUpdate.Description = updateProjectDto.Description;
                _context.Projects.Update(projectToUpdate);
                await _context.SaveChangesAsync();
                return new SuccessDataResult<Project>(projectToUpdate, "project updated");
            }
            return new ErrorDataResult<Project>("project cannot updated");

        }
    }
}
