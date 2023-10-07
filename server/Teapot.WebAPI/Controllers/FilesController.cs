using Microsoft.AspNetCore.Mvc;
using Teapot.Business.Images;

namespace Teapot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public FilesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            var result = await _imageService.UploadAsync(file);
            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] RemoveImageDto removeImageDto)
        {
            await _imageService.DeleteAsync(removeImageDto.Url);
            return Ok();
        }
    }

    public class RemoveImageDto
    {
        public string Url { get; set; }
    }
}
