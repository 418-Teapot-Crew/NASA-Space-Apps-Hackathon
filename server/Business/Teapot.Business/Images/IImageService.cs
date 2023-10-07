using Microsoft.AspNetCore.Http;

namespace Teapot.Business.Images
{
    public interface IImageService
    {
        Task<string> UploadAsync(IFormFile formFile);
        Task DeleteAsync(string imageUrl);
    }
}
