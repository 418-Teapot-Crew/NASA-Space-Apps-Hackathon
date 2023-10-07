using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.Projects.Dto;
using Teapot.Business.Concrete.Users.Dto;
using Teapot.DataAccess.Contexts;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.Projects
{
    public class ProjectManager : IProjectService
    {

        public Task<IDataResult<Project>> Add(AddProjectDto addProjectDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<Project>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Project>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Project>> Update(int id, UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
