using Teapot.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.Projects.Dto;
using Teapot.Business.Concrete.Users.Dto;
using Teapot.DataAccess.Contexts;
using Teapot.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Teapot.Business.Concrete.Projects
{
    public class ProjectManager : IProjectService
    {

        private readonly Teapot418DbContext _context;

        public ProjectManager(Teapot418DbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<Project>> Add(AddProjectDto addProjectDto)
        {
            var projectToAdd = await _context.Projects.AddAsync(new Project() {Title = addProjectDto.Title, Description = addProjectDto.Description,OwnerId = addProjectDto.OwnerId });
            await _context.SaveChangesAsync();
            return new SuccessDataResult<Project>(projectToAdd.Entity, "project added");
        }

        public async Task<IResult> Delete(int id)
        {
            var projectToDelete = await _context.Projects.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (projectToDelete != null)
            {
                _context.Projects.Remove(projectToDelete);
                return new SuccessResult();

            }
            return new ErrorResult("project cannot find");
        }

        public async Task<IDataResult<List<Project>>> GetAll()
        {
            var projects = await _context.Projects.ToListAsync();
            if (projects != null)
            {
                return new SuccessDataResult<List<Project>>(projects, "project listed");
            }
            return new ErrorDataResult<List<Project>>("projects cannot listed");
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

        public async Task<IDataResult<Project>> Update(int id, UpdateProjectDto updateProjectDto)
        {
            var projectToUpdate = await _context.Projects.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (projectToUpdate != null)
            {
                projectToUpdate.Title = updateProjectDto.Title;
                projectToUpdate.Description = updateProjectDto.Description;
                _context.Projects.Update(projectToUpdate);
                await _context.SaveChangesAsync();
                return new SuccessDataResult<Project>(projectToUpdate);    
            }
            return new ErrorDataResult<Project>("project cannot updated");

        }
    }
}
