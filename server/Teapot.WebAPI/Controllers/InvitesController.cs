using Microsoft.AspNetCore.Mvc;
using Teapot.Business.Concrete.Chats.Dto;
using Teapot.Business.Concrete.Chats;
using Teapot.Business.Concrete.Invites;
using Teapot.Business.Concrete.Invites.Dto;

namespace Teapot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitesController : ControllerBase
    {
        private readonly IInviteService _inviteService;

        public InvitesController(IInviteService ınviteService)
        {
            _inviteService = ınviteService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddInviteDto addInviteDto)
        {
            var result = await _inviteService.Add(addInviteDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _inviteService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _inviteService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _inviteService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, UpdateInviteDto updateInviteDto)
        {
            var result = await _inviteService.Update(id,updateInviteDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
