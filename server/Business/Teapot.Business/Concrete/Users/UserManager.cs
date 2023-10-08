using Microsoft.EntityFrameworkCore;
using Teapot.Business.Concrete.Projects.Dto;
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
            await _context.SaveChangesAsync();
            return new SuccessDataResult<AppUser>(user.Entity, "user added");
        }

        public async Task<IResult> Delete(int id)
        {
            var userToDelete = await  _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (userToDelete !=null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
                return new SuccessResult();
            }
            return new ErrorResult("user cannot find");

        }

        public async Task<IDataResult<List<UserListDto>>> GetAll()
        {
            
            var users = await _context.Users.Select(u => new UserListDto { Id = u.Id, Email = u.Email, FirstName = u.FirstName, LastName = u.LastName, Status = u.Status, Description = u.Description }).ToListAsync();
            if (users != null)
            {
                return new SuccessDataResult<List<UserListDto>>(users, "users listed");
            }
            return new ErrorDataResult<List<UserListDto>>("users cannot get");
        }

        public async Task<IDataResult<UserListDto>> GetById(int id)
        {
            var user = await _context.Users.Where(u => u.Id == id).Select(u=> new UserListDto { Id = u.Id ,Email = u.Email, FirstName = u.FirstName,LastName = u.LastName,Status = u.Status,Description = u.Description }).FirstOrDefaultAsync();
            if (user != null)
            {
                return new SuccessDataResult<UserListDto>(user, "user get");
            }
            return new ErrorDataResult<UserListDto>("user cannot get");

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



        public async Task<IDataResult<UserListDto>> Update(int id, UpdateUserDto updateUserDto)
        {
            var userToUpdate = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (userToUpdate != null)
            {
                userToUpdate.FirstName = updateUserDto.FirstName;
                userToUpdate.LastName = updateUserDto.LastName;
                userToUpdate.Description = updateUserDto.Description;
                _context.Users.Update(userToUpdate);
                await _context.SaveChangesAsync();
                return new SuccessDataResult<UserListDto>(new UserListDto {
                    Id = userToUpdate.Id,
                    FirstName = userToUpdate.FirstName,
                    LastName = userToUpdate.LastName,   
                    Description = userToUpdate.Description,
                   Email = userToUpdate.Email,
                   Status = userToUpdate.Status
                },"user updated");
            }
            return new ErrorDataResult<UserListDto>("user cannot updated");
        }
    }
}
