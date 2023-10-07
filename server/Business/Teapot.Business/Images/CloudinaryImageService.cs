using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Teapot.Business.Images
{
    public class CloudinaryImageService : IImageService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryImageService(IConfiguration configuration)
        {
            Account account = configuration.GetSection("CloudinaryAccount").Get<Account>();
            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> UploadAsync(IFormFile formFile)
        {
            await FileMustBeInDefinedFormat(formFile);

            ImageUploadParams imageUploadParams = new()
            {
                File = new(formFile.FileName, formFile.OpenReadStream()),
                UseFilename = false,
                UniqueFilename = true,
                Overwrite = false
            };
            ImageUploadResult imageUploadResult = await _cloudinary.UploadAsync(imageUploadParams);

            return imageUploadResult.Url.ToString();
        }

        public async Task DeleteAsync(string imageUrl)
        {
            DeletionParams deletionParams = new(GetPublicId(imageUrl));
            await _cloudinary.DestroyAsync(deletionParams);
        }

        private string GetPublicId(string imageUrl)
        {
            int startIndex = imageUrl.LastIndexOf('/') + 1;
            int endIndex = imageUrl.LastIndexOf('.');
            int length = endIndex - startIndex;
            return imageUrl.Substring(startIndex, length);
        }

        private async Task FileMustBeInDefinedFormat(IFormFile formFile)
        {
            List<string> extensions = new() { ".jpg", ".png", ".jpeg", ".webp", ".pdf" };

            string extension = Path.GetExtension(formFile.FileName).ToLower();
            if (!extensions.Contains(extension)) throw new Exception("Unsupported format");
            await Task.CompletedTask;
        }
    }
}
