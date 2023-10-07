using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Teapot.Business.Concrete.ProjectFiles.Dto;
using Teapot.Business.Images;
using Teapot.Core.Utilities.Results;
using Teapot.DataAccess.Contexts;

namespace Teapot.Business.Concrete.ProjectImages
{
    public interface IProjectFileService
    {
        Task<IDataResult<ProjectImageCreatedDto>> Add(IFormFile formfile, int projectId);
        Task<IResult> Delete(DeleteProjectImageDto urlInfo);
        Task<IDataResult<GetFilesByProjectDto>> GetByProject(int projectId);
    }

    public class ProjectFileManager : IProjectFileService
    {
        private readonly IImageService _imageService;
        private readonly Teapot418DbContext _context;

        public ProjectFileManager(Teapot418DbContext context, IImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        public async Task<IDataResult<ProjectImageCreatedDto>> Add(IFormFile formfile, int projectId)
        {
            var projectExists = await _context.Projects.Where(p => p.Id == projectId).AnyAsync();
            if (!projectExists)
                return new ErrorDataResult<ProjectImageCreatedDto>("Project not found!");
            var uploadedUrl = await _imageService.UploadAsync(formfile);
            var newEntity = await _context.ProjectFiles.AddAsync(new()
            {
                ProjectId = projectId,
                ImageUrl = uploadedUrl
            });
            await _context.SaveChangesAsync();
            return new SuccessDataResult<ProjectImageCreatedDto>(new() { ImageUrl = uploadedUrl }, "Success");
        }

        public async Task<IResult> Delete(DeleteProjectImageDto urlInfo)
        {
            var projectFiles = await _context
                    .ProjectFiles
                    .Where(p => urlInfo.Urls.Contains(p.ImageUrl) && p.ProjectId == urlInfo.ProjectId)
                    .ToListAsync();

            if (projectFiles.Count != urlInfo.Urls.Count())
                return new ErrorResult("Some photos are not accessible");

            foreach (var item in urlInfo.Urls)
            {
                await _imageService.DeleteAsync(item);
                var projectFile = projectFiles.SingleOrDefault(p => p.ImageUrl == item);
                _context.ProjectFiles.Remove(projectFile);
            }
            await _context.SaveChangesAsync();

            return new SuccessResult("Success");
        }

        public async Task<IDataResult<GetFilesByProjectDto>> GetByProject(int projectId)
        {
            var dto = new GetFilesByProjectDto();
            var res = await _context
                .ProjectFiles
                .Where(p => p.ProjectId == projectId)
                .Select(p => p.ImageUrl)
                .ToListAsync();
            dto.Urls = res;
            return new SuccessDataResult<GetFilesByProjectDto>(dto, "success");
        }
    }
}
