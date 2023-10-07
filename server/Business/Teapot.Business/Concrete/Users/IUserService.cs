using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.Auths.Dto;
using Teapot.Business.Concrete.Users.Dto;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.Users
{
    public interface IUserService
    {

        Task<IDataResult<User>> Add(AddUserDto addUserDto);
        Task<IDataResult<User>> GetById(int id);
        Task<IDataResult<List<User>>> GetAll();
        Task<IResult> Delete(int id);
        Task<IDataResult<User>> Update(int id,UpdateUserDto updateUserDto);

    }
}
