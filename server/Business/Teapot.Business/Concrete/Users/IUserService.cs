using Teapot.Business.Concrete.Users.Dto;
using Teapot.Core.Entities.Concrete;
using Teapot.Core.Utilities.Results;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.Users
{
    public interface IUserService
    {

        Task<IDataResult<AppUser>> Add(AppUser addUserDto);
        Task<IDataResult<AppUser>> GetById(int id);
        Task<IDataResult<List<AppUser>>> GetAll();
        Task<IResult> Delete(int id);
        Task<IDataResult<AppUser>> Update(int id, UpdateUserDto updateUserDto);
        Task<List<OperationClaim>> GetClaims(User user);
        Task<AppUser?> GetByMail(string email);

    }
}
