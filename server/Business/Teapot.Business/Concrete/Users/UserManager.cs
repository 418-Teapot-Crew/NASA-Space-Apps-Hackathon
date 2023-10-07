using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.Users.Dto;
using Teapot.DataAccess.Contexts;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.Users
{
    public class UserManager : IUserService
    {

        private readonly Teapot418DbContext _context;

        public UserManager(Teapot418DbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<User>> Add(AddUserDto addUserDto)
        {
            var user = await _context.Users.AddAsync(new User() { FirstName = addUserDto.FirstName,LastName = addUserDto.LastName, Email = addUserDto.Email, Password = addUserDto.Password});
            return new SuccessDataResult<User>(user, "user added");
        }

        public Task<IResult> Delete(int id)
        {
        }

        public Task<IDataResult<List<User>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> Update(UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> Update(int id, UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
