using Teapot.Business.Concrete.Projects.Dto;
using Teapot.Core.Utilities.Results;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.Projects
{
    public interface IProjectService
    {
        Task<IDataResult<Project>> Add(AddProjectDto addProjectDto);
        Task<IDataResult<ProjectListDto>> GetById(int id);
        Task<IDataResult<List<ProjectListDto>>> GetAll();
        Task<IResult> Delete(int id);
        Task<IDataResult<List<Project>>> GetProjectsByUserId(int userId);
        Task<IDataResult<Project>> Update(int id, UpdateProjectDto updateProjectDto);
        Task<int> GetOwnerIdByProject(int projectId);
        Task<IDataResult<List<ChatMessageDto>>> GetMessages(int projectId);
    }
}
