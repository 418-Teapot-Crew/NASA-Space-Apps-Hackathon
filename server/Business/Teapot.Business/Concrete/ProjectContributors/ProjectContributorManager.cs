using Teapot.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.ProjectContributors.Dto;
using Teapot.Entities.Concrete;
using Teapot.DataAccess.Contexts;
using Teapot.Business.Concrete.Messages.Dto;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Octokit;
using Project = Teapot.Entities.Concrete.Project;
using Teapot.Business.Concrete.Invites.Dto;
using Teapot.Business.Concrete.Projects.Dto;

namespace Teapot.Business.Concrete.ProjectContributors
{
    public class ProjectContributorManager : IProjectContributorService
    {

        private readonly Teapot418DbContext _context;

        public ProjectContributorManager(Teapot418DbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<ProjectContributor>> Add(AddProjectContributorDto addProjectContributorDto)
        {
            var projectContributorToAdd = await _context.ProjectContributors.AddAsync(new ProjectContributor()
            {
                ContributorId = addProjectContributorDto.ContributorId,
                ProjectId = addProjectContributorDto.ProjectId
            });
            await _context.SaveChangesAsync();
            return new SuccessDataResult<ProjectContributor>(projectContributorToAdd.Entity, "project contributer added");
        }

        public async Task<IResult> Delete(int id)
        {
            var projectContributorToDelete = await _context.ProjectContributors.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (projectContributorToDelete != null)
            {
                _context.ProjectContributors.Remove(projectContributorToDelete);
                await _context.SaveChangesAsync();
                return new SuccessResult("project contributor deleted");

            }
            return new ErrorResult("project contributor cannot find");
        }

        public async Task<IDataResult<List<ProjectContributor>>> GetAll()
        {
            var projectContributors = await _context.ProjectContributors.ToListAsync();
            if (projectContributors != null)
            {
                return new SuccessDataResult<List<ProjectContributor>>(projectContributors, "project contributers listed");
            }
            return new ErrorDataResult<List<ProjectContributor>>("project contributers cannot listed");
        }

        public async Task<IDataResult<List<AppUser>>> GetContributorsByProjectId(int projectId)
        {
           var contributors = await _context.ProjectContributors.Where(p => p.ProjectId == projectId).Select(p => p.Contributor).ToListAsync();
            if (contributors != null)
            {
                return new SuccessDataResult<List<AppUser>>(contributors, "project contributers listed");
            }
            return new ErrorDataResult<List<AppUser>>("project contributers cannot listed");
        }

        public async Task<IDataResult<List<Projects.Dto.ProjectListDto>>> GetProjectsByUserId(int userId)
        {
            var projects = await _context.ProjectContributors.Where(p => p.ContributorId == userId).Select(u=> u.Project).Select(u =>  new Projects.Dto.ProjectListDto
            {
                Id = u.Id,
                Description = u.Description,
                OwnerId = u.OwnerId,
                Title = u.Title,
                Contributors = u.Contributors.Select(u => new ProjectListContributorDto { Id = u.ContributorId, Email = u.Contributor.Email, FirstName = u.Contributor.FirstName, LastName = u.Contributor.LastName, }),
                Owner = new ProjectListOwnerDto { Id = u.Owner.Id, FirstName = u.Owner.FirstName, LastName = u.Owner.LastName, Email = u.Owner.Email },
            }).ToListAsync();
            if (projects != null)
            {
                return new SuccessDataResult<List<Projects.Dto.ProjectListDto>>(projects, "project contributers listed");
            }
            return new ErrorDataResult<List<Projects.Dto.ProjectListDto>>("project contributers cannot listed");
        }
    }
}
