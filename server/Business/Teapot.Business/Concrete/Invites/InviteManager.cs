using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.Chats.Dto;
using Teapot.Business.Concrete.Invites.Dto;
using Teapot.Business.Concrete.Projects.Dto;
using Teapot.Business.Concrete.Users.Dto;
using Teapot.Core.Utilities.Results;
using Teapot.DataAccess.Contexts;
using Teapot.Entities.Concrete;
using ProjectListDto = Teapot.Business.Concrete.Invites.Dto.ProjectListDto;

namespace Teapot.Business.Concrete.Invites
{
    public class InviteManager : IInviteService
    {

        private readonly Teapot418DbContext _context;

        public InviteManager(Teapot418DbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Add(AddInviteDto addInviteDto)
        {
            var inviteToAdd = await _context.Invites.AddAsync(new Invite() { ContributorId = addInviteDto.ContributorId, ProjectId = addInviteDto.ProjectId, Status = false});
            await _context.SaveChangesAsync();
            return new SuccessResult("invite added");
        }

        public async Task<IResult> Delete(int id)
        {
            var inviteToDelete = await _context.Chats.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (inviteToDelete != null)
            {
                _context.Chats.Remove(inviteToDelete);
                await _context.SaveChangesAsync();
                return new SuccessResult("invite deleted");

            }
            return new ErrorResult("invite cannot find");
        }

        public async Task<IDataResult<List<InviteListDto>>> GetAll()
        {
            var chats = await _context.Invites.Select(i=>  new InviteListDto { 
                ContributorId = i.ContributorId,
                Id = i.Id,
                ProjectId = i.ProjectId,
                Status = i.Status,
                Contributor = new ContributorListDto { Id = i.ContributorId, Email = i.Contributor.Email, FirstName = i.Contributor.FirstName, LastName = i.Contributor.LastName,},
                Project = new ProjectListDto { 
                    Id = i.Project.Id,
                    Title = i.Project.Title,
                    OwnerId = i.Project.OwnerId,
                    Owner = new ProjectListOwnerDto { Id = i.Project.Owner.Id,FirstName = i.Project.Owner.FirstName, Email = i.Project.Owner.Email,LastName = i.Project.Owner.LastName},
                    Description = i.Project.Description,
                    Contributors = i.Project.Contributors.Select(x => new ProjectListContributorDto {Id = x.Id,Email = x.Contributor.Email,LastName = x.Contributor.LastName,FirstName = x.Contributor.FirstName}),}
                }).ToListAsync();
            if (chats != null)
            {
                return new SuccessDataResult<List<InviteListDto>>(chats, "invites listed");
            }
            return new ErrorDataResult<List<InviteListDto>>("invites cannot listed");
        }

        public async Task<IDataResult<InviteListDto>> GetById(int id)
        {
            var invite = await _context.Invites.Where(c => c.Id == id).Select(i => new InviteListDto
            {
                Id = i.Id,
                ProjectId = i.ProjectId,
                Project = new ProjectListDto { Id = i.Project.Id, Title = i.Project.Title, Description = i.Project.Description, OwnerId = i.Project.OwnerId, Contributors = i.Project.Contributors.Select(x => new ProjectListContributorDto { Id = x.Id, Email = x.Contributor.Email, LastName = x.Contributor.LastName, FirstName = x.Contributor.FirstName }) },
                ContributorId = i.ContributorId,
                Contributor = new ContributorListDto { Id = i.ContributorId, Email = i.Contributor.Email, FirstName = i.Contributor.FirstName, LastName = i.Contributor.LastName },
                Status = i.Status
            }).FirstOrDefaultAsync();
            if (invite != null)
            {
                return new SuccessDataResult<InviteListDto>(invite, "invite get");
            }
            return new ErrorDataResult<InviteListDto>("invite cannot get");
        }

        public async Task<IDataResult<InviteListDto>> Update(int id, UpdateInviteDto updateInviteDto)
        {
            var inviteToUpdate = await _context.Invites.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (inviteToUpdate != null)
            {
                inviteToUpdate.Status = updateInviteDto.Status;
                //TODO: PROJEYE CONTRİBUTOR EKLENECEK
                _context.Invites.Update(inviteToUpdate);
                await _context.SaveChangesAsync();
                var inviteDto = new InviteListDto
                {
                    Id = inviteToUpdate.Id,
                    ProjectId = inviteToUpdate.ProjectId,
                    Project = new ProjectListDto { Id = inviteToUpdate.Project.Id, Title = inviteToUpdate.Project.Title, Description = inviteToUpdate.Project.Description, OwnerId = inviteToUpdate.Project.OwnerId, Contributors = inviteToUpdate.Project.Contributors.Select(x => new ProjectListContributorDto { Id = x.Id, Email = x.Contributor.Email, LastName = x.Contributor.LastName, FirstName = x.Contributor.FirstName }) },
                    ContributorId = inviteToUpdate.ContributorId,
                    Contributor = new ContributorListDto { Id = inviteToUpdate.ContributorId, Email = inviteToUpdate.Contributor.Email, FirstName = inviteToUpdate.Contributor.FirstName, LastName = inviteToUpdate.Contributor.LastName },
                    Status = inviteToUpdate.Status
                };
                return new SuccessDataResult<InviteListDto>(inviteDto, "invite updated");
            }
            return new ErrorDataResult<InviteListDto>("invite cannot updated");
        }

    }
}
