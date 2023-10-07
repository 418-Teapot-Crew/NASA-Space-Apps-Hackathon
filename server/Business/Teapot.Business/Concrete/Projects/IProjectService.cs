using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.Projects.Dto;
using Teapot.Business.Concrete.Users.Dto;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.Projects
{
    public interface IProjectService
    {
        Task<IDataResult<Project>> Add(AddProjectDto addProjectDto);
        Task<IDataResult<Project>> GetById(int id);
        Task<IDataResult<List<Project>>> GetAll();
        Task<IResult> Delete(int id);
        Task<IDataResult<Project>> Update(int id,UpdateUserDto updateUserDto);
    }
}
