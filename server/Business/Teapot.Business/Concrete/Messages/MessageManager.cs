using Teapot.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.Projects.Dto;
using Teapot.Entities.Concrete;
using Teapot.Business.Concrete.Messages.Dto;
using Microsoft.EntityFrameworkCore;
using Teapot.DataAccess.Contexts;

namespace Teapot.Business.Concrete.Messages
{
    public class MessageManager : IMessageService
    {

        private readonly Teapot418DbContext _context;

        public MessageManager(Teapot418DbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<Message>> Add(AddMessageDto addMessageDto)
        {
            var messageToAdd = await _context.Messages.AddAsync(new Message() { ChatId = addMessageDto.ChatId, SenderId = addMessageDto.SenderId });
            await _context.SaveChangesAsync();
            return new SuccessDataResult<Message>(messageToAdd.Entity, "message added");
        }

        public async Task<IResult> Delete(int id)
        {
            var messageToDelete = await _context.Messages.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (messageToDelete != null)
            {
                _context.Messages.Remove(messageToDelete);
                return new SuccessResult("message deleted");

            }
            return new ErrorResult("message cannot find");
        }

        public async Task<IDataResult<List<Message>>> GetAll()
        {
            var messages = await _context.Messages.ToListAsync();
            if (messages != null)
            {
                return new SuccessDataResult<List<Message>>(messages, "message listed");
            }
            return new ErrorDataResult<List<Message>>("message cannot listed");
        }

        public async Task<IDataResult<Message>> GetById(int id)
        {
            var message = await _context.Messages.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (message != null)
            {
                return new SuccessDataResult<Message>(message, "message get");
            }
            return new ErrorDataResult<Message>("message cannot get");
        }
    }
}
