using Microsoft.EntityFrameworkCore;
using Teapot.Business.Concrete.Users.Dto;
using Teapot.Core.Entities.Concrete;
using Teapot.Core.Utilities.Results;
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

        public async Task<IDataResult<AppUser>> Add(AppUser addUserDto)
        {
            var user = await _context.Users.AddAsync(addUserDto);
            return new SuccessDataResult<AppUser>(user.Entity, "user added");
        }

        public Task<IResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<AppUser>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<AppUser>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser?> GetByMail(string email)
        {
            return await _context.Users.Where(p => p.Email == email).FirstOrDefaultAsync();
        }

        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            var res = await _context
                 .UserOperationClaims
                 .Where(p => p.UserId == user.Id)
                 .Select(p => new OperationClaim
                 {
                     Id = p.OperationClaimId,
                     Name = p.OperationClaim.Name
                 })
                 .ToListAsync();
            return res;
        }

        public Task<IDataResult<AppUser>> Update(UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<AppUser>> Update(int id, UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
