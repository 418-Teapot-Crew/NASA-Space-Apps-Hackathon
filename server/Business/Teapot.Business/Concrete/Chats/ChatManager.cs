using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.Chats.Dto;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.Chats
{
    public class ChatManager : IChatService
    {
        public Task<IDataResult<Chat>> Add(AddChatDto addChatDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<Chat>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Chat>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
