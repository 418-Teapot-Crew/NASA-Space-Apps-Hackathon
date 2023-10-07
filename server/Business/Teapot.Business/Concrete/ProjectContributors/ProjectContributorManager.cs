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
    }
}
