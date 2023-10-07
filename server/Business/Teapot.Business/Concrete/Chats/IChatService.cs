using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.Chats.Dto;
using Teapot.Business.Concrete.Projects.Dto;
using Teapot.Business.Concrete.Users.Dto;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.Chats
{
    public interface IChatService
    {
        Task<IDataResult<Chat>> Add(AddChatDto addChatDto);
        Task<IDataResult<Chat>> GetById(int id);
        Task<IDataResult<List<Chat>>> GetAll();
        Task<IResult> Delete(int id);


    }
}
