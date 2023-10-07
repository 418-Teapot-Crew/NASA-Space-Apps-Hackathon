using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teapot.Business.Concrete.Projects.Dto;

namespace Teapot.Business.Concrete.Invites.Dto
{
    public class ProjectListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public ProjectListOwnerDto Owner { get; set; }
        public IEnumerable<ProjectListContributorDto> Contributors { get; set; }
    }
}
