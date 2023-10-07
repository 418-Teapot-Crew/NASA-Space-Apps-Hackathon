using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.Chats.Dto;
using Teapot.Business.Concrete.Invites.Dto;
using Teapot.Business.Concrete.Users.Dto;
using Teapot.Core.Utilities.Results;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.Invites
{
    public interface IInviteService
    {

        Task<IResult> Add(AddInviteDto addInviteDto);
        Task<IDataResult<InviteListDto>> GetById(int id);
        Task<IDataResult<List<InviteListDto>>> GetAll();
        Task<IResult> Delete(int id);
        Task<IDataResult<InviteListDto>> Update(int id, UpdateInviteDto updateInviteDto);

    }
}
