using Teapot.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.Chats.Dto;
using Teapot.Entities.Concrete;
using Teapot.DataAccess.Contexts;
using Teapot.Business.Concrete.Messages.Dto;
using Microsoft.EntityFrameworkCore;

namespace Teapot.Business.Concrete.Chats
{
    public class ChatManager : IChatService
    {

        private readonly Teapot418DbContext _context;

        public ChatManager(Teapot418DbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<Chat>> Add(AddChatDto addChatDto)
        {
            var chatToAdd = await _context.Chats.AddAsync(new Chat() { ContributerId = addChatDto.ContributerId, ProjectOwnerId = addChatDto.ProjectOwnerId });
            await _context.SaveChangesAsync();
            return new SuccessDataResult<Chat>(chatToAdd.Entity, "chat added");
        }

        public async Task<IResult> Delete(int id)
        {
            var chatToDelete = await _context.Chats.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (chatToDelete != null)
            {
                _context.Chats.Remove(chatToDelete);
                return new SuccessResult("chat deleted");

            }
            return new ErrorResult("chat cannot find");
        }

        public async Task<IDataResult<List<Chat>>> GetAll()
        {
            var chats = await _context.Chats.ToListAsync();
            if (chats != null)
            {
                return new SuccessDataResult<List<Chat>>(chats, "chats listed");
            }
            return new ErrorDataResult<List<Chat>>("chats cannot listed");
        }

        public async Task<IDataResult<Chat>> GetById(int id)
        {
            var chat = await _context.Chats.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (chat != null)
            {
                return new SuccessDataResult<Chat>(chat, "chat get");
            }
            return new ErrorDataResult<Chat>("chat cannot get");
        }
    }
}
