using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.Projects.Dto;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.Messages
{
    public class MessageManager : IMessageService
    {
        public Task<IDataResult<Message>> Add(AddProjectDto addProjectDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<Message>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Message>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
