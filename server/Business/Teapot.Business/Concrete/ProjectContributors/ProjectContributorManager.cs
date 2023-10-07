using Teapot.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.ProjectContributors.Dto;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.ProjectContributors
{
    public class ProjectContributorManager : IProjectContributorService
    {
        public Task<IDataResult<ProjectContributor>> Add(AddProjectContributorDto addProjectContributorDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<ProjectContributor>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<AppUser>>> GetContributorsByProjectId(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
