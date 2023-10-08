using Teapot.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.ProjectContributors.Dto;
using Teapot.Business.Concrete.Projects.Dto;
using Teapot.Business.Concrete.Users.Dto;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.ProjectContributors
{
    public interface IProjectContributorService
    {
        Task<IDataResult<ProjectContributor>> Add(AddProjectContributorDto addProjectContributorDto);
        Task<IDataResult<List<ProjectContributor>>> GetAll();
        Task<IDataResult<List<AppUser>>> GetContributorsByProjectId(int projectId);
        Task<IResult> Delete(int id);
        Task<IDataResult<List<Projects.Dto.ProjectListDto>>> GetProjectsByUserId(int userId);

    }
}
